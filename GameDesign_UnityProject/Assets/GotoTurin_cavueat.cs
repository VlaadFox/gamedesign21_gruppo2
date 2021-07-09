using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoTurin_cavueat : MonoBehaviour
{
    private bool hasmoney = false;
    private Inventory inventory;

    public GameObject canvas;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetMoney();
        canvas.SetActive(true);
    }


    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
    }


    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasmoney = inventory.listInventoryItems.Contains("money");
            if (hasmoney) 
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
                }
            }
           
        }
    }
    public void GetMoney()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false) // controllo di avere spazio nell'inventario
            {
                inventory.isFull[i] = true;
                inventory.listInventoryItems.Add("money");
                Debug.Log("caveau");
                break;
            }
        }
    }
}
