using System;
using Xunit;
using EcmaLanguageServer;

namespace EcmaLanguageServer.Tests
{
    public class DiagnosticProviderTests : IDisposable
    {
        private readonly DiagnosticProvider _testee;

        public DiagnosticProviderTests()
        {
            _testee = new DiagnosticProvider();
        }

        public void Dispose()
        {
            //clean up per test
        }

        [Fact]
        public void Test1()
        {
            
        }
    }
}
