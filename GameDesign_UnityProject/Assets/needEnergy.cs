using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needEnergy : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvasdel;
    private Inventory inventory;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);


    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.name == "Garage")
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
            {


                FindObjectOfType<Energy>().checkFinal();
                primo();


            }
        }
        if (gameObject.name == "Chiosco")
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
            {


                FindObjectOfType<Energy>().checkFinal();
                secondo();


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        canvasdel.SetActive(false);
    }
    public void primo()
    {

        inventory.listInventoryItems.Add("primo");
        Debug.Log("primo fatto");

    }
    public void secondo()
    {

        inventory.listInventoryItems.Add("secondo");
        Debug.Log("secondo fatto");

    }
}
