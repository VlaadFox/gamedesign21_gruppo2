using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButtonUse;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0 ; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // L'item può essere raccolto
                    inventory.isFull[i] = true;
                    Instantiate(itemButtonUse, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
