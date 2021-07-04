using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOBJ_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;

    public GameObject canvas;
    public GameObject canvasDel;


    private Inventory inventory;
    private bool hasCoin = false;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<Info_OBJ>().StartDialogue(dialogue);
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



                hasCoin = inventory.listInventoryItems.Contains("ToretCoin");

                if(hasCoin)
                {
                    // quì hai la moneta, da mettere messaggio che dice che la cabina è rotta e di cercarne un'altra funzionante.
                }
                else
                {
                    // quì NON hai la moneta, da mettere messaggio che dice "per utilizzare la cabina inserisci una moneta."
                }
            }
        }

    }
}
