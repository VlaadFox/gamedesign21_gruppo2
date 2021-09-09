using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RichiestaLuce : MonoBehaviour
{
    public GameObject muro;
    public GameObject Canvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThirdPersonController>().retLight())
        {
            //PUOI PASSARE

            //if (playerController.GetComponent<ThirdPersonController>().retLight()) { 
            Canvas.SetActive(false);
            muro.SetActive(false);

        }
    }
   
   

}
