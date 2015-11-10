namespace SimulateNestedLoops
{
    using System.IO;
    using System.Text;

    public class StartUp
    {
        private static readonly int Size = 3;
        private static readonly int[] Result = new int[Size];

        public static void Main()
        {
            // Run the unit test. 
            // You maybe need to wait some time so that the second test can be executed successfully. It's big.
            // Sorry for that.
        }

        public static void SimulateNestedLoops(int startValue, int endValue, string fileName, StringBuilder builder, int depth = 0)
        {
            if (depth == Size)
            {
                builder.AppendLine(string.Join(", ", Result));

                var writer = new StreamWriter("../../../Output tests/" + fileName + ".txt");

                using (writer)
                {
                    writer.WriteLine(builder.ToString());
                }
                                
                return;
            }

            for (int i = startValue + 1; i <= endValue; i++)
            {
                Result[depth] = i;
                SimulateNestedLoops(0, endValue, fileName, builder, depth + 1);
            }
        }
    }
}
