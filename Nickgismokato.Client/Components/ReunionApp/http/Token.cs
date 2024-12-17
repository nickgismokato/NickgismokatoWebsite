using System;
using System.IO;


using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;



namespace Nickgismokato.Client.Components.ReunionApp.http{
	public class Token{
		public string accessToken { get; set; } = string.Empty;
		public string tokenType { get; set; } = string.Empty;
		public int expires { get; set; }
		
		public static async Task<string> GetAccessTokenAsync(string authUrl, string clientId, string clientSecret){
			try{
				var client = new HttpClient();
				var data = new Dictionary<string, string>{
					{ "grant_type", "client_credentials" },
					{ "client_id", clientId },
					{ "client_secret", clientSecret }
				};

				var content = new FormUrlEncodedContent(data);
				var response = await client.PostAsync(authUrl, content);

				// Debugging logs
				System.Console.WriteLine("Response Status Code: " + response.StatusCode);
				System.Console.WriteLine("Response Content: " + await response.Content.ReadAsStringAsync());

				response.EnsureSuccessStatusCode();

				var jsonResponse = await response.Content.ReadAsStringAsync();
				dynamic parsedResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

				return parsedResponse.access_token;
			}catch(Exception ex){
				System.Console.WriteLine($"Error in GetAccessTokenAsync: {ex.Message}");
				return "";
			}
		}
	}
}