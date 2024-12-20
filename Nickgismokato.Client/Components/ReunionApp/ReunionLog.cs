using System;
using System.IO;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

using Nickgismokato.Client.Components.ReunionApp.http;

namespace Nickgismokato.Client.Components.ReunionApp{
    public class ReunionLog{
        private string _credentialsFilePath = "data/client_credentials.json";

        public async Task<string> GetAccessToken(string authUrl, string clientId, string clientSecret){
            try{
                if(Token.Expired()){
                    await Token.GetAccessTokenAsync(authUrl, clientId, clientSecret);
                }
                return Token.accessToken;
            }catch(Exception ex){
                System.Console.WriteLine($"Error in GetAccessTokenAsync: {ex.Message}");
                return "";
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
                        foreach (var error in response.Errors){
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
