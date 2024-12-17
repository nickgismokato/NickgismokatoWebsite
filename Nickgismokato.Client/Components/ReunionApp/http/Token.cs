using System;
using System.IO;
using System.Globalization;

using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;



namespace Nickgismokato.Client.Components.ReunionApp.http{
	public static class Token{
		public static string accessToken { get; set; } = string.Empty;
		public static string tokenType { get; set; } = string.Empty;
		public static int expires { get; set; } = -1;
		public static DateTime expiresDatetime { get; set; }
		public static DateTime timeCollected { get; set; }

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
				if(response.StatusCode != System.Net.HttpStatusCode.OK){
					System.Console.WriteLine("Response Content: " + await response.Content.ReadAsStringAsync());
				}

				response.EnsureSuccessStatusCode();

				var jsonResponse = await response.Content.ReadAsStringAsync();
				dynamic parsedResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

				accessToken = parsedResponse.access_token;
				tokenType = parsedResponse.token_type;
				expires = parsedResponse.expires_in;
				UpdateTime();
				return parsedResponse.access_token;
			}catch(Exception ex){
				System.Console.WriteLine($"Error in GetAccessTokenAsync: {ex.Message}");
				return "";
			}
		}

		public static bool Expired(){
			try{
				if(DateTime.Now > timeCollected.Date.AddDays(1)){
					return true;
				}
				return DateTime.Now > expiresDatetime;
			}catch(Exception ex){
				System.Console.WriteLine($"Token::Expired: {ex.Message}");
				return false;
			}
		}

		public static void UpdateTime(){
			DateTime now = DateTime.Now;
			expiresDatetime = now.AddSeconds(expires);
			timeCollected = DateTime.Now;
			//Debug
			System.Console.WriteLine($"Access token expires at: {expiresDatetime.ToString("dddd, MMMM dd, yyyy h:mm:ss tt", new CultureInfo("da-DK"))}");
		}
	}
}