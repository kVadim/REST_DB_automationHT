using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.validators
{
    public class ResultSetValidator
    {
        public static bool validate(string expectedName, DateTime expectedDate, List<Dictionary<string, object>> actualresponse)
        {
            if (actualresponse[0].Values.ElementAt(2).ToString().Equals(expectedName) )
            {
                DateTime actualDate = DateTime.Parse(actualresponse[0].Values.ElementAt(3).ToString());
                if (actualDate == expectedDate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

