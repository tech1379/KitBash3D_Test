using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeTest
{
    class Tests
    {
        public string test1 { get; set; }
        public string test2 { get; set; }

        public string test3 { get; set; }

        public string test4 { get; set; }

        public Tests()
        {
            for (int i = 0; i <= 100; i++)
            {
                test1 += "The quick Brown Fox jumped ";
            }
            test1 += "jumped: " + "https://twitter.com/POTUS/status/1482425359333212163" + " @POTUS";

            test2 = "the quick brown fox jumped Last: https://twitter.com/POTUS/status/1483114985538658312 @POTUS";

            test3 = "The QUICK BROWn FOX JUMPED: https://twitter.com/MichelleObama @FLOTUS";

            test4 = "the quick brown fox jumped: https://twitter.com/MichelleObama @FLOTUS";
        }
    }
}
