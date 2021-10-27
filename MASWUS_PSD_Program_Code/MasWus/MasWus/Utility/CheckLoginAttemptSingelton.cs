using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Utility
{
    public class CheckLoginAttemptSingelton
    {
        private static CheckLoginAttemptSingelton instance;

        private int attempt;

        private CheckLoginAttemptSingelton()
        {
            this.attempt = 0;
        }

        public static CheckLoginAttemptSingelton GetInstance()
        {
            if(instance == null)
            {
                instance = new CheckLoginAttemptSingelton();
            }

            return instance;
        }

        public void IncreaseAttempt()
        {
            attempt++;
        }

        public void ResetToZero()
        {
            attempt = 0;
        }

        public int GetAttemptTotal()
        {
            return attempt;
        }

    }
}