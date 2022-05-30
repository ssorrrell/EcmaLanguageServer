using System;
using System.Threading.Tasks;
using Xunit;
using EcmaLanguageServer.Services;

namespace EcmaLanguageServer.Tests.EcmaLanguageServer.Services
{
    public class InitializationServiceTests : IDisposable
    {
        private readonly InitializationService _testee;

        public InitializationServiceTests()
        {
            _testee = new InitializationService();
        }


        public void Dispose()
        {
            //clean up per test
        }

        [Fact]
        public async Task InitializedTestAsync()
        {
        }
    }
}
