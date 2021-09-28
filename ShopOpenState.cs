using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiOpen
{
    static class ShopOpenState
    {
        static bool isOpen = false;
        const int penalty = -5;

       public static bool getOpen()
        {
            return isOpen;
        }

        public static void setOpen(bool open)
        {
            isOpen = open;
        }

        public static int getPenalty()
        {
            return penalty;
        }


    }
}
