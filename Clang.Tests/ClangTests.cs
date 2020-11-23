using Xunit;
using Xunit.Abstractions;
using XUnit.Antlr4;

namespace Clang.Tests
{
    public class ClangTests : AntlrTest
    {
        public ClangTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("")]
        [InlineData("int oops")]
        [InlineData("int*")]
        [InlineData("int (a)()")]
        [InlineData("int a()")]
        [InlineData("int a(int)")]
        [InlineData("int a(int, int a)")]
        [InlineData("int (a)(int)")]
        [InlineData("int (*a)(int)")]
        [InlineData("int (*a)(int *a[][])")]
        [InlineData("int *a()")]
        [InlineData("int i[]")]
        [InlineData("int[]")]
        [InlineData("int (*getFunc())(int, int)")]
        [InlineData("int (*getFunc(void))(int, int)")]
        [InlineData("int (*getFunc(int a, int *b[]))(int, int)")]
        [InlineData("int (*getFunc(void (*p)(), int *b[]))(int, int)")]
        public void TestCases(string s)
        {
            Prepare(s).file();
        }

        [Theory]
        [InlineData("typedef oops;")]
        [InlineData("typedef oops int;")]
        [InlineData("typedef int (*getFunc())(int, int);")]
        [InlineData("typedef int (*_sf) (int*[], int *a[][]);")]
        [InlineData("typedef int *x, (*p)();")]
        /*
int *x, (*p)();         // x has type int*, and p has type int(*)()
typedef int *x, (*p)(); // x is an alias for int*, while p is an alias for int(*)()        
        */

        public void TypeDef(string s)
        {
            Prepare(s).file();
        }



        [InlineData("int[] i")]
        [InlineData("typedef;")]
        [Theory]
        public void Fails(string s)
        {
            Assert.Throws<SyntaxErrorException>(() => Prepare(s).file());
        }
    }
}