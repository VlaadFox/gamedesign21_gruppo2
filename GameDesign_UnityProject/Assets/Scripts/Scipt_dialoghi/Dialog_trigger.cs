using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dialog_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;
    public Dialogo_padre dialogue2;
    public Dialogo_padre dialogue3;
    public Dialogo_padre dialogue4;
    public Dialogo_padre dialogue5;

    public Animator transistion;

   // public GameObject ladro;

    public GameObject canvas;
    public GameObject canvasDel;
    public GameObject continue_button;

    public Animator anim;

    private int b=0;

    private Inventory inventory;
    private Energy energy;

    private InventorySlot inventorySlot;

    private bool hasCoin = false; // per controllare moneta
    private bool hasCan = false; // per controllare lattina
    private bool hasUSB = false;
    private bool hasenter = false;
    private bool hasmoney = false;
    private bool hasWrench = false;
    private bool haslight = false;
    private bool firstime = false;

    public GameObject imgUIInventarioMoneta;

    public GameObject slot1Inventario;


    public GameObject camera;
    
    public GameObject canvasBottoni;


    public GameObject yesFirstButton;

    public GameObject playerController;
    public GameObject antagonist;
    public GameObject antagonista;



    private int j ;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerController = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
       


    }
    public IEnumerator time()
    {
        yield return new WaitForSeconds(1f);
        transistion.SetTrigger("start");
        transistion.SetTrigger("end");
        canvas.SetActive(false);

        antagonist.SetActive(false);
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
    public void TriggerDialogue5()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialogue5);
    }


    



    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
                hasCoin = inventory.listInventoryItems.Contains("ToretCoin");
                hasCan = inventory.listInventoryItems.Contains("LattinaOlio");
                hasUSB = inventory.listInventoryItems.Contains("USB");
                hasenter = inventory.listInventoryItems.Contains("entrato");
                hasmoney = inventory.listInventoryItems.Contains("money");
                hasWrench= inventory.listInventoryItems.Contains("Wrench");
                haslight= inventory.listInventoryItems.Contains("luce");





            
            if (gameObject.name == "robotLavori") // stai parlando col robot
                {
                    if(!hasCan) // entra nel ciclo in cui NON ha ancora la lattina d'olio
                    {
                        if (hasCoin)
                        {
                            // quì ti ha già dato la moneta, da mettere messaggio che dice "Fai presto perfavore!"
                            Debug.Log("Hai già la moneta");
                            Debug.Log("Fai presto perfavore!");
                            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
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
                            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                            {
                                playerController.GetComponent<CharacterController>().enabled = false;
                                Time.timeScale = 0f;

                                anim.SetBool("talkBool", true);
                                anim.SetBool("pauseBool", false);
                                canvasDel.SetActive(false);
                                canvas.SetActive(true);
                                TriggerDialogue();
                                Cursor.lockState = CursorLockMode.None;
                                canvasBottoni.SetActive(true);

                                // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                                EventSystem.current.SetSelectedGameObject(null);
                                // ora posso selezionare in oggetto
                                EventSystem.current.SetSelectedGameObject(yesFirstButton);
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
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue3();
                            DropItem(); // mi droppa il primo elemento nell'inventario qualsiasi esso sia, in questo caso deve essere la lattina d'olio per logica
                            GetCollezionabile();
                            FindObjectOfType<Feedbakinventory>().WrenchFeed();


                        Debug.Log("Ce l'hai fatta! Grazie mille, eccoti una ricompensa.");
                        }
                    if (hasWrench)
                    {

                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue4();

                        }
                    }
                        
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                        // aggiungere in questo if il dialogo dove dice che gli ha dato la chiave inglese come collezionabile
                    }
                }





            if (gameObject.name == "RobotLucee")
            {
                if (!haslight)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
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
                }else if (haslight)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();

                    }
                }
            }





            if (gameObject.name == "Robottone")
                {
               
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                    
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                    continue_button.SetActive(true);
                    canvasBottoni.SetActive(false);


                }
                   if (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Submit"))
                    {
                    playerController.GetComponent<CharacterController>().enabled = false;
                    Time.timeScale = 0f;
                    continue_button.SetActive(false);
                    //anim.SetBool("talkBool", true);
                    //anim.SetBool("pauseBool", false);
                    Debug.Log("entrato");
                    canvasDel.SetActive(false);
                    canvas.SetActive(true);
                    TriggerDialogue5();
                    Cursor.lockState = CursorLockMode.None;
                    canvasBottoni.SetActive(true);

                    // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                    EventSystem.current.SetSelectedGameObject(null);
                    // ora posso selezionare in oggetto
                    EventSystem.current.SetSelectedGameObject(yesFirstButton);




                }
                   
                }



            if (gameObject.name == "robotLadro")
            {
                if (!hasUSB)
                {
                   
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            //playerController.GetComponent<CharacterController>().enabled = false;
                            //Time.timeScale = 0f;
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                            continue_button.SetActive(true);
                            // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                            //EventSystem.current.SetSelectedGameObject(null);
                            // ora posso selezionare in oggetto
                           // EventSystem.current.SetSelectedGameObject(yesFirstButton);
                        }
                        if (Input.GetKeyDown(KeyCode.C) || Input.GetButtonDown("Submit"))
                        {
                            playerController.GetComponent<CharacterController>().enabled = false;
                            Time.timeScale = 0f;

                            TriggerDialogue2();
                            
                            
                            continue_button.SetActive(false);
                        canvasBottoni.SetActive(true);
                        Cursor.lockState = CursorLockMode.None;
                        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                            EventSystem.current.SetSelectedGameObject(null);
                            // ora posso selezionare in oggetto
                            EventSystem.current.SetSelectedGameObject(yesFirstButton);
                    }
                }
                if (hasUSB)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue3();
                    }
                }
                if (hasmoney)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue4();
                        StartCoroutine(finishdialogue());
                        StartCoroutine(DestroyLadro());

                    }
                }
            }

            if (gameObject.name == "robotRotto")
            {
                if (!hasenter)
                {
                    if (j == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                            continue_button.SetActive(true); Debug.Log("1");
                        }
                        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit"))
                        {
                            Nextdisplay();
                            continue_button.SetActive(false); Debug.Log("1.2");
                            StartCoroutine(delay()); continue_button.SetActive(true);
                        }

                    }

                    if (j == 1)
                    {
                        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue2();
                            continue_button.SetActive(false);
                            Debug.Log("2");

                        }
                    }
                }

                if (hasenter)
                {
                    if (j == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue3();
                            continue_button.SetActive(true); Debug.Log("3");
                        }
                        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit"))
                        {
                            Nextdisplay();
                            continue_button.SetActive(false); Debug.Log("4");
                            StartCoroutine(delay());
                        }
                    }


                    if (j == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
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
    public void Getlight()
    {
        
               
                
                inventory.listInventoryItems.Add("luce");
                Debug.Log("Ho ricevuto la luce");
                
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
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.name == "antagonista")
            {
                canvas.SetActive(true);
                TriggerDialogue();
                
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

            if (gameObject.name == "antagonista")
            {

                canvas.SetActive(false);
                

                transistion.SetTrigger("start");
                transistion.SetTrigger("end");
                StartCoroutine(antag());
            }
        }
    }

    public IEnumerator antag()
    {
        yield return new WaitForSeconds(1f);
        antagonista.SetActive(false);
    }

    public void DropItem()
    {
        foreach (Transform child in inventory.slots[0].transform)
        {
            GameObject.Destroy(child.gameObject);
            inventory.isFull[0] = false;
        }
    }

    public void Getcoin()
    {
        /*for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[0] == false) // controllo di avere spazio nell'inventario
            {*/
                inventory.isFull[0] = true;
                Instantiate(imgUIInventarioMoneta, inventory.slots[0].transform, false);
                inventory.listInventoryItems.Add("ToretCoin");
                Debug.Log("Ho ricevuto la moneta");
                //break;
            /*}
        }*/
    }
    public void Getenter()
    {
        
                 inventory.listInventoryItems.Add("entrato");
                Debug.Log("sonoentrato");
                
    }
    public void NoRobottone()
    {
        TriggerDialogue4();
    }

    public IEnumerator DestroyLadro()
    {
        yield return new WaitForSeconds(6f);
        this.gameObject.SetActive(false);
    }
    public IEnumerator finishdialogue()
    {
        yield return new WaitForSeconds(5f);
        transistion.SetTrigger("start");
        transistion.SetTrigger("end");
        canvas.SetActive(false);
    }
    public IEnumerator aggiustalight()
    {
        yield return new WaitForSeconds(2f);
        TriggerDialogue2();
    }
    public void fade()
    {
        transistion.SetTrigger("start");
        transistion.SetTrigger("end");
        StartCoroutine(aggiustalight());
    }
    public IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        j++;
    }

    public void Scale()
    {
        playerController.GetComponent<ThirdPersonController>().Scale();
    }
}


// ancora da mettere imgLattinaOlio dopo averla creata e piazzata in scena (nascosta da qualche parte)