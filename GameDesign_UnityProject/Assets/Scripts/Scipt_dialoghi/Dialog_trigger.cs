using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;
    public Dialogo_padre dialogue2;
    public Dialogo_padre dialogue3;
    public Dialogo_padre dialogue4;

    public GameObject canvas;
    public GameObject canvasDel;
    public GameObject continue_button;

    public Animator anim;

    private Inventory inventory;

    private InventorySlot inventorySlot;

    private bool hasCoin = false; // per controllare moneta
    private bool hasCan = false; // per controllare lattina
    private bool hasUSB = false;
    private bool hasenter = false;

    public GameObject imgUIInventarioMoneta;

    public GameObject slot1Inventario;

    

    public GameObject canvasBottoni;

    private int j ;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        anim = GetComponent<Animator>();

    }

    /*private void Update()
    {
        if (slot1Inventario.transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }*/

    public void Nextdisplay()
    {
        FindObjectOfType<Dialog_manager>().DisplayNextSentence();
    }

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
    public void TriggerDialogue4()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialogue4);
    }


    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
                hasCoin = inventory.listInventoryItems.Contains("ToretCoin");
                hasCan = inventory.listInventoryItems.Contains("LattinaOlio");
                hasUSB = inventory.listInventoryItems.Contains("USB");
                hasenter = inventory.listInventoryItems.Contains("entrato");







            if (gameObject.name == "robotLavori") // stai parlando col robot
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
                                anim.SetBool("talkBool", true);
                                anim.SetBool("pauseBool", false);
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
                                anim.SetBool("talkBool", true);
                                anim.SetBool("pauseBool", false);
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
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue3();
                            DropItem(); // mi droppa il primo elemento nell'inventario qualsiasi esso sia, in questo caso deve essere la lattina d'olio per logica
                            GetCollezionabile();
                            inventory.listInventoryItems.Remove(item: "LattinaOlio");
                            continue_button.SetActive(true);

                        Debug.Log("Ce l'hai fatta! Grazie mille, eccoti una ricompensa.");
                        }
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        Nextdisplay();
                        continue_button.SetActive(false);
                        GetCollezionabile();
                    }
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                    }
                }





            if(gameObject.name == "RobotLucee")
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        {
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                        }

                }






            if (gameObject.name == "Robottone")
                {
                    if (Input.GetKeyDown(KeyCode.R))
                        {
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                            continue_button.SetActive(true);
                }
                   if (Input.GetKeyDown(KeyCode.C))
                    {
                       Nextdisplay();
                       continue_button.SetActive(false);
                }
                }



            if (gameObject.name == "robotLadro")
            {
                if (!hasUSB)
                {
                   
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                            continue_button.SetActive(true);
                    }
                        if (Input.GetKeyDown(KeyCode.C))
                        {
                            Nextdisplay();
                            Cursor.lockState = CursorLockMode.None;
                            canvasBottoni.SetActive(true);
                            continue_button.SetActive(false);
                    }
                }
                if (hasUSB)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                    }
                }
            }

            if (gameObject.name == "robotRotto")
            {
                if (j == 0)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
                        continue_button.SetActive(true); Debug.Log("1");
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        Nextdisplay();
                        continue_button.SetActive(false); Debug.Log("1.2");
                        j++;
                    }

                }

                if (j == 1)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                        continue_button.SetActive(true); Debug.Log("2");
                        
                    }
                }
                
                if(hasenter)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue3();
                        continue_button.SetActive(true); Debug.Log("3");
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        Nextdisplay();
                        continue_button.SetActive(false); Debug.Log("4");
                        j++;
                    }
                }

                if (j == 2)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue4(); Debug.Log("4");
                    }   
                }
            }
                



        }
    }


    public GameObject imgUIInventarioUSB;
    
    
    public void GetUSB()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[6] == false) // controllo di avere spazio nell'inventario
            {
                inventory.isFull[6] = true;
                Instantiate(imgUIInventarioUSB, inventory.slots[6].transform, false);
                inventory.listInventoryItems.Add("USB");
                Debug.Log("Ho ricevuto la USB");
                break;
            }
        }
    }


    public GameObject imgUIInventarioWrench;
    private void GetCollezionabile()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[7] == false) // controllo di avere spazio nell'inventario
            {
                inventory.isFull[7] = true;
                Instantiate(imgUIInventarioWrench, inventory.slots[7].transform, false);
                inventory.listInventoryItems.Add("Wrench");
                Debug.Log("Ho ricevuto la chiave inglese");
                break;
            }
        }
    }
   
 

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.name == "Policerobot_piccolo")
            {

                TriggerDialogue();
                canvas.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.name == "Policerobot_piccolo")
            {

               
                canvas.SetActive(false);
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
    public void Getenter()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false) // controllo di avere spazio nell'inventario
            {
                inventory.isFull[i] = true;
                
                inventory.listInventoryItems.Add("entrato");
                Debug.Log("sonoentrato");
                break;
            }
        }
    }
}

// ancora da mettere imgLattinaOlio dopo averla creata e piazzata in scena (nascosta da qualche parte)