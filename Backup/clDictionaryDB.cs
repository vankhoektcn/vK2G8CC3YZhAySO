using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    public class clDictionaryDB
    {
        public static string sGetValueLanguage(string s)
        {
            return hsLibrary.clDictionaryDB.sGetValueLanguage(s);
        }
        public static string sGetValueLanguage(string s, int n)
        {
            return hsLibrary.clDictionaryDB.sGetValueLanguage(s,n);

        }

    }
}
