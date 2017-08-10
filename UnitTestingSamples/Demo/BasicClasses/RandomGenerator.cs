using System;

namespace Demo
{
    public class RandomGenerator
    {
        private readonly Random rnd;

        public RandomGenerator()
        {
            rnd = new Random();
        }

        public int GetRandomInt() => rnd.Next(1, 101);
    }
}
