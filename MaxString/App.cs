using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxString
{
    public class App
    {
        private readonly NumberFormatInfo _nfi = new NumberFormatInfo()
        {
            NumberDecimalSeparator = "."
        };

        /// <summary>
        /// Opens file and splits it into lines
        /// </summary>
        /// <param name="filename">Name of file</param>
        /// <returns>Array of file's lines</returns>
        public String[] SplitFile(String filename)
        {
            using StreamReader reader = new(filename);
            List<String> lines = new();
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
            return lines.ToArray();
        }

        /// <summary>
        /// Calculates sum of csv numbers
        /// </summary>
        /// <param name="csv">Comma separated values (string)</param>
        /// <returns></returns>
        public double SumNumbers(String csv)
        {
            double sum = 0;
            foreach (String str in csv.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    sum += Convert.ToDouble(str, _nfi);
                }
                catch
                {
                    throw new ArgumentException(str);
                }
            }
            return sum;
        }

        /// <summary>
        /// Scans file, look for max number, collects bad strings
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>Complex result of 'Result' class</returns>
        public Result MaxSumNumbers(String filename)
        {
            Result res = new();
            int lineNumber = 0;
            foreach (String line in SplitFile(filename))
            {
                lineNumber += 1;
                try
                {
                    double sum = SumNumbers(line);
                    if (sum > res.Max)
                    {
                        res.Max = sum;
                        res.MaxLine = lineNumber;
                    }
                }
                catch (ArgumentException ex)
                {
                    res.BadStrings.Add($"line: {lineNumber}, val: '{ex.Message}'");
                }

            }
            return res;
        }

        /// <summary>
        /// Entry points
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Enter file path (Empty to use 'TextFile2.txt')");
            String? userInput = Console.ReadLine();
            if(userInput is null)
            {
                Console.WriteLine("System error");
                return;
            }
            if(userInput == String.Empty)
            {
                userInput = "TextFile2.txt";
            }
            Result res = MaxSumNumbers(userInput);
            Console.WriteLine(res);
        }
    }
}
