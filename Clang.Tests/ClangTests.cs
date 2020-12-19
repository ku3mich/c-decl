using Antlr4;
using Xunit;
using Xunit.Abstractions;

namespace Clang.Tests
{
    public class ClangTests : XunitTest
    {
        private readonly ClangHelper _helper;

        public ClangTests(ClangHelper helper, ITestOutputHelper output) : base(output)
        {
            _helper = helper;
        }

        private ClangParser Prepare(string s) => _helper.CreateParser(s);

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