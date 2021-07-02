using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject imgUIInventario
    ;
    public GameObject txtPickUp;

    private bool pickAllowed = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //txtPickUp.SetActive(false);
    }

    private void Update()
    {
        if(pickAllowed && Input.GetKeyDown(KeyCode.E)) // ho premuto il tasto E
            {
                for (int i = 0 ; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false) // controllo di avere spazio nell'inventario
                    {
                        // L'item può essere raccolto
                        inventory.isFull[i] = true;
                        Instantiate(imgUIInventario, inventory.slots[i].transform, false);
                        inventory.listInventoryItems.Add(gameObject.ToString());
                        Destroy(gameObject);
                        txtPickUp.SetActive(false);
                        break;
                    }
                }
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            txtPickUp.SetActive(true); // vengo informato che per raccogliere l'oggetto devo premere E
            pickAllowed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        txtPickUp.SetActive(false);
        pickAllowed = false;
    }
}
