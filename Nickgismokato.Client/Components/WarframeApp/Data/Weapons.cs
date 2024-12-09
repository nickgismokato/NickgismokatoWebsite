using System;
using System.Collections.Generic;

namespace Nickgismokato.Client.Components.WarframeApp.Data;

public class Weapons{
	//Fields
	public string name {get; set;}
	public string type {get; set;}
	public bool isPrime {get; set;}
	public string category {get; set;}
	public int masteryReq {get; set;}
	public double accuracy {get; set;}
	public List<Damage> damage {get; set;}
	public List<Crit> crit {get; set;}
	public double statusChance {get; set;}
	public double multiShot {get; set;}
	public string url {get; set;}

	//Constuctor
	public Weapons(){
		
	}
}

public class Crit{
	public double criticalChance {get; set;}
	public double criticalMultiplier {get; set;}
}
public class Damage{
	public string damageType {get; set;}
	public double value {get; set;}
}




public class RawWeapon{
    public string name { get; set; }
    public string type { get; set; }
    public bool isPrime { get; set; }
    public string category { get; set; }
    public int masteryReq { get; set; }
    public double accuracy { get; set; }
    public double criticalChance { get; set; }
    public double criticalMultiplier { get; set; }
    public Dictionary<string, double> damage { get; set; }
}
