using System.IO;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace Nickgismokato.Client.Components.ReunionApp
{
    public class ReuniongLog
    {
        private string _credentialsFilePath = "client_credentials.json";

        // Method to handle uploading the JSON file
        public void SaveClientCredentials(Stream fileStream)
        {
            using (var file = new FileStream(_credentialsFilePath, FileMode.Create))
            {
                fileStream.CopyTo(file);
            }
        }

        // Method to process a GraphQL query
        public async Task<string> ExecuteGraphQLQuery(string endpoint, string query, string variables = null)
        {
            var client = new GraphQLHttpClient(endpoint, new NewtonsoftJsonSerializer());

            var graphQLRequest = new GraphQLHttpRequest
            {
                Query = query,
                Variables = variables != null ? Newtonsoft.Json.JsonConvert.DeserializeObject(variables) : null
            };

            var response = await client.SendQueryAsync<dynamic>(graphQLRequest);
            return response.Data.ToString();
        }
    }
}
