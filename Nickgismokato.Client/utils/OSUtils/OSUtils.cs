
namespace Nickgismokato.Client.utils.OSUtils{
	public static class OSUtils{
		public static string GetOS(){
			return System.Runtime.InteropServices.RuntimeInformation.OSDescription;
		}


		public static bool CheckIfDirectoryExists(string path){
			return System.IO.Directory.Exists(path);
		}

		public static void CreateDirectory(string path){
			System.IO.Directory.CreateDirectory(path);
		}
	}
}