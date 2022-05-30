using System;
using Xunit;
using EcmaLanguageServer.Services;

namespace EcmaLanguageServer.Tests.EcmaLanguageServer.Services
{
    public class WorkspaceServiceTests : IDisposable
    {
        private readonly WorkspaceService _testee;

        public WorkspaceServiceTests()
        {
            _testee = new WorkspaceService();
        }

        public void Dispose()
        {
            //clean up per test
        }
    }
}
