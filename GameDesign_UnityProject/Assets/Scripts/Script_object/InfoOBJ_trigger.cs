using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOBJ_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;
    public Dialogo_padre dialogue2;

    public GameObject canvas;
    public GameObject canvasDel;


    private Inventory inventory;
    private bool hasCoin = false;
    private bool hasCan = false;


    public GameObject imgUIInventarioLattinaOlio;
    public GameObject imgUIInventarioLattinaOlio_RED;
    public GameObject slot1Inventario;

    public GameObject canvasBottoni;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<Info_OBJ>().StartDialogue(dialogue);
    }
    public void TriggerDialogue2()
    {
        FindObjectOfType<Info_OBJ>().StartDialogue(dialogue2);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasCoin = inventory.listInventoryItems.Contains("ToretCoin");
            hasCan = inventory.listInventoryItems.Contains("LattinaOlio");


            if (gameObject.name == "OilVending") // stai interagendo con la macchinetta dell'olio
            {
                if (!hasCan && !hasCoin)
                {
                    // da mettere messaggio "Lattina d'olio: 1 moneta."
                    Debug.Log("Lattina d'olio: 1 moneta.");
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();     
                    }
                }
                else if (!hasCan && hasCoin) // quì hai preso già la moneta dal robot delle costruzioni
                {
                    // da mettere messaggio "Vuoi acquistare una lattina d'olio?"
                    Debug.Log("Vuoi acquistare una lattina d'olio?");
                    Debug.Log("Sì");
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                        Cursor.lockState = CursorLockMode.None;
                        canvasBottoni.SetActive(true);
                    }

                    // "SI"
                    
                    // qua mi cancella la moneta dall'inventario
                        
                    

                    // "NO"
                    // chiudi il dialogo
                }
            }


            // DA MODIFICARE DIALOGO RELATIVO A CAN ROSSA
            // DA MODIFICARE DIALOGO RELATIVO A CAN ROSSA
            // DA MODIFICARE DIALOGO RELATIVO A CAN ROSSA
            // DA MODIFICARE DIALOGO RELATIVO A CAN ROSSA
            // DA MODIFICARE DIALOGO RELATIVO A CAN ROSSA
            // usare dropitemRED
            if (gameObject.name == "OilVending_seconda") // stai interagendo con la macchinetta nella seconda piazza (can rossa)
            {
                if (!hasCan && !hasCoin)
                {
                    // da mettere messaggio "Lattina d'olio: 1 moneta."
                    Debug.Log("Lattina d'olio: 1 moneta.");
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();     
                    }
                }
                else if (!hasCan && hasCoin) // quì hai preso già la moneta dal robot delle costruzioni
                {
                    // da mettere messaggio "Vuoi acquistare una lattina d'olio?"
                    Debug.Log("Vuoi acquistare una lattina d'olio?");
                    Debug.Log("Sì");
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                        Cursor.lockState = CursorLockMode.None;
                        canvasBottoni.SetActive(true);
                    }

                    // "SI"
                    
                    // qua mi cancella la moneta dall'inventario
                        
                    

                    // "NO"
                    // chiudi il dialogo
                }
            }   
        }
    }


    public void DropItem()
    {
        foreach (Transform child in slot1Inventario.transform)
        {
            GameObject.Destroy(child.gameObject);
            inventory.isFull[0] = false;
        }
        inventory.listInventoryItems.Remove(item: "ToretCoin");
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(imgUIInventarioLattinaOlio, inventory.slots[i].transform, false);
                inventory.listInventoryItems.Add("LattinaOlio");
                Debug.Log("Ho ricevuto la lattina d'olio");
                break;
            }
        }
    }

    public void DropItemRED()
    {
        foreach (Transform child in slot1Inventario.transform)
        {
            GameObject.Destroy(child.gameObject);
            inventory.isFull[0] = false;
        }
        inventory.listInventoryItems.Remove(item: "ToretCoin");
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                Instantiate(imgUIInventarioLattinaOlio_RED, inventory.slots[i].transform, false);
                inventory.listInventoryItems.Add("LattinaOlioRED");
                Debug.Log("Ho ricevuto la lattina d'olio rossa");
                break;
            }
        }
    }

    /*hasCoin = inventory.listInventoryItems.Contains("ToretCoin");
                if(hasCoin)
                {
                    // quì hai la moneta, da mettere messaggio che dice che la cabina è rotta e di cercarne un'altra funzionante.
                }
                else
{
    // quì NON hai la moneta, da mettere messaggio che dice "per utilizzare la cabina inserisci una moneta."
}*/
}
