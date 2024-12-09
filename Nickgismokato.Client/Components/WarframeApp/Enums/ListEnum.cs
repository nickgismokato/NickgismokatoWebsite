using System;
using System.Collections.Generic;
using System.Linq;

namespace Nickgismokato.Client.Components.WarframeApp.Enums;

public static class ListEnum{
	public static IEnumerable<string> GetAllEnums(){
		var staticEnumValues = Enum.GetValues(typeof(StaticEnum)).Cast<StaticEnum>().Where(e=> e != StaticEnum.None).Select(e => e.ToString());
		//var profileEnumValues = Enum.GetValues(typeof(ProfileEnum)).Cast<ProfileEnum>().Where(e => e != ProfileEnum.None).Select(e => e.ToString());
		var itemEnumValues = Enum.GetValues(typeof(ItemEnum)).Cast<ItemEnum>().Where(e => e != ItemEnum.None).Select(e => e.ToString());

		return staticEnumValues.Concat(itemEnumValues);
	}
}