using System;
using System.IO;
using System.Text;

namespace HackerRank
{
    public class Output
    {
        public static void PrintArray(string file, int[] arr)
        {
            var folder = Environment.GetEnvironmentVariable("TEST_OUTPUT_FOLDER");
            var path = Path.Combine(folder, file);
            TextWriter textWriter = new StreamWriter(path, true);
            var builder = new StringBuilder();
            builder.Append("[");
            var first = true;
            foreach (var element in arr)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append(", ");
                }
                builder.Append(element);
            }
            builder.Append("]");
            textWriter.WriteLine(builder);
            textWriter.Close();
        }
    }
}
