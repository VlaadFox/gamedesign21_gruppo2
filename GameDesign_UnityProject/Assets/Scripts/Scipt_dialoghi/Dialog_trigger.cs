using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;
    public Dialogo_padre dialogue2;
    public Dialogo_padre dialogue3;

    public GameObject canvas;
    public GameObject canvasDel;


    private Inventory inventory;

    private InventorySlot inventorySlot;

    private bool hasCoin = false; // per controllare moneta
    private bool hasCan = false; // per controllare lattina

    public GameObject imgUIInventarioMoneta;

    public GameObject slot1Inventario;

    public GameObject imgUIInventarioLattinaOlio;

    public GameObject canvasBottoni;

    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    /*private void Update()
    {
        if (slot1Inventario.transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }*/

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialogue);
    }


    public void TriggerDialogue2()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialogue2);
    }
    public void TriggerDialogue3()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialogue3);
    }



    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
            




                hasCoin = inventory.listInventoryItems.Contains("ToretCoin");
                hasCan = inventory.listInventoryItems.Contains("LattinaOlio");
                //hasCan = true;
                
                if(gameObject.name == "RobotLavori") // stai parlando col robot
                {
                    if(!hasCan) // entra nel ciclo in cui NON ha ancora la lattina d'olio
                    {
                        if (hasCoin)
                        {
                            // quì ti ha già dato la moneta, da mettere messaggio che dice "Fai presto perfavore!"
                            Debug.Log("Hai già la moneta");
                            Debug.Log("Fai presto perfavore!");
                            if (Input.GetKeyDown(KeyCode.R))
                            {
                                canvasDel.SetActive(false);
                                canvas.SetActive(true);
                                TriggerDialogue2();
                            }
                        }
                        else
                        {


                            // quì ancora NON hai la moneta, ti chiede "Ciao, mi servirebbe una lattina d'olio per recuperare energie, ti andrebbe di aiutarmi?"
                            // quindi da gestire domanda con possibilità di rispondere sì o no
                            //Debug.Log("Ciao, mi servirebbe una lattina d'olio per recuperare energie, ti andrebbe di aiutarmi?");
                            //Debug.Log("Sì");
                            if (Input.GetKeyDown(KeyCode.R))
                            {
                                canvasDel.SetActive(false);
                                canvas.SetActive(true);
                                TriggerDialogue();
                                Cursor.lockState = CursorLockMode.None;
                                canvasBottoni.SetActive(true);
                            }

                            // "SI"
                            // messaggio ""Ti ringrazio! Eccoti una moneta, cerca una macchinetta dove vendono lattine d'olio." + codice sotto tra graffe
                            /* public void Getcoin()
                             {
                                 for (int i = 0 ; i < inventory.slots.Length; i++)
                                 {
                                     if (inventory.isFull[i] == false) // controllo di avere spazio nell'inventario
                                     {
                                         inventory.isFull[i] = true;
                                         Instantiate(imgUIInventarioMoneta, inventory.slots[i].transform, false);
                                         inventory.listInventoryItems.Add("ToretCoin");
                                         Debug.Log("Ho ricevuto la moneta");
                                         break;
                                     }
                                 }
                             }*/

                            // "NO"
                            // chiudiamo semplicemente il dialogo col robot o gli dice qualcosa?
                        }
                    }
                    else // quì hai già comprato la lattina d'olio
                    {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue3();
                        DropItem(); // mi droppa il primo elemento nell'inventario qualsiasi esso sia, in questo caso deve essere la lattina d'olio per logica
                        inventory.listInventoryItems.Remove(item: "LattinaOlio");
                        inventory.listInventoryItems.Add("CollezionabileOlio");
                        Debug.Log("Ce l'hai fatta! Grazie mille, eccoti una ricompensa.");
                    }
                    // da mettere messaggio "Ce l'hai fatta! Grazie mille, eccoti una ricompensa."
                    
                       
                        // quì ci va poi il codice col "for" per aggiungere il collezionabile che scegliamo all'inventario ma una volta che lo decidiamo lo implemento io
                    }
                }
                else if (gameObject.name == "OilVending") // stai interagendo con la macchinetta dell'olio
                {
                    if(!hasCan && !hasCoin)
                    {
                        // da mettere messaggio "Lattina d'olio: 1 moneta."
                        Debug.Log("Lattina d'olio: 1 moneta.");
                    }   
                    else if(!hasCan && hasCoin) // quì hai preso già la moneta dal robot delle costruzioni
                    {
                        // da mettere messaggio "Vuoi acquistare una lattina d'olio?"
                        Debug.Log("Vuoi acquistare una lattina d'olio?");
                        Debug.Log("Sì");

                        // "SI"
                        {
                            DropItem(); // qua mi cancella la moneta dall'inventario
                            inventory.listInventoryItems.Remove(item: "ToretCoin");
                            for (int i = 0 ; i < inventory.slots.Length; i++)
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
    }

    public void Getcoin()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false) // controllo di avere spazio nell'inventario
            {
                inventory.isFull[i] = true;
                Instantiate(imgUIInventarioMoneta, inventory.slots[i].transform, false);
                inventory.listInventoryItems.Add("ToretCoin");
                Debug.Log("Ho ricevuto la moneta");
                break;
            }
        }
    }
}

// ancora da mettere imgLattinaOlio dopo averla creata e piazzata in scena (nascosta da qualche parte)