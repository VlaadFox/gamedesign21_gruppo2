using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_dialog : MonoBehaviour
{

    public GameObject canvas;
    public GameObject dialogCanvas;
    public GameObject dialogCanvas1;
    public GameObject dialogCanvas2;

    public GameObject bottoni;
    [SerializeField]
    private GameObject continue_button;
    public Animator anim;

    public Vector3 v1;
    public Quaternion v2;


    private void Start()
    {
       // continue_button= GameObject.FindGameObjectWithTag("Continue");
        anim.SetBool("pauseBool", true);
        this.GetComponent<followerNPC>().enabled = false;
        this.GetComponent<ffollowerNPC>().enabled = true;
        v1 = this.transform.rotation.eulerAngles;
        v2 = this.transform.rotation;

    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            canvas.SetActive(true);

            this.GetComponent<followerNPC>().enabled = true;
            this.GetComponent<ffollowerNPC>().enabled = false;


        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
            dialogCanvas.SetActive(false);
           
            bottoni.SetActive(false);
            continue_button.SetActive(false);

            anim.SetBool("talkBool", false);

            anim.SetBool("pauseBool", true);

            dialogCanvas1.SetActive(false);
            dialogCanvas2.SetActive(false);
            this.GetComponent<followerNPC>().enabled = false;
            StartCoroutine(waitS());

        }



    }
    public IEnumerator waitS()
    {
        yield return new WaitForSeconds(3f);
        print("daiiiiiii");
        //this.gameObject.transform.SetPositionAndRotation(this.transform.position, v1);
        // Quaternion rotTarget = Quaternion.LookRotation(v1 - this.transform.rotation.eulerAngles);
        //this.gameObject.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, v1, 5f * Time.deltaTime);
        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, 60f * Time.deltaTime);
        //this.gameObject.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, v2, 5f * Time.deltaTime);
        this.GetComponent<ffollowerNPC>().enabled = true;
    }



}
