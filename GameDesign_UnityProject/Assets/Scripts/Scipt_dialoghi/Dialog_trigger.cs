using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_trigger : MonoBehaviour
{
    public Dialogo_padre dialogue;

    public GameObject canvas;
    public GameObject canvasDel;


    public void TriggerDialogue()
    {
        FindObjectOfType<Dialog_manager>().StartDialogue(dialogue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            canvasDel.SetActive(false);
            canvas.SetActive(true);
            TriggerDialogue();
        }
    }

}
