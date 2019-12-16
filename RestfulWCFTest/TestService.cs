using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestfulWCFTest
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in both code and config file together.
	public class TestService : ITestService
	{
		public string GetTextFromPost(string text)
		{
			return $"You input: '{text}'";
		}

		public string GetTextFromDTO(SomeDTO input)
		{
			return $"You input: '{input.Text}'";
		}
	}
}
