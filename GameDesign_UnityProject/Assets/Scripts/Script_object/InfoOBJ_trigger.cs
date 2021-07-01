using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOBJ_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;

    public GameObject canvas;
    public GameObject canvasDel;


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
            }
        }

    }
}
