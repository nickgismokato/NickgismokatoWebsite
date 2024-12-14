using Nickgismokato.Client.Components.WarframeApp.Enums;
using Nickgismokato.Client.Components.WarframeApp.Logging;
using Nickgismokato.Client.Components.WarframeApp.Data;

namespace Nickgismokato.Client.Components.WarframeApp;

public static class HTTPRequest{
	public static string baseURL = "https://api.warframestat.us/";

	public static string URLParser<T>(T myEnum){
		GlobalLogger.LogInfo($"Parsing enum {typeof(T).Name}");
		if(Enum2String.EnumToString(myEnum) == "NULL"){
			return "ERROR - NULL";
		}
		return baseURL + Enum2String.EnumToString(myEnum);
	}
	public static string URLParserString(string myEnum){
		GlobalLogger.LogInfo($"Parsing enum string {myEnum}");
		return baseURL + myEnum;
	}
	
	public static void CreateDataFolder(string pathFile){
		GlobalLogger.LogInfo($"Creating data folder at {pathFile}");
		Directory.CreateDirectory(pathFile);
	}

	public static async Task GetJSONFile(bool call) {
		//fields needed
		string pathFile = "data/warframe/";
		string fileName = "";

		//Create datafolder for Warframe.
		if(!Directory.Exists(pathFile)){
			Directory.CreateDirectory(pathFile);
		}

		//Create list of all enums.
		var enumList = ListEnum.GetAllEnums();
		/*foreach(var itm in enumList){
			GlobalLogger.LogInfo(itm);
		}*/
		
		//Parse all .json data from Warframe API
		foreach(var myEnum in enumList){
			if(myEnum == "Profile"){
				continue;
			}
			fileName = myEnum + ".json";
			if(File.Exists(pathFile + fileName)){
				if(!call){
					continue;
				}
			}
			using(HttpClient client = new HttpClient()){
				try{
					HttpResponseMessage response = await client.GetAsync(URLParserString(myEnum));
					response.EnsureSuccessStatusCode();
					string content = await response.Content.ReadAsStringAsync();

					await File.WriteAllTextAsync(pathFile+fileName, content);

				}catch(HttpRequestException e){
					GlobalLogger.LogError("Error in parsing data .json in HTTPRequest.cs");
					GlobalLogger.LogError(e.Message);
				}
			}
		}
	}
	public static async Task FetchAndSaveData<T>(string jsonFileName, ItemEnum itemEnum, StaticEnum staticEnum){
		string basePath = "data/warframe/";
		string jsonFilePath = Path.Combine(basePath, $"{jsonFileName}.json");
		string binaryFilePath;
		if(itemEnum != ItemEnum.None && staticEnum != StaticEnum.None){
			GlobalLogger.LogError("Error in HTTPRequest.FetchAndSaveData.\tCannot specify both item and static enums");
			Exception ex = new Exception("Cannot specify both item and static enums");
			GlobalLogger.LogException(ex);
			throw new Exception("Cannot specify both item and static enums");
		}
		if(itemEnum != ItemEnum.None && staticEnum == StaticEnum.None){
			binaryFilePath = Path.Combine(basePath, $"{itemEnum}.bin");
		}else if(itemEnum == ItemEnum.None && staticEnum != StaticEnum.None){
			binaryFilePath = Path.Combine(basePath, $"{staticEnum}.bin");
		}else{
			GlobalLogger.LogError("Error in HTTPRequest.FetchAndSaveData.\tBoth enums are NONE.");
			throw new Exception("Both enums are NONE.");
		}

		// Ensure the directory exists
		CreateDataFolder(basePath);

		// Fetch JSON if it doesn't exist
		if (!File.Exists(jsonFilePath)){
			await GetJSONFile(true); // Force download
		}

		// Parse JSON
		string jsonContent = await File.ReadAllTextAsync(jsonFilePath);
		var parsedData = ParseJson.ParseWeaponToObjects(jsonContent); // Replace with a generic parser if needed

		// Save to binary
		FileOperations.SaveBinary(binaryFilePath, parsedData);
	}
	public static List<T> LoadData<T>(ItemEnum itemEnum, StaticEnum staticEnum){
		string binaryFilePath;

		if(itemEnum != ItemEnum.None && staticEnum != StaticEnum.None){
			GlobalLogger.LogError("Error in HTTPRequest.LoadData.\tCannot specify both item and static enums");
			Exception ex = new Exception("Cannot specify both item and static enums");
			GlobalLogger.LogException(ex);
			throw new Exception("Cannot specify both item and static enums");
		}
		if(itemEnum != ItemEnum.None && staticEnum == StaticEnum.None){
			binaryFilePath = $"data/warframe/{itemEnum}.bin";
		}else if(itemEnum == ItemEnum.None && staticEnum != StaticEnum.None){
			binaryFilePath = $"data/warframe/{staticEnum}.bin";

		}else{
			GlobalLogger.LogError("Error in HTTPRequest.LoadData.\tBoth enums are NONE.");
			throw new Exception("Both enums are NONE.");
		}

		// Load from binary
		return FileOperations.LoadBinary<T>(binaryFilePath);
	}
}