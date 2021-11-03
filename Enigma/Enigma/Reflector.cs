using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Reflector
    {
        public string str = "ABCDEFGDIJKGMKMIEBFTCVVJAT";
        public int Move (int x)
        {
            
            for (int i=0; i<26; i++)
                if(str[x]==str[i] && i!=x)
                {
                    x = i;
                    break;
                }
            return x;
        }
    }
}
