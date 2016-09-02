using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Core.Common
{
    public class RandomNumber
    {
        public static Random rand = new Random();

        public static int RandomFromTo(int startNumber, int endNumber)
        {
            return rand.Next(startNumber, endNumber);
        }
    }
}
