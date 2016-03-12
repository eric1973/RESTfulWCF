using ServiceLayer.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestfulService
    {

        [OperationContract]
        [WebInvoke(
            Method = "GET", 
            BodyStyle = WebMessageBodyStyle.Bare, 
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "Data/{value}")]
        List<CompositeType> GetJsonData(string value);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Xml,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "xml/Data/{value}")]
        List<CompositeType> GetXmlData(string value);

        [OperationContract]
        [WebInvoke(
            Method = "PUT", 
            BodyStyle = WebMessageBodyStyle.Bare, 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json, 
            UriTemplate = "AddData/")]
        CompositeType AddData(CompositeType composite);

        [OperationContract]
        [WebInvoke(
            Method = "DELETE",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "DeleteData/{id}")]
        bool DeleteData(string id);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "UpdateData/{id}")]
        bool UpdateData(string id, CompositeType composite);
    }
}
