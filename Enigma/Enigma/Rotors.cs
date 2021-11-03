using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Rotors
    {
        string Alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public char[] str;
        public int a;
        // a - номер начала str относительно A (от 0 до 25)
        //x - номер исходной буквы относительно A (от 0 до 25)
        // буква проходет через ротор справа налево в прямом направлении
        public int Right (int x)
        {
            char m;
            if (x + a <= 25)
                m = str[a + x];
            else m = str[ x + a-26];
            for (int i=0; i<=25;i++)
            {
                   if (m== Alph[i])
                   {
                        if (Convert.ToInt32(m) >= a + Convert.ToInt32('A')) 
                               x = Convert.ToInt32(m) - (a + Convert.ToInt32('A'));
                        else x = 26 + Convert.ToInt32(m) - (a + Convert.ToInt32('A'));
                        break;
                   }
            }            
            return x;
        }

        public int Back (int x)
        {
            char m;
            if (x + a <= 25)
                m = Convert.ToChar(Convert.ToInt32('A') + a + x);
            else m = Convert.ToChar(Convert.ToInt32('A') + a + x - 26);
            //m = str[Convert.ToInt32(m) - Convert.ToInt32('A')];
            for (int i = 0; i < 26; i++)
            {
                if (m == str[i])
                {
                    if (i >= a)
                        x = i - a;
                    else x = 25-a+i+1;
                    break;
                }
            }
            return x;
        }
    }
}
