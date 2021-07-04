using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;


    public GameObject canvas;
    public GameObject canvasDel;


    private Inventory inventory;

    private bool hasCoin = false; // per controllare moneta
    private bool hasCan = false; // per controllare lattina

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialogue);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                canvasDel.SetActive(false);
                canvas.SetActive(true);
                TriggerDialogue();


                hasCan = inventory.listInventoryItems.Contains(""); // nome lattina

            }
        }
           
    }
       
    

}
