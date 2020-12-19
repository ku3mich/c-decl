using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Microsoft.Extensions.Logging;
using Xunit.Extensions.Antlr4;

namespace Clang.Tests
{
    public class ClangHelper : Antlr4Helper<ClangLexer, ClangParser>
    {
        public ClangHelper(ILogger logger, IEnumerable<Func<IParseTreeListener>> listnersFactory, Func<IAntlrErrorListener<IToken>> errorListnerFactory)
            : base(logger, listnersFactory, errorListnerFactory)
        {
        }
    }
}