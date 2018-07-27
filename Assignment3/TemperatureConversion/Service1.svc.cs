using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TemperatureConversion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int tempConvert(int cel, int temp)
        {
            // if temp is celsius
            if (cel == 1){
                double deg = temp * 1.8 + 32;
                return Convert.ToInt32(deg);
            }
            else
            {
                // take int, apply formula, (possibly) get double, convert back into int and return
                double deg = (temp - 32) / 1.8;
                return Convert.ToInt32(deg);
            }
        }
    }
}
