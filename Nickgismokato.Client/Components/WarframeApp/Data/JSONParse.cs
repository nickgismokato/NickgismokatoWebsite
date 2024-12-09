using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

using Nickgismokato.Client.Components.WarframeApp.Logging;

namespace Nickgismokato.Client.Components.WarframeApp.Data;

static class ParseJson{

	public static void SaveObjectAsBinary(string filePath, List<Weapons> data){
		using (var stream = File.Open(filePath, FileMode.Create))
		using (var writer = new BinaryWriter(stream)){
			// Write the number of Weapons objects
			writer.Write(data.Count);

			foreach (var weapon in data){
				// Write basic weapon properties
				writer.Write(weapon.name ?? "");
				writer.Write(weapon.type ?? "");
				writer.Write(weapon.isPrime);
				writer.Write(weapon.category ?? "");
				writer.Write(weapon.masteryReq);
				writer.Write(weapon.accuracy);

				// Write Crit list
				writer.Write(weapon.crit.Count); // Number of Crit elements
				foreach (var crit in weapon.crit){
					writer.Write(crit.criticalChance);
					writer.Write(crit.criticalMultiplier);
				}

				// Write Damage list
				writer.Write(weapon.damage.Count); // Number of Damage elements
				foreach (var damage in weapon.damage){
					writer.Write(damage.damageType ?? ""); // Damage type
					writer.Write(damage.value);           // Damage value
				}
			}
		}
	}


	public static List<Weapons> ParseWeaponToObjects(string jsonContents){
		try{
			var rawWeapons = JsonSerializer.Deserialize<List<RawWeapon>>(jsonContents);
			if(rawWeapons == null){
				Exception ex = new Exception("ParseWeaponToObjects: NULL error in deserialize");
				GlobalLogger.LogException(ex);
				throw ex;
			}
			var weapons = new List<Weapons>();

			foreach (var rawWeapon in rawWeapons){
				if(rawWeapon == null){
					continue;
				}
				var weapon = new Weapons{
					name = rawWeapon.name,
					type = rawWeapon.type,
					isPrime = rawWeapon.isPrime,
					category = rawWeapon.category,
					masteryReq = rawWeapon.masteryReq,
					accuracy = rawWeapon.accuracy,
					crit = new List<Crit>{
						new Crit{
							criticalChance = rawWeapon.criticalChance,
							criticalMultiplier = rawWeapon.criticalMultiplier
						}
					},
					damage = rawWeapon.damage
						.Where(kvp => IsValidDamageType(kvp.Key)) // Filter the damage fields
						.Select(kvp => new Damage{
							damageType = kvp.Key,
							value = kvp.Value
						})
						.ToList()
				};

				weapons.Add(weapon);
			}

			return weapons;
		}catch (Exception ex){
			GlobalLogger.LogError("Exception occurred in ParseWeaponToObjects");
			GlobalLogger.LogException(ex);
			return null;
		}
	}

	private static bool IsValidDamageType(string key){
		// Add the valid damage types here (e.g., "total" to "tau")
		var validKeys = new List<string>{
			"total", "impact", "puncture", "slash", "heat", "cold", "electricity", "toxin", "blast",
			"radiation", "gas", "magnetic", "viral", "corrosive", "void", "tau"
		};
		return validKeys.Contains(key);
	}

}

