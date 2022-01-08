using System.Collections;
using StarterAssets;
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

    private AudioSource audioGetCollezionabile;
    public GameObject cameraoil;
    



    private Inventory inventory;

    private bool hasCoin = false;
    private bool hasCan = false;
    

    public GameObject tombino;
    


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
        slot1Inventario = GameObject.FindGameObjectWithTag("Slot1");
        playerController = GameObject.FindGameObjectWithTag("Player");
        audioGetCollezionabile = GameObject.FindGameObjectWithTag("audioRobotLavori").GetComponent<AudioSource>();
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
                //camera = GameObject.FindGameObjectWithTag("cameraoil");
                Debug.Log("oliomacchina");
                if (!hasCan && !hasCoin)
                {
                    // da mettere messaggio "Lattina d'olio: 1 moneta."
                   
                    if (Input.GetKeyDown(KeyCode.R) ||Input.GetButtonDown("Interactions"))
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
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                         playerController.GetComponent<ThirdPersonController>().enabled = false;
                        // Time.timeScale = 0f;
                        
                        cameraoil.SetActive(true);
                        
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

                    // "SI"

                    // qua mi cancella la moneta dall'inventario

                    this.GetComponent<AudioSource>().Play();

                    // "NO"
                    // chiudi il dialogo
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
                    }
                }
            }

            if (gameObject.name == "OilVending_seconda") // stai interagendo con la macchinetta nella seconda piazza (can rossa)
            {
                if (!hasCan && !hasCoin)
                {
                    // da mettere messaggio "Lattina d'olio: 1 moneta."

                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
                        Debug.Log("Lattina di energia: 1 moneta.");
                    }
                }
                else if (!hasCan && hasCoin) // quì hai preso già la moneta dal robot delle costruzioni
                {
                    // da mettere messaggio "Vuoi acquistare una lattina d'olio?"
                    Debug.Log("Vuoi acquistare una lattina di energai?");
                    Debug.Log("Sì");
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

                    // "SI"

                    // qua mi cancella la moneta dall'inventario



                    // "NO"
                    // chiudi il dialogo
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
                    }
                }
            }   

            if(gameObject.name == "CabinaTel")
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                {
                    canvasDel.SetActive(false);
                    canvas.SetActive(true);
                    TriggerDialogue();
                }
            }

            if(gameObject.name == "CabinaTel_funzionante")
            {
                if (hasCoin)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        playerController.GetComponent<CharacterController>().enabled = false;
                        Time.timeScale = 0f;
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
                        Cursor.lockState = CursorLockMode.None;
                        canvasBottoni.SetActive(true);

                        //aprire la il tombino
                        inventory.listInventoryItems.Add("Tombino");
                        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
                        EventSystem.current.SetSelectedGameObject(null);
                        // ora posso selezionare in oggetto
                        EventSystem.current.SetSelectedGameObject(yesFirstButton);
                    }
                }
                if (!hasCoin)
                {
                    if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue2();
                    }
                }
            }

            /*if (gameObject.name == "Chiosco")
            {
                if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
                {
                    if (!FindObjectOfType<Energy>().checkFinal())
                    {
                        canvasDel.SetActive(false);
                        canvas.SetActive(true);
                        TriggerDialogue();
                    }
                }
            }*/


        }
    }


    public void DropItem()
    {
        foreach (Transform child in inventory.slots[0].transform)
        {
            
            GameObject.Destroy(child.gameObject);
            inventory.isFull[0] = false;
        }
        inventory.listInventoryItems.Remove(item: "ToretCoin");
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[0] == false)
            {
                audioGetCollezionabile.Play();
                inventory.isFull[0] = true;
                Instantiate(imgUIInventarioLattinaOlio, inventory.slots[0].transform, false);
                inventory.listInventoryItems.Add("LattinaOlio");
                Debug.Log("Ho ricevuto la lattina d'olio");
                break;
            }
        }
    }
    public void DropCoin()
    {
        foreach (Transform child in inventory.slots[0].transform)
        {
            GameObject.Destroy(child.gameObject);
            inventory.isFull[0] = false;
        }
        inventory.listInventoryItems.Remove(item: "ToretCoin");
        
    }

    public void DropItemRED()
    {
        foreach (Transform child in inventory.slots[0].transform)
        {
            GameObject.Destroy(child.gameObject);
            inventory.isFull[0] = false;
        }
        inventory.listInventoryItems.Remove(item: "ToretCoin");
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                audioGetCollezionabile.Play();
                inventory.isFull[i] = true;
                Instantiate(imgUIInventarioLattinaOlio_RED, inventory.slots[i].transform, false);
                inventory.listInventoryItems.Add("LattinaOlioRED");
                Debug.Log("Ho ricevuto la lattina d'olio rossa");
                break;
            }
        }
    }

    public void Hellopen()
    {
        tombino.GetComponent<SphereCollider>().enabled = true;
    }
}
