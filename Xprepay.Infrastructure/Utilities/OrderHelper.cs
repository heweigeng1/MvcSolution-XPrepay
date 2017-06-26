using System;
using System.Collections.Generic;

namespace Xprepay.Utilities
{
    public class OrderHelper
    {
        private static int num = 0;
        public string GetOnlyOrderNum()
        {
            var time = DateTime.Now;
            string random = new Random(time.Millisecond + num).Next(1000, 9999).ToString();
            string timestamp = time.Year.ToString() + time.Month.ToString() + time.Day.ToString();
            lock (random)
            {
                if (num == 99999)
                {
                    num = 1;
                }
                else
                {
                    num++;
                }
                return timestamp + random + num.ToString().PadLeft(6, '0');
            }
        }
    }
}
