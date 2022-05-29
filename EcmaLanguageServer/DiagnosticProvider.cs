using System;
using System.Collections.Generic;
using System.Text;
using LanguageServer.Contracts;
using LanguageServer.Server;
using Range = LanguageServer.Contracts.Range;
using Jint;

namespace EcmaLanguageServer
{
    public class DiagnosticProvider
    {

        public DiagnosticProvider()
        {

        }

        //private static readonly string[] Keywords =
        //    {".NET Framework", ".NET Core", ".NET Standard", ".NET Compact", ".NET"};

        public ICollection<Diagnostic> LintDocument(TextDocument document, int maxNumberOfProblems)
        {
            var diag = new List<Diagnostic>();
            var content = document.Content;
            var parser = new Jint.Parser.JavaScriptParser();
            var parserResults = parser.Parse(content);
            if (parserResults != null) return diag;
/*            foreach(string errorItem in parserResults.LexerErrorList)
            {
                //parse position
                //{line}:{col}-{line}:{col2}
                int pos = errorItem.IndexOf(":");
                int col = 0;
                int col2 = 0;
                int line = 0;
                string errorMessage = errorItem;
                if (pos > 0)
                {
                    line = int.Parse(errorItem.Substring(0, pos));
                    int pos2 = errorItem.IndexOf("-", pos);
                    col = int.Parse(errorItem.Substring(pos, pos2));
                    pos = pos2;
                    pos2 = errorItem.IndexOf(":", pos);
                    pos = pos2;
                    pos2 = errorItem.IndexOf(" ", pos);
                    col2 = int.Parse(errorItem.Substring(pos, pos2));
                    errorMessage = errorItem.Substring(pos2);
                }

                diag.Add(new Diagnostic(DiagnosticSeverity.Error,
                    new Range(new Position(line, col), new Position(line, col2)),
                    "Color Basic Lexer", "01", errorMessage));
            }
            foreach (string errorItem in parserResults.ParserErrorList)
            {
                //parse position
                //{line}:{col}-{line}:{col2}
                int pos = errorItem.IndexOf(":");
                int col = 0;
                int col2 = 0;
                int line = 0;
                string errorMessage = errorItem;
                if (pos > 0)
                {
                    line = int.Parse(errorItem.Substring(0, pos));
                    int pos2 = errorItem.IndexOf("-", pos);
                    col = int.Parse(errorItem.Substring(pos, pos2));
                    pos = pos2;
                    pos2 = errorItem.IndexOf(":", pos);
                    pos = pos2;
                    pos2 = errorItem.IndexOf(" ", pos);
                    col2 = int.Parse(errorItem.Substring(pos, pos2));
                    errorMessage = errorItem.Substring(pos2);
                }

                diag.Add(new Diagnostic(DiagnosticSeverity.Error,
                    new Range(new Position(line, col), new Position(line, col2)),
                    "Color Basic Parser", "02", errorMessage));
            }*/
            return diag;

            //if (string.IsNullOrWhiteSpace(content))
            //{
            //    diag.Add(new Diagnostic(DiagnosticSeverity.Hint,
            //        new Range(new Position(0, 0), document.PositionAt(content?.Length ?? 0)),
            //        "DLS", "DLS0001", "Empty document. Try typing something, such as \".net core\"."));
            //    return diag;
            //}
            //foreach (var kw in Keywords)
            //{
            //    int pos = 0;
            //    while (pos < content.Length)
            //    {
            //        pos = content.IndexOf(kw, pos, StringComparison.CurrentCultureIgnoreCase);
            //        if (pos < 0) break;
            //        var separatorPos = pos + kw.Length;
            //        if (separatorPos < content.Length && char.IsLetterOrDigit(content, separatorPos))
            //            continue;
            //        var inputKw = content.Substring(pos, kw.Length);
            //        if (inputKw != kw)
            //        {
            //            diag.Add(new Diagnostic(DiagnosticSeverity.Warning,
            //                new Range(document.PositionAt(pos), document.PositionAt(separatorPos)), "DLS", "DLS1001", $"\"{inputKw}\" should be \"{kw}\"."));
            //            if (diag.Count >= maxNumberOfProblems)
            //            {
            //                diag.Add(new Diagnostic(DiagnosticSeverity.Information,
            //                    new Range(document.PositionAt(pos), document.PositionAt(separatorPos)), "DLS", "DLS2001", "Too many messages, exiting…"));
            //                return diag;
            //            }
            //        }
            //        pos++;
            //    }
            //}
            //return diag;
        }
    }
}
