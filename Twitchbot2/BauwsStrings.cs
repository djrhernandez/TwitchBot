using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitchbot2
{
    class BauwsStrings
    {
        //need to add a new string for TextAfter
        //how the fuck do I go about that???
        //idk i'm too fucking tired to think about it
        //work on in the future
        //consult David/Kyle/Wyatt/James???
        public static string TextBetween(string source, string searchToken1, string searchToken2, 
            bool firstOrLastInstance1 = true, bool firstOrLastInstance2 = true)
        {
            int iStart;
            if(firstOrLastInstance1)
            {
                iStart = source.IndexOf(searchToken1);
            }
            else
            {
                iStart = source.LastIndexOf(searchToken1);
            }
            if (iStart >= 0)
            {
                iStart += searchToken1.Length;
                int iEnd;
                if (firstOrLastInstance2)
                {
                    iEnd = source.IndexOf(searchToken2, iStart);
                }
                else
                {
                    iEnd = source.LastIndexOf(searchToken2);
                }
                if(iEnd > iStart)
                {
                    return source.Substring(iStart, iEnd - iStart);
                }
            }
            return null;
        }

    }
}
