using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenGenerator.Helpers
{
    public class DateTimehelper
    {
        public DateTimeOffset? GetLocalTime(DateTimeOffset? utcString)
        {
            if (utcString == null)
                return null;

            return utcString.Value.ToLocalTime();
        }
    }
}
