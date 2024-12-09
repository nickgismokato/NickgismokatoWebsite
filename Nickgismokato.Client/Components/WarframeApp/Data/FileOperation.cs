using System.Text.Json;
using System.IO;

namespace Nickgismokato.Client.Components.WarframeApp.Data;
public static class FileOperations{
	private static readonly string BackupFolder = "data/warframe/backups/";

	static FileOperations(){
		Directory.CreateDirectory(BackupFolder); // Ensure backup directory exists
	}

	// Generic save method
	public static void SaveBinary<T>(string filePath, List<T> data){
		using (var stream = File.Open(filePath, FileMode.Create))
		using (var writer = new BinaryWriter(stream)){
			writer.Write(data.Count);
			foreach (var item in data){
				var json = JsonSerializer.Serialize(item);
				writer.Write(json);
			}
		}
	}

	// Generic load method
	public static List<T> LoadBinary<T>(string filePath){
		if (!File.Exists(filePath)){
			throw new FileNotFoundException($"Binary file not found: {filePath}");
		}

		using (var stream = File.Open(filePath, FileMode.Open))
		using (var reader = new BinaryReader(stream)){
			int count = reader.ReadInt32();
			var data = new List<T>();

			for (int i = 0; i < count; i++){
				var json = reader.ReadString();
				data.Add(JsonSerializer.Deserialize<T>(json));
			}

			return data;
		}
	}

	public static void CreateHourlyBackup(string originalFilePath){
		string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
		string backupPath = Path.Combine(BackupFolder, $"Backup_{timestamp}.bin");

		File.Copy(originalFilePath, backupPath, overwrite: true);
	}
}