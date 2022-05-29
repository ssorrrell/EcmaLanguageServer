using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using JsonRpc.Contracts;
using LanguageServer.Contracts;
using Newtonsoft.Json.Linq;

namespace EcmaLanguageServer.Services
{
    [JsonRpcScope(MethodPrefix = "workspace/")]
    public class WorkspaceService : EcmaLanguageServiceBase
    {
        [JsonRpcMethod(IsNotification = true)]
        public async Task DidChangeConfiguration(SettingsRoot settings)
        {
            //await Client.Window.LogMessage(MessageType.Log, "WorkspaceService.DidChangeConfiguration ");
            Session.Settings = settings.EcmaLanguageServer;
            foreach (var doc in Session.Documents.Values)
            {
                //await Client.Window.LogMessage(MessageType.Log, "WorkspaceService.DidChangeConfiguration docs " + doc?.Document?.Content?.Length);
                var diag = Session.DiagnosticProvider.LintDocument(doc.Document, Session.Settings.MaxNumberOfProblems);
                await Client.Document.PublishDiagnostics(doc.Document.Uri, diag);
            }
        }

        [JsonRpcMethod(IsNotification = true)]
        public async Task DidChangeWatchedFiles(ICollection<FileEvent> changes)
        {
            //await Client.Window.LogMessage(MessageType.Log, "WorkspaceService.DidChangeWatchedFiles changes " + changes.Count);
            foreach (var change in changes)
            {
                if (!change.Uri.IsFile) continue;
                var localPath = change.Uri.AbsolutePath;
                //await Client.Window.LogMessage(MessageType.Log, "WorkspaceService.DidChangeWatchedFiles localPath " + localPath);
                //if (string.Equals(Path.GetExtension(localPath), ".demo"))
                //{
                //    // If the file has been removed, we will clear the lint result about it.
                //    // Note that pass null to PublishDiagnostics may mess up the client.
                //    //await Client.Window.LogMessage(MessageType.Log, "WorkspaceService.DidChangeWatchedFiles ChangeType " + change?.Type);
                //    if (change.Type == FileChangeType.Deleted)
                //    {
                //        await Client.Document.PublishDiagnostics(change.Uri, new Diagnostic[0]);
                //    }
                //}
            }
        }
    }
}
