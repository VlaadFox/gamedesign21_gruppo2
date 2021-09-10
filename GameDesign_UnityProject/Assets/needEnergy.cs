using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needEnergy : MonoBehaviour
{
    public GameObject canvas;
    public GameObject structure;
    public GameObject canvasdel;
    private Inventory inventory;

    public GameObject Ordinestrutture;
    

    private bool Ch = false;
    private bool Ga = false;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

   


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.name == "Chiosco")
            {
                if (Ch)
                {
                    structure.SetActive(true);
                    Debug.Log("sbloccata");
                }
                if(!Ch)
                {
                    canvas.SetActive(true);
                    Debug.Log("bloccata");
                }

            }
            if (gameObject.name == "Garage")
            {
                Debug.Log("IN_Garage");
                if (Ga)
                {
                    structure.SetActive(true);
                    Debug.Log("sbloccata");
                }
                if (!Ga)
                {
                    Ch = inventory.listInventoryItems.Contains("secondo");
                    canvas.SetActive(true);
                    Debug.Log("bloccata");
                    if (!Ch)
                    {
                        Ordinestrutture.SetActive(true);
                        Debug.Log("faiprimailchiosco");
                    }
                }
               
            }
        }


    }
    private void OnTriggerStay(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            Ch = inventory.listInventoryItems.Contains("secondo");
            Ga = inventory.listInventoryItems.Contains("primo");

            if (gameObject.name == "Garage")
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                {

                    if (!Ga && Ch)
                    {
                        //FindObjectOfType<Energy>().checkFinal2();
                        FindObjectOfType<energy2>().checkFinal2();
                        // primo();
                    }

                }
            }
            if (gameObject.name == "Chiosco")
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                {
                    if (!Ch)
                    {

                       // FindObjectOfType<Energy>().checkFinal();
                        FindObjectOfType<energy2>().checkFinal();




                    }


                }
            }
        }
    }

    

    private void OnTriggerExit(Collider collider)
    {
        if (gameObject.name == "Chiosco")
        {
            if (Ch)
            {
                structure.SetActive(false);
                canvas.SetActive(false);
            }
            if (!Ch)
            {
                canvas.SetActive(false);
                canvasdel.SetActive(false);
            }

        }
        if (gameObject.name == "Garage")
        {
            if (Ga)
            {
                structure.SetActive(false);
                canvas.SetActive(false);
            }
            if (!Ga)
            {
                canvas.SetActive(false);
                canvasdel.SetActive(false);
            }
            if (!Ch)
            {
                Ordinestrutture.SetActive(false);
                Debug.Log("faiprimailchiosco");
            }

        }
    }
}

    

