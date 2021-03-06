using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Dialog_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;
    public Dialogo_padre dialogue2;
    public Dialogo_padre dialogue3;
    public Dialogo_padre dialogue4;
    public Dialogo_padre dialogue5;

    public GameObject icon;

    public GameObject StepAudio;

    public GameObject textInter, textmission;

   // public GameObject Robottonesi;
    //public GameObject RobottoneEnergia;

    public Animator transistion;

   // public GameObject ladro;

    public GameObject canvas;
    public GameObject canvasDel;
    public GameObject continue_button;

    public Animator anim;

   // private int b=0;

    private Inventory inventory;
    //private Energy energy;

   // private InventorySlot inventorySlot;

    private bool hasCoin = false; // per controllare moneta
    private bool hasCan = false;
    private bool hasCanRed = false;// per controllare lattina
    private bool hasUSB = false;
    private bool hasenter = false;
    private bool hasmoney = false;
    private bool hasWrench = false;
    private bool haslight = false;
    private bool Ch = false;
    private bool Ga = false;
    private bool notalk = false;
    private bool tombino = false;
    private bool energy = false;
    private bool noenergy = false;
    //private bool firstime = false;

    public GameObject imgUIInventarioMoneta;

    public GameObject slot1Inventario;


    public GameObject camera;
    
    public GameObject canvasBottoni;


    public GameObject yesFirstButton;

    public GameObject playerController;
    public GameObject antagonist;
    public GameObject antagonista;

    /*public TextMeshProUGUI txtMissioneDog;
    public TextMeshProUGUI txtMissioneOil;*/
    public Color colorText;

    private AudioSource audioGetCollezionabile;
    public GameObject cameralavori, cameraAnt, cameraluce, camerarobottone, cameraladro,cameravecchio;





    public int j ;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerController = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        audioGetCollezionabile = GameObject.FindGameObjectWithTag("audioRobotLavori").GetComponent<AudioSource>();
        
    }
    public IEnumerator time()
    {
        yield return new WaitForSeconds(1f);
        transistion.SetTrigger("start");
        transistion.SetTrigger("end");
        canvas.SetActive(false);

    
        antagonist.SetActive(false);
    }


    private void Update()
    {
        energy = inventory.listInventoryItems.Contains("energy");
        noenergy = inventory.listInventoryItems.Contains("noenergy");
    }

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
                Ch = inventory.listInventoryItems.Contains("secondo");
                Ga = inventory.listInventoryItems.Contains("primo");
                tombino = inventory.listInventoryItems.Contains("Tombino");
            hasCanRed= inventory.listInventoryItems.Contains("LattinaOlioRED");






            if (gameObject.name == "robotLavori") // stai parlando col robot
            {
                if (!canvasBottoni.active)
                {

                    if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                    {
                        Debug.Log("fine");
                        cameralavori.SetActive(false);
                        playerController.GetComponent<CharacterController>().enabled = true;
                        playerController.GetComponent<ThirdPersonController>().enabled = true;
                        // playerController.SetActive(true);
                        anim.SetBool("talkBool", false);
                        anim.SetBool("pauseBool", true);
                        canvasDel.SetActive(false);
                        canvas.SetActive(false);
                        continue_button.SetActive(false);

                    }
                }
                //this.cameralavori = GameObject.FindGameObjectWithTag("Cameralavori");

                if (!hasCan && !tombino && !hasCanRed) // entra nel ciclo in cui NON ha ancora la lattina d'olio
                {
                    if (hasCoin)
                    {
                        // qu?? ti ha gi?? dato la moneta, da mettere messaggio che dice "Fai presto perfavore!"
                        Debug.Log("Hai gi?? la moneta");
                        Debug.Log("Fai presto perfavore!");
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            cameralavori.SetActive(true);
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue2();
                            continue_button.SetActive(true);
                        }
                    }
                    else
                    {
                        // qu?? ancora NON hai la moneta, ti chiede "Ciao, mi servirebbe una lattina d'olio per recuperare energie, ti andrebbe di aiutarmi?"
                        // quindi da gestire domanda con possibilit?? di rispondere s?? o no
                        //Debug.Log("Ciao, mi servirebbe una lattina d'olio per recuperare energie, ti andrebbe di aiutarmi?");

                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            cameralavori.SetActive(true);
                           // playerController.GetComponent<CharacterController>().enabled = false;
                            playerController.GetComponent<ThirdPersonController>().enabled = false;
                            
                            //Time.timeScale = 0f;
                            // playerController.SetActive(false);
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                            canvasBottoni.SetActive(true);

                            Cursor.lockState = CursorLockMode.None;
                            // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                            EventSystem.current.SetSelectedGameObject(null);
                            // ora posso selezionare in oggetto
                            EventSystem.current.SetSelectedGameObject(yesFirstButton);
                        }

                        


                        // "NO"
                        // chiudiamo semplicemente il dialogo col robot o gli dice qualcosa?
                    }
                }
                else // qu?? hai gi?? comprato la lattina d'olio
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions") && !tombino)
                    {
                        cameralavori.SetActive(true);
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue3();
                        DropItem(); // mi droppa il primo elemento nell'inventario qualsiasi esso sia, in questo caso deve essere la lattina d'olio per logica
                        GetCollezionabile();
                        FindObjectOfType<Feedbakinventory>().WrenchFeed();
                        continue_button.SetActive(true);

                        Debug.Log("Ce l'hai fatta! Grazie mille, eccoti una ricompensa.");
                    }
                    if (hasWrench)
                    {

                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            cameralavori.SetActive(true);
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue4();
                            continue_button.SetActive(true);

                        }
                        
                    }

                    if (tombino )
                    {
                        if (hasCanRed)
                        {
                            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                            {
                                cameralavori.SetActive(true);
                                anim.SetBool("talkBool", true);
                                anim.SetBool("pauseBool", false);
                                canvasDel.SetActive(false);
                                canvas.SetActive(true);
                                TriggerDialogue2();
                                continue_button.SetActive(true);

                            }
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
                if (!canvasBottoni.active)
                {

                    if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                    {
                        Debug.Log("fine");
                        cameraluce.SetActive(false);

                        playerController.GetComponent<ThirdPersonController>().enabled = true;
                        // playerController.SetActive(true);

                        canvasDel.SetActive(false);
                        canvas.SetActive(false);
                        continue_button.SetActive(false);

                    }
                }
                if (!haslight)
                {

                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        playerController.GetComponent<ThirdPersonController>().enabled = false;
                        //Time.timeScale = 0f;
                        cameraluce.SetActive(true);
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
                }
                else if (haslight)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        cameraluce.SetActive(true);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        continue_button.SetActive(true);
                        TriggerDialogue3();

                    }
                }
            }


            if (gameObject.name == "Robottone")
                {
                
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                    // playerController.GetComponent<CharacterController>().enabled = false;
                    //Time.timeScale = 0f;
                    playerController.GetComponent<ThirdPersonController>().enabled = false;
                    camerarobottone.SetActive(true);
                    continue_button.SetActive(false);
                    //anim.SetBool("talkBool", true);
                    //anim.SetBool("pauseBool", false);
                    Debug.Log("entrato");
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
                   
                   
                }
            if (gameObject.name == "antagonista2")
            {

                
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                {
                    if (Ch)
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                    }
                    if (Ga)
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue3();
                    }
                    if (!Ch)
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
                    }
                    
                   



                }

            }



            if (gameObject.name == "robotLadro")
            {
                if (!canvasBottoni.active)
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                    {
                        playerController.GetComponent<ThirdPersonController>().enabled = true;

                        cameraladro.SetActive(false);



                        anim.SetBool("talkBool", false);
                        anim.SetBool("pauseBool", true);
                        canvasDel.SetActive(false);
                        canvas.SetActive(false);

                        continue_button.SetActive(false);
                        canvasBottoni.SetActive(false);
                        Cursor.lockState = CursorLockMode.None;
                        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                        EventSystem.current.SetSelectedGameObject(null);
                        // ora posso selezionare in oggetto
                        EventSystem.current.SetSelectedGameObject(yesFirstButton);
                    }
                }
                if (!hasUSB)
                {
                   
                       
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                        playerController.GetComponent<ThirdPersonController>().enabled = false;
                        cameraladro.SetActive(true);

                            TriggerDialogue2();

                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);

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
                        cameraladro.SetActive(true);
                        continue_button.SetActive(true);
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
                        cameraladro.SetActive(true);
                        continue_button.SetActive(true);
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


            if (gameObject.name == "antagonista")
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                {
                    canvas.SetActive(false);
                    continue_button.SetActive(false);
                   
                    playerController.GetComponent<ThirdPersonController>().enabled = true;
                    icon.SetActive(false);
                    transistion.SetTrigger("start");
                    transistion.SetTrigger("end");
                    StartCoroutine(antag());
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
                            playerController.GetComponent<ThirdPersonController>().enabled = false;
                            cameravecchio.SetActive(true);
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue();
                            continue_button.SetActive(true); Debug.Log("1");

                            textInter.SetActive(false);
                            textmission.SetActive(true);
                        }
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = false;
                            cameravecchio.SetActive(true);
                            Nextdisplay();
                            
                            Debug.Log("1.2");
                            StartCoroutine(delay()); 
                            continue_button.SetActive(true);
                        }

                    }

                    if (j == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit")|| Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = false;
                            cameravecchio.SetActive(true);
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue2();
                            continue_button.SetActive(true);
                            Debug.Log("2");
                            StartCoroutine(delay());

                            
                        }
                        
                    }
                    if (j >= 2)
                    {
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = true;
                            cameravecchio.SetActive(false);
                            anim.SetBool("talkBool", false);
                            anim.SetBool("pauseBool", true);
                            canvasDel.SetActive(false);
                            canvas.SetActive(false);
                            continue_button.SetActive(false);
                            StartCoroutine(delayneg());
                        }
                    }
                }

                if (hasenter)
                {
                    if (j == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = false;
                            cameravecchio.SetActive(true);
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            continue_button.SetActive(true);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue3();
                            continue_button.SetActive(true); Debug.Log("3");
                        }
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = false;
                            cameravecchio.SetActive(true);
                            Nextdisplay();
                            Debug.Log("4");
                            StartCoroutine(delay());
                        }
                    }
                    if (j == 1)
                    {
                        
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = true;
                            cameravecchio.SetActive(false);
                            anim.SetBool("talkBool", false);
                            anim.SetBool("pauseBool", true);
                            canvasDel.SetActive(false);
                            canvas.SetActive(false);
                            continue_button.SetActive(false);
                            StartCoroutine(delay());

                        }
                    }

                    if (j >= 2)
                    {
                        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = false;
                            cameravecchio.SetActive(true);
                            anim.SetBool("talkBool", true);
                            anim.SetBool("pauseBool", false);
                            canvasDel.SetActive(false);
                            canvas.SetActive(true);
                            TriggerDialogue4(); Debug.Log("4");
                            notalk = inventory.listInventoryItems.Contains("notalk");
                        }
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                        {
                            playerController.GetComponent<ThirdPersonController>().enabled = true;
                            cameravecchio.SetActive(false);
                            anim.SetBool("talkBool", false);
                            anim.SetBool("pauseBool", true);
                            canvasDel.SetActive(false);
                            canvas.SetActive(false);
                            continue_button.SetActive(false);
                           
                            
                        }
                    }
                }
                if (notalk)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        playerController.GetComponent<ThirdPersonController>().enabled = false;
                        cameravecchio.SetActive(true);
                        anim.SetBool("talkBool", true);
                        anim.SetBool("pauseBool", false);
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue4();
                        continue_button.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Submit"))
                    {
                        playerController.GetComponent<ThirdPersonController>().enabled = true;
                        cameravecchio.SetActive(false);
                        anim.SetBool("talkBool", false);
                        anim.SetBool("pauseBool", true);
                        canvasDel.SetActive(false);
                        canvas.SetActive(false);
                        continue_button.SetActive(false);


                    }
                }
            }
                



        }
    }

 public void Yesrobottone() 
                {
                    Debug.Log("fine");
                    camerarobottone.SetActive(false);

                    playerController.GetComponent<ThirdPersonController>().enabled = true;
                    // playerController.SetActive(true);

                    canvasDel.SetActive(false);
                    canvas.SetActive(false);
                    continue_button.SetActive(false);

                }

