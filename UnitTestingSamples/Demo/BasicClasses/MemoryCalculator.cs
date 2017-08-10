using System;
using System.Threading;

namespace Demo
{
    public class MemoryCalculator : IDisposable
    {
        public MemoryCalculator()
        {
            Thread.Sleep(2000);
        }

        public int IntInMemory { get; set; }
        public double DoubleInMemory { get; set; }
        public bool BooleanInMemory { get; set; }

        public int Add(int a, int b) => IntInMemory = a + b;

        public double Add(double a, double b) => DoubleInMemory =  a + b;

        public double Divide(double a, double b) => DoubleInMemory = a / b;

        public bool IsGreaterCheck(int a, int b) => BooleanInMemory = a > b;

        public void ClearData()
        {
            IntInMemory = 0;
            DoubleInMemory = 0;
            BooleanInMemory = false;
        }

        public void Dispose()
        {
            //Any disposable logic
        }
    }
}
