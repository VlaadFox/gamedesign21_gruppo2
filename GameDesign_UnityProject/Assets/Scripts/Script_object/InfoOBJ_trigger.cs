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

                for (int i = 0; i < inventory.listInventoryItems.Count; i++)
                {
                    // Debug.Log(inventory.listInventoryItems[i]);
                    if (inventory.listInventoryItems[i] == "ToretCoin")
                        hasCoin = true;
                }

                //hasCoin = inventory.listInventoryItems.Contains("ToretCoin");

                if(hasCoin)
                    Debug.Log("Hai la moneta");
                else
                    Debug.Log("NON hai la moneta");
            }
        }

    }
}
