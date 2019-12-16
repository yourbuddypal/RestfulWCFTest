using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace RestfulWCFTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string address = "http://localhost:8082/RestfulWCFTest";

			using (ServiceHost host = new ServiceHost(typeof(TestService), new Uri(address)))
			{
				var binding = new WebHttpBinding(WebHttpSecurityMode.None);
				binding.TransferMode = TransferMode.Buffered;

				ServiceEndpoint restEndpoint = new ServiceEndpoint(
					ContractDescription.GetContract(typeof(ITestService)),
					binding,
					new EndpointAddress(address)
				);

				restEndpoint.EndpointBehaviors.Add(new System.ServiceModel.Description.WebHttpBehavior());

				bool mex = true;
				if (mex)
				{
					ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
					smb.HttpGetEnabled = true;
					host.Description.Behaviors.Add(smb);
				}

				host.AddServiceEndpoint(restEndpoint);

				host.Open();

				System.Threading.Thread thread = new System.Threading.Thread(sendRequest);
				thread.Start(address);

				Console.WriteLine($"Recognizer Service running at {address}.\nPress any key to stop...");
				Console.ReadKey(true);
				host.Close();
			}
		}

		public static void sendRequest(object address)
		{
			WebHttpBinding theBinding = new WebHttpBinding()
			{
				TransferMode = TransferMode.Buffered,
			};
		
			EndpointAddress epAddr = new EndpointAddress((string)address);

			using (TestServiceReference.TestServiceClient client = new TestServiceReference.TestServiceClient(theBinding, epAddr))
			{
				client.Endpoint.EndpointBehaviors.Add(new System.ServiceModel.Description.WebHttpBehavior());
				string output = client.GetTextFromDTO(new TestServiceReference.SomeDTO() { Text = "Yo" });
				Console.WriteLine(output);
			}
		}
	}
}
