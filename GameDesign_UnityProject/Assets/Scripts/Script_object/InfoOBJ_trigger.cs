using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoOBJ_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;
    public Dialogo_padre dialogue2;
    public Dialogo_padre dialogue3;

    public GameObject canvas;
    public GameObject canvasDel;


    private Inventory inventory;

    private bool hasCoin = false;
    private bool hasCan = false;


    public GameObject imgUIInventarioLattinaOlio;
    public GameObject imgUIInventarioLattinaOlio_RED;

    //stai attento potrebbe non esse un Gameonject
    public GameObject slot1Inventario;

    public GameObject canvasBottoni;

    public GameObject yesFirstButton;
    public GameObject playerController;

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
    public void TriggerDialogue3()
    {
        FindObjectOfType<Info_OBJ>().StartDialogue(dialogue3);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasCoin = inventory.listInventoryItems.Contains("ToretCoin");
            hasCan = inventory.listInventoryItems.Contains("LattinaOlio");
            Debug.Log("entro collider");





            if (gameObject.name == "OilVending") // stai interagendo con la macchinetta dell'olio
            {
                Debug.Log("oliomacchina");
                if (!hasCan && !hasCoin)
                {
                    // da mettere messaggio "Lattina d'olio: 1 moneta."
                   
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                            Debug.Log("Lattina d'olio: 1 moneta.");
                    }
                }
                else if (!hasCan && hasCoin) // quì hai preso già la moneta dal robot delle costruzioni
                {
                    // da mettere messaggio "Vuoi acquistare una lattina d'olio?"
                    Debug.Log("Vuoi acquistare una lattina d'olio?");
                    Debug.Log("Sì");
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        playerController.GetComponent<CharacterController>().enabled = false;
                        Time.timeScale = 0f;
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                        Cursor.lockState = CursorLockMode.None;
                        canvasBottoni.SetActive(true);

                        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                        EventSystem.current.SetSelectedGameObject(null);
                        // ora posso selezionare in oggetto
                        EventSystem.current.SetSelectedGameObject(yesFirstButton);
                    }
                    else 
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
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
                        playerController.GetComponent<CharacterController>().enabled = false;
                        Time.timeScale = 0f;
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                        Cursor.lockState = CursorLockMode.None;
                        canvasBottoni.SetActive(true);
                        EventSystem.current.SetSelectedGameObject(null);
                        // ora posso selezionare in oggetto
                        EventSystem.current.SetSelectedGameObject(yesFirstButton);
                    }

                    // "SI"
                    
                    // qua mi cancella la moneta dall'inventario
                        
                    

                    // "NO"
                    // chiudi il dialogo
                }
            }   

            if(gameObject.name == "CabinaTel")
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    canvasDel.SetActive(false);
                    canvas.SetActive(true);
                    TriggerDialogue();
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
