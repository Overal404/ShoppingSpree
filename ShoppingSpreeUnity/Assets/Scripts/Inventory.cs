// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// // Include the namespace required to use Unity UI and Input System
// using UnityEngine.InputSystem;
// using TMPro;

// public class Inventory {
	
// 	private List<Item> itemList;

// 	public Inventory() {
// 		itemList = new List<Item>();
// 		Debug.Log("Inventory");

// 		AddItem(new Item {itemType = Item.ItemType.Sword, amount = 1});
// 		AddItem(new Item {itemType = Item.ItemType.HealthPotion, amount = 1});
// 		AddItem(new Item {itemType = Item.ItemType.ManaPotion, amount = 1});

// 		Debug.Log(itemList.Count);
		
// 	}

// 	public void AddItem(Item item) {
// 		itemList.Add(item);
// 		// if (item.IsStackable()) {
// 		// 	bool itemAlreadyInInventory = false;
// 		// 	foreach (Item inventoryItem in itemList) {
// 		// 		if( inventoryItem.itemType == item.itemType) {
// 		// 			inventoryItem.amount += item.amount;
// 		// 			itemAlreadyInInventory = true;
// 		// 		}
// 		// 	}
// 		// }
// 	}

// 	public List<Item> GetItemList() {
// 		return itemList;
// 	}
// }