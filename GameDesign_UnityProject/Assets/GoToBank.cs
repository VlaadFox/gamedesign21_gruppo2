using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBank : MonoBehaviour
{
    private bool hasUSB = false;
    private Inventory inventory;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
   

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasUSB = inventory.listInventoryItems.Contains("USB");
            Debug.Log("onstay");
        }
        if (hasUSB)
        {
            Debug.Log("haiusb");
            FindObjectOfType<LevelLoader>().LoadNextLevelBank();
        }
    }
   
}
