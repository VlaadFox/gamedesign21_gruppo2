using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_dialog : MonoBehaviour
{

    public GameObject canvas;
    public GameObject dialogCanvas;
    public GameObject bottoni;
    public Animator anim;

    private void Start()
    {

        anim.SetBool("robotLavBase", true);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            canvas.SetActive(true);


        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
            dialogCanvas.SetActive(false);
            bottoni.SetActive(false);

            anim.SetBool("robotLavTalk", false);

            anim.SetBool("robotLavBase", true);
        }
    }

    

}
