using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public TextMeshProUGUI countText;
	public GameObject winTextObject;

    public Toggle EnableRemove;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);


        GameObject obj = Instantiate(InventoryItem, ItemContent);
        obj.transform.GetChild(0).GetComponent<TMP_Text>().text = item.itemName;
        obj.transform.GetChild(1).GetComponent<Image>().sprite = item.icon;
        obj.transform.GetComponent<Button>().onClick.AddListener(() => Remove(item, obj));
    }

    public void Remove(Item item, GameObject cur)
    {
        if(EnableRemove.isOn)
        {
            PlayerController.count += item.value;
            Items.Remove(item);
            Destroy(cur);
        }

        if (PlayerController.count >= 6) {
            winTextObject.SetActive(true);
        }
            
    }

    public void ListItems()
    {
        


        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }


    public void EnableItemRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else 
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }
}
