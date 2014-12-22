using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace fabian.iOS
{
	public class SocialItem
	{
		public string Id { get; set; }
		[JsonProperty(PropertyName = "firstname")]
		public string FirstName { get; set; }
		[JsonProperty(PropertyName = "lastname")]
		public string LastName { get; set; }
		[JsonProperty(PropertyName = "mobilephone")]
		public string MobilePhone { get; set; }
		[JsonProperty(PropertyName = "emailaddr")]
		public string EmailAddr { get; set; }
		[JsonProperty(PropertyName = "twitterhandle")]
		public string TwitterHandle { get; set; }
		[JsonProperty(PropertyName = "igname")]
		public string IGName { get; set; }
		[JsonProperty(PropertyName = "fbname")]
		public string FBName { get; set; }
	}
}
