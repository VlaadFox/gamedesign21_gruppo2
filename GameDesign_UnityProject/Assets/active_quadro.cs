using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_quadro : MonoBehaviour
{
    public GameObject canvas;
    public GameObject light;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(true);


        }
    }

    private void OnTriggerExit(Collider collider)
    {
        canvas.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            
            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<LevelLoader>().LoadNextLevelRoom();
            

        }
    }

    /* public IEnumerator load()
     {
         yield return new WaitForSeconds(1f);
         FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
     }*/


}
