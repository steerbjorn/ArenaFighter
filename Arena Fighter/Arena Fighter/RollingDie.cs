using System;
using System.Collections.Generic;
using System.Text;

namespace Arena_Fighter
{
    class RollingDie
    {
        private Random random;
        private int sidesCount;

        public RollingDie()
        {
            sidesCount = 6;
            random = new Random();
        }

        public RollingDie(int sideCount)
        {
            this.sidesCount = sideCount;
            random = new Random();
        }

        public int GetSideCount()
        {
            return sidesCount;
        }

        public int Roll()
        {
            return random.Next(1, sidesCount + 1);
        }
    }
}
