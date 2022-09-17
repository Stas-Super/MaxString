using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxString
{
    public class Result
    {
        public double Max { get; set; }
        public double MaxLine { get; set; }
        public List<String> BadStrings { get; set; } = new();
        public override string ToString()
        {
            return $"Max = {Max} (Line = {MaxLine})\n" + String.Join('\n', BadStrings);
        }
    }
}
