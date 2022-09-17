using MaxString;

namespace UnitTests
{
    [TestClass]
    public class AppTest
    {
        private readonly MaxString.App _app = new();

        [TestMethod]
        public void TestSumNumbers()
        {
            Assert.AreEqual(
                51.9,
                _app.SumNumbers("1,2,3,5,6,7.2,8.2,9.2,10.3"),
                1e-10   // delta - equality precision
            );
            Assert.AreEqual(
                463,
                _app.SumNumbers("33,64,75,86,97,108")
            );

            String bad = "Bad string";
            Assert.AreEqual(
                bad,
                Assert.ThrowsException<ArgumentException>(
                    () => _app.SumNumbers(bad)
                ).Message
            );
        }

        [TestMethod]
        public void TestSplitFile()
        {
            String[] lines = _app.SplitFile("TextFile1.txt");
            Assert.IsNotNull(lines);
            Assert.AreEqual(3, lines.Length);

            Assert.ThrowsException<FileNotFoundException>(
                () => _app.SplitFile("UnExisting.txt")
            );
        }

        [TestMethod]
        public void TestMaxSumNumbers()
        {
            Result res = _app.MaxSumNumbers("TextFile1.txt");
            Assert.IsNotNull(res);
            Assert.AreEqual(463, res.Max);
            Assert.AreEqual(3, res.MaxLine);
            Assert.IsNotNull(res.BadStrings);
            Assert.AreEqual(0, res.BadStrings.Count);

            res = _app.MaxSumNumbers("TextFile2.txt");
            Assert.IsNotNull(res);
            Assert.AreEqual(463, res.Max);
            Assert.AreEqual(5, res.MaxLine);
            Assert.IsNotNull(res.BadStrings);
            Assert.AreEqual(2, res.BadStrings.Count);

        }
    }
}