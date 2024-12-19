using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;


namespace Nickgismokato.Client.Components.ReunionApp.http{
	public static class QueryGQL {
		private static string graphqlEndpoint = "https://www.warcraftlogs.com/api/v2/client"
		private static string _credentialsFilePath = "data/client_credentials.json";
		
		public static async Task<string> SendQueryGQL(string query, string variables){
			Authenticate();
			return "";
		}

		private static bool CheckGQLQuery(string query){

			return true;
		}

		private static bool CheckQGLVariables(string variables){

			return true;
		}

		private static void Authenticate(){
			if(!File.Exists(_credentialsFilePath)){
				System.Console.WriteLine("Credentials file not found.");
				throw new Exception("ERROR <QueryGQL:Authenticate>: Credentials file not found.");
			}

		}
	}
}