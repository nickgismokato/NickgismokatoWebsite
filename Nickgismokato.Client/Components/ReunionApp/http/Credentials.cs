

namespace Nickgismokato.Client.Components.ReunionApp.http{
	public static class CredentialsHandler{
		private static readonly string path = "data/client_credentials.json";

		public static Credentials credentials = new Credentials();

		public static async Task SaveClientCredentials(Stream fileStream){
			try{
				File.WriteAllText(path, "test content");
			}catch(Exception ex){
				System.Console.WriteLine($"Error writing all files: {ex.Message}");
			}
			try{
				if (fileStream == null || fileStream.Length == 0){
					throw new ArgumentException("The provided file stream is empty or null.");
				}
				
				using (var file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true)){
					System.Console.WriteLine("Starting file write...");
					await fileStream.CopyToAsync(file);
					System.Console.WriteLine("File write completed.");
				}
			}catch (Exception ex){
				System.Console.WriteLine($"Error in SaveClientCredentialsAsync: {ex.Message}");
			}
		}
	}



	public class Credentials{

		public string ClientId { get; set; } = string.Empty;
		public string ClientSecret { get; set; } = string.Empty;
	}
}