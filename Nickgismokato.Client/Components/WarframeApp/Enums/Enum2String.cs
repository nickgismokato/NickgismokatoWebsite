namespace Nickgismokato.Client.Components.WarframeApp.Enums{
	public static class Enum2String{
        public static string EnumToString<T>(T myEnum){
			switch(myEnum){
				case PlatformEnum.PC:
					return "pc";
				case PlatformEnum.PS4:
					return "ps4";
				case PlatformEnum.SWI:
					return "swi";
				case PlatformEnum.XboxOne:
					return "xb1";

				case ItemEnum.Items:
					return "items";
				case ItemEnum.Mods:
					return "mods";
				case ItemEnum.Weapons:
					return "weapons";
				case ItemEnum.Warframes:
					return "warframes";
				case ProfileEnum.Profile:
					return "profile";
				
				case StaticEnum.Arcanes:
					return "arcanes";
				case StaticEnum.Conclave:
					return "conclave";
				case StaticEnum.Events:
					return "events";
				case StaticEnum.Factions:
					return "factions";
				case StaticEnum.FissureModifiers:
					return "fissureModifiers";
				case StaticEnum.Languages:
					return "languages";
				case StaticEnum.Locales:
					return "locales";
				case StaticEnum.MissionTypes:
					return "missionTypes";
				case StaticEnum.OperationTypes:
					return "operationTypes";
				case StaticEnum.PersistentEnemy:
					return "persistentEnemy";
				case StaticEnum.SolNodes:
					return "solNodes";
				case StaticEnum.Sortie:
					return "sortie";
				case StaticEnum.Syndicates:
					return "syndicates";
				case StaticEnum.Tutorials:
					return "tutorials";
				case StaticEnum.UpgradeTypes:
					return "upgradeTypes";
				default:
					return "NULL";
			}
		}
	}
}