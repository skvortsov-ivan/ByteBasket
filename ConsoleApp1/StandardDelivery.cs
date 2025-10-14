using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebasket
{
    public class StandardDelivery : Delivery
    {
        public override void HandleDelivery()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Standard delivery completed.");
        }
    }
}

