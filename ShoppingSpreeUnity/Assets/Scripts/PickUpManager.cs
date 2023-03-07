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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ListGenerator()
    {
        for (int i = 0; i < Random.Range(3,6); i++)
        {
            int itemID = Random.Range(0, ingrediantObjects.Length - 1);
            Item newItem = ingrediantObjects[itemID].GetComponent<ItemPick>().Item;
            Items.Add(newItem);
            int randx = Random.Range(-10, 10);
            int randy = Random.Range(-10, 10);
            Vector3 transform = new Vector3(randx, 0.5f, randy);
            
            Instantiate(ingrediantObjects[itemID], transform, Quaternion.identity);
        }
    }
}
