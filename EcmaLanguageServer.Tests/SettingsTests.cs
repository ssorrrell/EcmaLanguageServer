using System;
using Xunit;
using EcmaLanguageServer;

namespace EcmaLanguageServer.Tests
{
    public class SettingsTests : IDisposable
    {
        private readonly LanguageServerSettings _testee;

        public SettingsTests()
        {
            _testee = new LanguageServerSettings();
        }

        public void Dispose()
        {
            //clean up per test
        }

        [Fact]
        public void MaxNumberOfProblems()
        {
            Assert.Equal(10, _testee.MaxNumberOfProblems);
        }
    }
}
