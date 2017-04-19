using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfile.Framework.Util.String
{
    public static class StringExtension
    {
        public static string GetNumericChars(this string text)
        {
            int num = 0;
            string onlyNumbers = string.Empty;

            for (var i = 0; i < text.Length; i++)
                if (int.TryParse(text[i].ToString(), out num))
                    onlyNumbers = string.Concat(onlyNumbers, text[i]);

            return onlyNumbers;
        }
    }
}
