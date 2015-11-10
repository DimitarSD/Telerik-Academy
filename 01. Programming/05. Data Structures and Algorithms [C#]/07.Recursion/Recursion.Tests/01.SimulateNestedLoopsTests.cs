namespace Recursion.Tests
{
    using System.IO;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SimulateNestedLoops;

    [TestClass]
    public class SimulateNestedLoopsTests
    {
        [TestMethod]
        public void SimulateNestedLoopsMethodShouldHaveCorrectBehaviourOne()
        {
            StartUp.SimulateNestedLoops(0, 2, "output_1", new StringBuilder());

            var readerOutput = new StreamReader("../../../Output tests/output_1.txt");
            string output = string.Empty;
            
            using (readerOutput)
            {
                output = readerOutput.ReadToEnd();
            }

            var readerExpectedOutput = new StreamReader("../../../Output tests/expected_output_1.txt");
            string expectedOutput = string.Empty;

            using (readerExpectedOutput)
            {
                expectedOutput = readerExpectedOutput.ReadToEnd();
            }

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SimulateNestedLoopsMethodShouldHaveCorrectBehaviourTwo()
        {
            StartUp.SimulateNestedLoops(3, 15, "output_2", new StringBuilder());

            var readerOutput = new StreamReader("../../../Output tests/output_2.txt");
            string output = string.Empty;
                     
            using (readerOutput)
            {
                output = readerOutput.ReadToEnd();
            }

            var readerExpectedOutput = new StreamReader("../../../Output tests/expected_output_2.txt");
            string expectedOutput = string.Empty;

            using (readerExpectedOutput)
            {
                expectedOutput = readerExpectedOutput.ReadToEnd();
            }

            Assert.AreEqual(expectedOutput, output);
        }

        [TestMethod]
        public void SimulateNestedLoopsMethodShouldHaveCorrectBehaviourThree()
        {
            StartUp.SimulateNestedLoops(4, 9, "output_3", new StringBuilder());

            var readerOutput = new StreamReader("../../../Output tests/output_3.txt");
            string output = string.Empty;

            using (readerOutput)
            {
                output = readerOutput.ReadToEnd();
            }

            var readerExpectedOutput = new StreamReader("../../../Output tests/expected_output_3.txt");
            string expectedOutput = string.Empty;

            using (readerExpectedOutput)
            {
                expectedOutput = readerExpectedOutput.ReadToEnd();
            }

            Assert.AreEqual(expectedOutput, output);
        }
    }
}
