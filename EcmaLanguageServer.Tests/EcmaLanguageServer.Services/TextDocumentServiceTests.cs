using System;
using Xunit;
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
        public void HoverTest()
        {
            //var textDocument = new TextDocument();
           // var position = new Position(0, 0);
            //_testee.Hover(textDocument, position, )
            //Assert.Equal()
        }
    }
}
