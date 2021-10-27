using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Utility
{
    public class TheadSingelton
    {
        private static TheadSingelton instance;
        private int threadId = 0;

        private TheadSingelton()
        {

        }

        public static TheadSingelton GetInsntance()
        {
            if(instance == null)
            {
                instance = new TheadSingelton();
            }
            return instance;
        }

        public void SaveThreadID(int threadId)
        {
            this.threadId = threadId;
        }

        public int GetThreadID()
        {
            return this.threadId;
        }

    }
}