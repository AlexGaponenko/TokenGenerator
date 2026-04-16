using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenGenerator.Helpers
{
    internal class StringHelper
    {
        internal string MaskToken(string? token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return "";

            return $"{token.Substring(0, 10)}***********{token.Substring(token.Length - 4)}";
        }
    }
}
