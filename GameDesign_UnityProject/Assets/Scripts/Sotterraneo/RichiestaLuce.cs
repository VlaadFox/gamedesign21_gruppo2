using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RichiestaLuce : MonoBehaviour
{
    public GameObject uIObject, scritta;
    public GameObject playerController;
    void Start()
    {
        uIObject.SetActive(false);

      

    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") && !other.GetComponent<ThirdPersonController>().retLight())
        {
            //playerController = other.gameObject;

            //if (playerController.GetComponent<ThirdPersonController>().retLight()) { 

            uIObject.SetActive(true);
            StartCoroutine("Wait");
            //}
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        uIObject.SetActive(false);
        // Destroy(uIObject);
        // Destroy(gameObject);
    }
   

}
