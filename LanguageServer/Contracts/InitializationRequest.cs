﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LanguageServer.Contracts
{

    /// <summary>
    /// Base class for client capabilities.
    /// This class provides some basic operations, such as implicit <see cref="bool"/> conversion.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ClientCapability
    {
        public static readonly ClientCapability Empty = new ClientCapability();

        /// <summary>
        /// Returns <c>true</c> only when the current <see cref="ClientCapability"/> is not <c>null</c>.
        /// </summary>
        public static implicit operator bool(ClientCapability cap)
        {
            return cap != null;
        }
    }

    public class DynamicClientCapability : ClientCapability
    {
        /// <summary>
        /// Whether this capability supports dynamic registration.
        /// </summary>
        [JsonProperty]
        public bool DynamicRegistration { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return DynamicRegistration ? "DynamicRegistration" : "";
        }
    }

    /// <summary>
    /// Defines the capabilities provided by the client.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ClientCapabilities
    {
        /// <summary>
        /// Workspace specific client capabilities.
        /// </summary>
        [JsonProperty]
        public WorkspaceClientCapability Workspace { get; set; }

        /// <summary>
        /// Text document specific client capabilities.
        /// </summary>
        [JsonProperty]
        public TextDocumentClientCapabilities TextDocument { get; set; }

        /// <summary>
        /// Window specific client capabilities.
        /// </summary>
        [JsonProperty]
        public WindowClientCapability Window { get; set; }

        /// <summary>
        /// Experimental client capabilities.
        /// </summary>
        [JsonProperty]
        public JToken Experimental { get; set; }
    }

    /// <summary>
    /// Defines capabilities the editor / tool provides on the workspace.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WorkspaceClientCapability
    {
        /// <summary>
        /// The client supports applying batch edits to the workspace by supporting
        /// the request 'workspace/applyEdit'.
        /// </summary>
        [JsonProperty]
        public bool ApplyEdit { get; set; }

        /// <summary>
        /// Capabilities specific to <see cref="WorkspaceEdit"/>s.
        /// </summary>
        [JsonProperty]
        public WorkspaceEditCapability WorkspaceEdit { get; set; }

        /// <summary>
        /// specific to the `workspace/didChangeConfiguration` notification.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability DidChangeConfiguration { get; set; }

        /// <summary>
        /// Capabilities specific to the `workspace/didChangeWatchedFiles` notification.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability DidChangeWatchedFiles { get; set; }

        /// <summary>
        /// Capabilities specific to the `workspace/symbol` request.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability Symbol { get; set; }

        /// <summary>
        /// Capabilities specific to the `workspace/executeCommand` request.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability ExecuteCommand { get; set; }

    }

    /// <summary>
    /// Capabilities specific to <see cref="WorkspaceEdit"/>s.
    /// </summary>
    public class WorkspaceEditCapability : ClientCapability
    {
        /// <summary>
        /// The client supports versioned document changes in <see cref="WorkspaceEdit"/>s.
        /// </summary>
        [JsonProperty]
        public bool DocumentChanges { get; set; }
    }

    /// <summary>
    /// Defines capabilities the editor / tool provides on text documents.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TextDocumentClientCapabilities
    {

        /// <summary>
        /// Synchronization supports.
        /// </summary>
        [JsonProperty]
        public TextDocumentSynchronizationCapability Synchronization { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/completion`
        /// </summary>
        [JsonProperty]
        public TextDocumentCompletionCapability Completion { get; set; }

        /// <summary>
        /// The server provides hover support.
        /// </summary>
        [JsonProperty]
        public TextDocumentHoverCapability Hover { get; set; }

        /// <summary>
        /// The server provides signature help support.
        /// </summary>
        [JsonProperty]
        public TextDocumentSignatureHelpCapability SignatureHelp { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/declaration` request. (LSP 3.14)
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability Declaration { get; set; }

        /// <summary>
        /// The server provides goto definition support.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability Definition { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/implementation` request. (LSP 3.6)
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability Implementation { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/typeDefinition` request. (LSP 3.6)
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability TypeDefinition { get; set; }

        /// <summary>
        /// The server provides find references support.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability References { get; set; }

        /// <summary>
        /// The server provides document highlight support.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability DocumentHighlight { get; set; }

        /// <summary>
        /// The server provides document symbol support.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability DocumentSymbol { get; set; }

        /// <summary>
        /// The server provides workspace symbol support.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability WorkspaceSymbol { get; set; }

        /// <summary>
        /// The server provides code actions.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability CodeAction { get; set; }

        /// <summary>
        /// The server provides code lens.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability CodeLens { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/documentLink` request.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability DocumentLink { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/documentColor` and the `textDocument/colorPresentation` request.
        /// (LSP 3.6)
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability ColorProvider { get; set; }

        /// <summary>
        /// The server provides document formatting.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability Formatting { get; set; }

        /// <summary>
        /// The server provides document range formatting.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability RangeFormatting { get; set; }

        /// <summary>
        /// The server provides document formatting on typing.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability OnTypeFormatting { get; set; }

        /// <summary>
        /// The server provides rename support.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability Rename { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/publishDiagnostics` notification.
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability PublishDiagnostics { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/foldingRange` notification. (LSP 3.10)
        /// </summary>
        [JsonProperty]
        public FoldingRangeClientCapabilities FoldingRange { get; set; }

        /// <summary>
        /// Capabilities specific to the `textDocument/selectionRange` notification. (LSP 3.15)
        /// </summary>
        [JsonProperty]
        public DynamicClientCapability SelectionRange { get; set; }

    }

    public class TextDocumentSynchronizationCapability : DynamicClientCapability
    {
        /// <summary>
        /// The client supports sending will save notifications.
        /// </summary>
        [JsonProperty]
        public bool WillSave { get; set; }

        /// <summary>
        /// The client supports sending a will save request and
        /// waits for a response providing text edits which will
        /// be applied to the document before it is saved.
        /// </summary>
        [JsonProperty]
        public bool WillSaveWaitUntil { get; set; }

        /// <summary>
        /// The client supports did save notifications.
        /// </summary>
        [JsonProperty]
        public bool DidSave { get; set; }
    }

    public class TextDocumentCompletionCapability : DynamicClientCapability
    {

        /// <summary>
        /// The client supports the following <see cref="Contracts.CompletionItem"/> specific capabilities.
        /// </summary>
        [JsonProperty]
        public TextDocumentCompletionItemCapability CompletionItem { get; set; }

        [JsonProperty]
        public TextDocumentCompletionItemKindCapability CompletionItemKind { get; set; }

        /// <summary>
        /// The client supports to send additional context information for a
        /// <c>textDocument/completion</c> request.
        /// </summary>
        [JsonProperty]
        public bool ContextSupport { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TextDocumentCompletionItemCapability
    {
        /// <summary>
        /// Client supports snippets as insert text.
        /// </summary>
        /// <remarks>
        /// A snippet can define tab stops and placeholders with `$1`, `$2`
        /// and `${3:foo}`. `$0` defines the final tab stop, it defaults to
        /// the end of the snippet. Placeholders with equal identifiers are linked,
        /// that is typing in one will update others too.
        /// </remarks>
        [JsonProperty]
        public bool SnippetSupport { get; set; }

        /// <summary>Client supports commit <see cref="CompletionItem.CommitCharacters"/> on a completion item.</summary>
        [JsonProperty]
        public bool CommitCharactersSupport { get; set; }

        /// <summary>
        /// Client supports the follow content formats for the documentation
        /// property.The order describes the preferred format of the client.
        /// </summary>
        [JsonProperty]
        public IList<MarkupKind> DocumentationFormat { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class TextDocumentCompletionItemKindCapability
    {
        /// <summary>
        /// The completion item kind values the client supports. When this
        /// property exists the client also guarantees that it will
        /// handle values outside its set gracefully and falls back
        /// to a default value when unknown.
        /// </summary>
        /// <remarks>
        /// If this property is not present, the client only supports
        /// the completion items kinds from `Text` to `Reference` as defined in
        /// the initial version of the protocol.
        /// </remarks>
        [JsonProperty]
        public IEnumerable<CompletionItemKind> ValueSet { get; set; }

    }

    /// <summary>
    /// Capabilities specific to the `textDocument/hover`.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TextDocumentHoverCapability : DynamicClientCapability
    {
        /// <summary>
        /// Client supports the follow content formats for the content property.
        /// The order describes the preferred format of the client.
        /// </summary>
        [JsonProperty]
        public IList<MarkupKind> ContentFormat { get; set; }
    }

    /// <summary>
    /// Capabilities specific to the `textDocument/signatureHelp`.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class TextDocumentSignatureHelpCapability : DynamicClientCapability
    {
        /// <summary>
        /// The client supports the following <see cref="SignatureInformation"/> specific properties.
        /// </summary>
        [JsonProperty]
        public TextDocumentSignatureInformationCapability SignatureInformation { get; set; }
    }
    
    [JsonObject(MemberSerialization.OptIn)]
    public class TextDocumentSignatureInformationCapability
    {
        /// <summary>
        /// Client supports the follow content formats for the documentation
        /// property. The order describes the preferred format of the client.
        /// </summary>
        [JsonProperty]
        public IList<MarkupKind> DocumentationFormat { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DocumentLinkClientCapabilities : DynamicClientCapability
    {
        /// <summary>
        /// Whether the client supports the `tooltip` property on `DocumentLink`. (LSP 3.15)
        /// </summary>
        [JsonProperty]
        public bool TooltipSupport { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class FoldingRangeClientCapabilities : DynamicClientCapability
    {
        /// <summary>
        /// The maximum number of folding ranges that the client prefers to receive per document.
        /// The value serves as a hint, servers are free to follow the limit.
        /// </summary>
        [JsonProperty]
        public int RangeLimit { get; set; }

        /// <summary>
        /// If set, the client signals that it only supports folding complete lines. If set, client will
        /// ignore specified `startCharacter` and `endCharacter` properties in a FoldingRange.
        /// </summary>
        [JsonProperty]
        public bool LineFoldingOnly { get; set; }
    }

    public class WindowClientCapability : ClientCapability
    {
        /// <summary>
        /// Whether client supports handling progress notifications.
        /// </summary>
        [JsonProperty]
        public bool WorkDoneProgress { get; set; }
    }

}
