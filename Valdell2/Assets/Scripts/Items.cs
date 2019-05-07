using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{//was seeing how others used C# to implement and came up with this

	//Will need a Hero Class to impliment Equiping each of these to each heroes own inventory
	GameObject ItemObject; //mot sure if using right 
	

	public class Potion
	{
		int points { get; set; } //getter/setter
		string potionName { get; set; } //getter/setter
		
		private Potion()
		{
			//Empty Constructor
		}

		public Potion(string thePotionName, int numOfPoints)
		{
			this.potionName = thePotionName;
			this.points = numOfPoints;
			
		}

		public Potion GetPotion()
		{
			return this;
		}
	}

	public class Armor
	{
		int hitPoints { get; set; }
		string armorName { get; set; }

		private Armor()
		{
			//Empty Constructor
		}

		public Armor(string otherArmorName, int otherHitPoints)
		{
			this.armorName = otherArmorName;
			this.hitPoints = otherHitPoints;
		}

		public Armor GetArmor() // maybe not the correct way 
		{
			return this;
		}
	}

	public class Weapon
	{
		int AttackPoints { get; set; } //getter/setter
		int Durability { get; set; }
		string WeaponName { get; set; } //getter/setter

		private Weapon()
		{
			//Empty Constructor
		}

		public Weapon(string TheWeaponName, int NumOfAttackPoints, int TheDurability)
		{
			this.WeaponName = TheWeaponName;
			this.AttackPoints = NumOfAttackPoints;
			this.Durability = TheDurability;
		}
		public Weapon GetWeapon()
		{
			return this;
		}
	}

	public class Inventory //Should we make it a String Function?
	{
		public List<Items> BackPackItems;

		public Inventory() // new inventory
		{
			this.BackPackItems = new List<Items>();
		}

		public void addToInventory(Items anItem)
		{
			if (this.ItemCap())
				this.BackPackItems.Add(anItem);

			else
				System.Console.WriteLine("Inventory is Full!");
		}

		public void ItemUsed(Items anItem)
		{
			BackPackItems.Remove(anItem); //removes from backPack
		}

		public List<Items> getItems
		{
			get { return BackPackItems; }
		}

		public bool ItemCap()
		{
			return BackPackItems.Count < 4;
		}
	}

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		
    }

	
}
