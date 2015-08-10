﻿using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace VSDiagnostics.Diagnostics.Tests.RemoveTestSuffix
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class RemoveTestSuffixAnalyzer : DiagnosticAnalyzer
    {
        private const string Category = "Tests";
        private const string DiagnosticId = nameof(RemoveTestSuffixAnalyzer);
        private const string Message = "Test method \"{0}\" should not end with \"Test\".";
        private const DiagnosticSeverity Severity = DiagnosticSeverity.Warning;
        private const string Title = "Verifies whether a test method ends with \"Test\".";

        internal static DiagnosticDescriptor Rule => new DiagnosticDescriptor(DiagnosticId, Title, Message, Category, Severity, true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.MethodDeclaration);
        }

        private void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            var method = context.Node as MethodDeclarationSyntax;
            if (method == null)
            {
                return;
            }

            if (!method.Identifier.Text.EndsWith("Test", System.StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }

            if (!IsTestMethod(method))
            {
                return;
            }

            context.ReportDiagnostic(Diagnostic.Create(Rule, method.Identifier.GetLocation(), method.Identifier.Text));
        }

        private static bool IsTestMethod(MethodDeclarationSyntax method)
        {
            var methodAttributes = new[] { "Test", "TestMethod", "Fact" };
            var attributes = method.AttributeLists.FirstOrDefault()?.Attributes;

            if (attributes == null)
            {
                return false;
            }

            return attributes.Value.Any(x => methodAttributes.Contains(x.Name.ToString()));
        }
    }
}