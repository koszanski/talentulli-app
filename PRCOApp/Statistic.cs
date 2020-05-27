using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRCOApp
{
    public class Statistic
    {

        int statID;
        int statVal;
        int statTypeID;

        public Statistic(int theID, int theStatVal, int theTypeID)
        {
            statID = theID;
            statVal = theStatVal;
            statTypeID = theTypeID;
        }

        public Statistic()
        {
            statID = 0;
            statVal = 0;
            statTypeID = 0;
        }



    }
}
