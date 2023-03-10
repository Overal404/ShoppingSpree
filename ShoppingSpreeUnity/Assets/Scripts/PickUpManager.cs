using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public GameObject[] ingrediantObjects;

    public List<Item> Items = new List<Item>();


    // Start is called before the first frame update
    void Start()
    {
        ListGenerator();
    }

    private void ListGenerator()
    {
        for (int i = 0; i < Random.Range(3,6); i++)
        {
            int itemID = Random.Range(0, ingrediantObjects.Length - 1);
            Item newItem = ingrediantObjects[itemID].GetComponent<ItemPick>().Item;
            Items.Add(newItem);
            int randx = Random.Range(-9, 9);
            int randy = Random.Range(-9, 9);

            while (randx % 2 != 0)
            {
                randx = Random.Range(-9, 9);
            }
            while (randy % 2 != 0)
            {
                randy = Random.Range(-9, 9);
            }

            Vector3 transform = new Vector3(randx, 0.5f, randy);
            
            Instantiate(ingrediantObjects[itemID], transform, Quaternion.identity, this.gameObject.transform);
        }
    }

    public int GetCountWinValue()
    {
        int winValue = 0;

        foreach(Item item in Items)
        {
            winValue += item.value;
        }

        return winValue;
    }
}
