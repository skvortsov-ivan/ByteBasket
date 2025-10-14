using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebasket
{
    public class ExpressDelivery : Delivery
    {
        public override void HandleDelivery()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Standard delivery completed.");
        }
    }
}
