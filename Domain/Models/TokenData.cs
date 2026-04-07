using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenGenerator.Domain.Models
{
    public class TokenData
    {
        public string Token { get; }
        public DateTimeOffset ExpiresOn { get; }

        public TokenData(string token, DateTimeOffset expiresOn)
        {
            Token = token;
            ExpiresOn = expiresOn;
        }
    }
}
