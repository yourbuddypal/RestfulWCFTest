using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestfulWCFTest
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
	[ServiceContract]
	public interface ITestService
	{
		/*
		[OperationContract, WebInvoke(Method = "POST"
			, UriTemplate = "/GetTextFromImageStream"
			, BodyStyle = WebMessageBodyStyle.Bare
			, RequestFormat = WebMessageFormat.Json
			, ResponseFormat = WebMessageFormat.Json)]
		string GetTextFromImageStream(Stream input);

		[OperationContract, WebInvoke(Method = "POST"
			, UriTemplate = "/GetTextFromImageBuffer"
			, BodyStyle = WebMessageBodyStyle.Bare
			, RequestFormat = WebMessageFormat.Json
			, ResponseFormat = WebMessageFormat.Json)]
		string GetTextFromImageBuffer(byte[] input);
		*/

		[OperationContract, WebInvoke(Method = "POST"
			, UriTemplate = "/GetTextFromPost"
			, BodyStyle = WebMessageBodyStyle.Bare
			, RequestFormat = WebMessageFormat.Json
			, ResponseFormat = WebMessageFormat.Json)]
		string GetTextFromPost(string text);

		[OperationContract, WebInvoke(Method = "POST"
			, UriTemplate = "/GetTextFromDTO"
			, BodyStyle = WebMessageBodyStyle.Bare
			, RequestFormat = WebMessageFormat.Json
			, ResponseFormat = WebMessageFormat.Json)]
		string GetTextFromDTO(SomeDTO input);
	}
}
