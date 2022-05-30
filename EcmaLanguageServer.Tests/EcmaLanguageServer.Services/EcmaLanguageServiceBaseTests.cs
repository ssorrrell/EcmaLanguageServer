using System;
using Xunit;
using EcmaLanguageServer.Services;

namespace EcmaLanguageServer.Tests.EcmaLanguageServer.Services
{
    public class EcmaLanguageServiceBaseTests : IDisposable
    {
        private readonly EcmaLanguageServiceBase _testee;

        public EcmaLanguageServiceBaseTests()
        {
            _testee = new EcmaLanguageServiceBase();
        }

        public void Dispose()
        {
            //clean up per test
        }
    }
}
