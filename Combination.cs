using System;
using System.Text;

namespace DecimalFuzzGenerator
{
    public class Combination
    {
        static Random random = new Random();
        public bool Hi { get; }
        public bool Mid { get; }
        public bool Lo { get; }

        internal Combination(bool lo, bool mid, bool hi)
        {
            Lo = lo;
            Mid = mid;
            Hi = hi;
        }

        public decimal GenerateBoundary()
        {
            var lo = Lo ? uint.MaxValue : 0;
            var mid = Mid ? uint.MaxValue : 0;
            var hi = Hi ? uint.MaxValue : 0;
            var negative = random.Next() % 2 == 0;
            var scale = (byte)random.Next(0, 29);
            return new Decimal((int)lo, (int)mid, (int)hi, negative, scale);
        }
        
        public decimal Generate()
        {
            var lo = Lo ? random.Next() : 0;
            var mid = Mid ? random.Next() : 0;
            var hi = Hi ? random.Next() : 0;
            var negative = random.Next() % 2 == 0;
            var scale = (byte)random.Next(0, 29);
            var d = new Decimal(lo, mid, hi, negative, scale);
            return d;
        }

        public bool IsZero => !Lo && !Mid && !Hi;

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(Lo ? "1" : "0");
            text.Append(Mid ? "1" : "0");
            text.Append(Hi ? "1" : "0");
            return text.ToString();
        }
    }
}