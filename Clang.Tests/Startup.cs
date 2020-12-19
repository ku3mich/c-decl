// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.Extensions.Essentials;
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Xunit.Extensions.Antlr4;
using Antlr4;

namespace Clang.Tests
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder) => hostBuilder
            .ConfigureXunitEssentials()
            .ConfigureServices(s => s
                .AddTransient<ClangHelper>()
                .AddTransient<Func<IParseTreeListener>>(s => () => s.GetRequiredService<IParseTreeListener>())
                .AddTransient<Func<IAntlrErrorListener<IToken>>>(s => () => s.GetRequiredService<IAntlrErrorListener<IToken>>())
                .AddTransient<IParseTreeListener, DebugListener>()
                .AddTransient<IAntlrErrorListener<IToken>, SyntaxErrorThrower>()
            );
    }
}
