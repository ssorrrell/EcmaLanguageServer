using System;
using System.Threading;
using System.Collections.Generic;
using Xunit;
using LanguageServer.Contracts;
using EcmaLanguageServer.Services;

namespace EcmaLanguageServer.Tests.EcmaLanguageServer.Services
{
    public class TextDocumentServiceTests : IDisposable
    {
        private readonly TextDocumentService _testee;

        public TextDocumentServiceTests()
        {
            _testee = new TextDocumentService();
        }

        public void Dispose()
        {
            //clean up per test
        }

        [Fact]
        public async void HoverTest()
        {
            TextDocumentIdentifier textDocument = new TextDocumentIdentifier(new Uri("http://www.contoso.com/"));
            Position position = new Position(0, 0);
            CancellationToken ct = new CancellationToken();
            Hover hover = await _testee.Hover(textDocument, position, ct);
            Assert.Equal(MarkupKind.PlainText, hover.Contents.Kind);
            Assert.Equal("Test _hover_ @(0,0)\n\n" + "http://www.contoso.com/", hover.Contents.Value);
        }

        [Fact]
        public void SignatureHelpTest()
        {
            TextDocumentIdentifier textDocument = new TextDocumentIdentifier(new Uri("http://www.contoso.com/"));
            Position position = new Position(0, 0);
            SignatureHelp signatureHelp = _testee.SignatureHelp(textDocument, position);
            Assert.IsType<List<SignatureInformation>>(signatureHelp.Signatures);
            SignatureInformation signatureHelp1 = new SignatureInformation("**Function1**", "Documentation1");
            Assert.Equal(signatureHelp1.Label, signatureHelp.Signatures[0].Label);
            Assert.Equal(signatureHelp1.Documentation.Kind, signatureHelp.Signatures[0].Documentation.Kind);
            Assert.Equal(signatureHelp1.Documentation.Value, signatureHelp.Signatures[0].Documentation.Value);
            SignatureInformation signatureHelp2 = new SignatureInformation("**Function2** <strong>test</strong>", "Documentation2");
            Assert.Equal(signatureHelp2.Label, signatureHelp.Signatures[1].Label);
            Assert.Equal(signatureHelp2.Documentation.Kind, signatureHelp.Signatures[1].Documentation.Kind);
            Assert.Equal(signatureHelp2.Documentation.Value, signatureHelp.Signatures[1].Documentation.Value);
        }

/*        [Fact]
        public void CompletionTest()
        {
            CompletionItem[] PredefinedCompletionItems =
            {
            new CompletionItem(".NET", CompletionItemKind.Keyword,
                "Keyword1",
                MarkupContent.Markdown("Short for **.NET Framework**, a software framework by Microsoft (possibly its subsets) or later open source .NET Core."),
                null),
            new CompletionItem(".NET Standard", CompletionItemKind.Keyword,
                "Keyword2",
                "The .NET Standard is a formal specification of .NET APIs that are intended to be available on all .NET runtimes.",
                null),
            new CompletionItem(".NET Framework", CompletionItemKind.Keyword,
                "Keyword3",
                ".NET Framework (pronounced dot net) is a software framework developed by Microsoft that runs primarily on Microsoft Windows.", null),
            };

            TextDocumentIdentifier textDocument = new TextDocumentIdentifier(new Uri("http://www.contoso.com/"));
            Position position = new Position(0, 0);
            CompletionContext completionContext = new CompletionContext();
            CompletionList completionList = _testee.Completion(textDocument, position, completionContext);
            Assert.False(completionList.IsIncomplete);
            Assert.Contains<CompletionItem>(PredefinedCompletionItems[0], completionList.Items);
            Assert.Contains<CompletionItem>(PredefinedCompletionItems[1], completionList.Items);
            Assert.Contains<CompletionItem>(PredefinedCompletionItems[2], completionList.Items);
        }*/
    }
}
