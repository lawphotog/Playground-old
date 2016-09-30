using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication1.Models
{
    class CustomerRepository
    {
        internal bool IsNameUnique(object value)
        {
            if (value.ToString().Trim().ToLower() == "tom")
                return false;

            return true;
        }

        internal bool MustLiveInNewcastle(object value)
        {
            if (value.ToString().Trim().ToLower() == "newcastle")
                return true;

            return false;
        }
    }
}
