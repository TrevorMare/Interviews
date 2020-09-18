using System;

namespace Conway.Helpers
{

    public class RandomGenerator
    {

        #region Members
        private Random _rndWait = new Random(123);
        private Random _rndNext = new Random(321);
        #endregion

        #region Methods
        public byte GetNextRandomByte()
        {
            int waitTicks = _rndWait.Next(1, 500);
            System.Threading.Thread.Sleep(TimeSpan.FromTicks(waitTicks));

            int result = _rndNext.Next(0, 100);
            if (result <= 50)
                return 0;
            else
                return 1;
        }
        #endregion


    }

}