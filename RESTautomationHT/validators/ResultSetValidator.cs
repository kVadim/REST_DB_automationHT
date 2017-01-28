using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.validators
{
    public class ResultSetValidator
    {
    }
}

//public ResultSetValidator() {
//    }

//    public static boolean validate(String ExpectedName, String ExpectedDate, List<Map<String, Object>> ActualResponse) throws IOException {
//        Iterator var3 = ActualResponse.iterator();

//        Map row;
//        do {
//            if(!var3.hasNext()) {
//                return true;
//            }

//            row = (Map)var3.next();
//            if(!row.get("NAME").toString().equalsIgnoreCase(ExpectedName)) {
//                return false;
//            }
//        } while(row.get("DATE").toString().equalsIgnoreCase(ExpectedDate));

//        return false;
//    }