using System;
using System.Threading.Tasks;
using JsonRpc;
using JsonRpc.Contracts;
using JsonRpc.Messages;
using JsonRpc.Server;
using LanguageServer.Contracts;
using Newtonsoft.Json.Linq;

namespace EcmaLanguageServer.Services
{
    public class InitializationService : EcmaLanguageServiceBase
    {

        [JsonRpcMethod(AllowExtensionData = true)]
        public InitializeResult Initialize(int processId, Uri rootUri, ClientCapabilities capabilities,
            JToken initializationOptions = null, string trace = null)
        {
            return new InitializeResult(new ServerCapabilities
            {
                //HoverProvider = new HoverOptions(),
                //SignatureHelpProvider = new SignatureHelpOptions("()"),
                //CompletionProvider = new CompletionOptions(true, "."),
                TextDocumentSync = new TextDocumentSyncOptions
                {
                    OpenClose = true,
                    WillSave = true,
                    Change = TextDocumentSyncKind.Incremental
                },
            });
        }

        [JsonRpcMethod(IsNotification = true)]
        public async Task Initialized()
        {
            await Client.Window.ShowMessage(MessageType.Info, $"ECMA Language Server Initialized");
            //var choice = await Client.Window.ShowMessage(MessageType.Warning, "Wanna drink?", "Yes", "No");
            //await Client.Window.ShowMessage(MessageType.Info, $"You chose {(string) choice ?? "Nothing"}.");
        }

        [JsonRpcMethod]
        public void Shutdown()
        {

        }

        [JsonRpcMethod(IsNotification = true)]
        public void Exit()
        {
            Session.StopServer();
        }

        [JsonRpcMethod("$/cancelRequest", IsNotification = true)]
        public void CancelRequest(MessageId id)
        {
            RequestContext.Features.Get<IRequestCancellationFeature>().TryCancel(id);
        }
    }
}
