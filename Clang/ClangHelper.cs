﻿using Antlr4.Runtime;

namespace Clang
{
    public static class ClangHelper
    {
        public static CommonTokenStream CreateTokenStream(ICharStream stream) => new CommonTokenStream(new ClangLexer(stream));
        public static CommonTokenStream CreateTokenStream(string s) => CreateTokenStream(new AntlrInputStream(s));
    }
}
