using System;
using Xunit;
using EcmaLanguageServer.Services;

namespace EcmaLanguageServer.Tests.EcmaLanguageServer.Services
{
    public class CompletionItemServiceTests : IDisposable
    {
        private readonly CompletionItemService _testee;

        public CompletionItemServiceTests()
        {
            _testee = new CompletionItemService();
        }

        public void Dispose()
        {
            //clean up per test
        }
    }
}