public GameObject imgUIInventarioUSB;
    
    
    public void GetUSB()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[6] == false) // controllo di avere spazio nell'inventario
            {
                audioGetCollezionabile.Play();
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
    //public AudioSource audioGetCollezionabile;
    
    private void GetCollezionabile()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[7] == false) // controllo di avere spazio nell'inventario
            {
                audioGetCollezionabile.Play();
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

                StepAudio.GetComponent<AudioSource>().enabled = false;
                cameraAnt.SetActive(true);
                playerController.GetComponent<ThirdPersonController>().enabled = false;
                continue_button.SetActive(true);
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

           
        }
    }

    public IEnumerator antag()
    {
        yield return new WaitForSeconds(1f);
        antagonista.SetActive(false);
        cameraAnt.SetActive(false);
        StepAudio.GetComponent<AudioSource>().enabled = true;

        // Destroy(antagonista);
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
                audioGetCollezionabile.Play();
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

    public void Robottone()
    {
        if (energy) 
        {
            TriggerDialogue3();
        }
        if (noenergy)
        {
            TriggerDialogue2();
        }

    }
    /*public void siRobottone()
    {
        Robottonesi.SetActive(true);
    }
    public void energiaRobottone()
    {
        RobottoneEnergia.SetActive(true);
    }
    */
    public IEnumerator DestroyLadro()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
    public IEnumerator finishdialogue()
    {
        yield return new WaitForSeconds(4f);
        transistion.SetTrigger("start");
        transistion.SetTrigger("end");
        canvas.SetActive(false);
        canvasDel.SetActive(false);
    }
    public IEnumerator aggiustalight()
    {
        yield return new WaitForSeconds(1f);
        TriggerDialogue3();
    }
    public void fade()
    {
        transistion.SetTrigger("start");
        transistion.SetTrigger("end");
        StartCoroutine(aggiustalight());
    }
    public IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        j++;
    }
    public IEnumerator delayneg()
    {
        yield return new WaitForSeconds(1f);
        j--;
    }

    public void Scale()
    {
        playerController.GetComponent<ThirdPersonController>().Scale();
    }
    public void Light()
    {
        playerController.GetComponent<ThirdPersonController>().lightrue();
    }
}


// ancora da mettere imgLattinaOlio dopo averla creata e piazzata in scena (nascosta da qualche parte)