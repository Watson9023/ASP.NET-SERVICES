using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StoreLocator
{
    [ServiceContract]
    public interface IService1
    {
        // contract for service
        [OperationContract]
        string findNearestStore(string zipcode, string storeName);
    }
}
