using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    public GameObject emptyTexts;
    public GameObject txtInfoSfera;
    public GameObject txtInfoCartello;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) // mi serve per dichiarare che un determinato slot sia vuoto in modo da poter pickare oggetti dentro
        {
            inventory.isFull[i] = false;
        }
    }

    /*public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }*/

    public void InfoItem()
    {
        foreach (Transform child in transform)
        {
            //child.GetComponent<Spawn>().GetInfoItem();
            
            switch (child.GetComponent<Spawn>().item.name)
            {
                case "spPickUpDrop":
                    Debug.Log("Questa è una sfera");
                    emptyTexts.SetActive(true);
                    txtInfoSfera.SetActive(true);
                    txtInfoCartello.SetActive(false);
                    break;
                case "CartelloV1.2":
                    Debug.Log("Questo è un cartello");
                    emptyTexts.SetActive(true);
                    txtInfoSfera.SetActive(false);
                    txtInfoCartello.SetActive(true);
                    break;
                default:
                    Debug.Log("Seleziona un oggetto");
                    break;
            }
        }
    }
}
