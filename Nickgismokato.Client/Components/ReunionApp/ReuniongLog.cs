using System.IO;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace Nickgismokato.Client.Components.ReunionApp{
    public class ReunionLog{
        private string _credentialsFilePath = "data/client_credentials.json";

        public async Task<string> GetAccessTokenAsync(string authUrl, string clientId, string clientSecret){
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


        // Method to handle uploading the JSON file
        public async Task SaveClientCredentials(Stream fileStream){
            try{
                File.WriteAllText("data/client_credentials.json", "test content");
            }catch(Exception ex){
                System.Console.WriteLine($"Error writing all files: {ex.Message}");
            }
            try{
                if (fileStream == null || fileStream.Length == 0){
                    throw new ArgumentException("The provided file stream is empty or null.");
                }
                
                using (var file = new FileStream(_credentialsFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true)){
                    System.Console.WriteLine("Starting file write...");
                    await fileStream.CopyToAsync(file);
                    System.Console.WriteLine("File write completed.");
                }
            }catch (Exception ex){
                System.Console.WriteLine($"Error in SaveClientCredentialsAsync: {ex.Message}");
            }
        }


        // Method to process a GraphQL query
        public async Task<string> ExecuteGraphQLQuery(string endpoint, string query, string variables = null, string accessToken = null){
            GraphQLHttpRequest graphQLRequest = null;
            GraphQLHttpClient client = null;
            try{
                Console.WriteLine($"GraphQL Endpoint: {endpoint}");
                Console.WriteLine($"GraphQL Query: {query}");
                Console.WriteLine($"GraphQL Variables: {variables}");
                try{
                    client = new GraphQLHttpClient(endpoint, new NewtonsoftJsonSerializer());
                }catch(Exception ex){
                    System.Console.WriteLine($"Error in ExecuteGraphQLQuery::GraphQLHttpClient: {ex.Message}");
                }
                try{
                    if (!string.IsNullOrEmpty(accessToken)){
                        client.HttpClient.DefaultRequestHeaders.Authorization =
                            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    }
                }catch(Exception ex){
                    System.Console.WriteLine($"Error in ExecuteGraphQLQuery::AuthenticationHeader: {ex.Message}");
                }

                try{
                    graphQLRequest = new GraphQLHttpRequest{
                    Query = query,
                    Variables = variables != null ? Newtonsoft.Json.JsonConvert.DeserializeObject(variables) : null
                };
                }catch(Exception ex){
                    System.Console.WriteLine($"Error in ExecuteGraphQLQuery::DeserializeObject<Variables>: {ex.Message}");
                }
                try{
                    
                    var response = await client.SendQueryAsync<dynamic>(graphQLRequest);
                    if (response.Errors != null){
                        foreach (var error in response.Errors)
                        {
                            System.Console.WriteLine($"GraphQL Error: {error.Message}");
                        }
                    }
                    System.Console.WriteLine(response.Data.ToString());
                    return response.Data?.ToString() ?? "No data";
                }catch(Exception ex){
                    System.Console.WriteLine($"Error in ExecuteGraphQLQuery::Response: {ex.Message}");
                    return "Error";
                }
                
            }catch(Exception ex){
                System.Console.WriteLine($"Error in ExecuteGraphQLQuery: {ex.Message}");
                return "Error";
            }
        }

    }
}
