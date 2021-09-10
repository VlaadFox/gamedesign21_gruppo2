using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findgo : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject muro;
    private Inventory inventory;
    private bool hasenter=false;
    private void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        hasenter = inventory.listInventoryItems.Contains("entrato");
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (hasenter)
        {
            canvas1.SetActive(true);
            muro.SetActive(false);

        }
        if(!hasenter)
        {
            canvas2.SetActive(true);


        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (hasenter)
        {
            canvas1.SetActive(false);
           
        }
        if (!hasenter)
        {
            canvas2.SetActive(false);

        }
    }
}
