using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_quadro : MonoBehaviour
{
    public GameObject canvas;
    public GameObject luce;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(true);

            FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        canvas.SetActive(false);
    }

   /* private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            luce.SetActive(true);
           // FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
            

        }
    }*/

    /* public IEnumerator load()
     {
         yield return new WaitForSeconds(1f);
         FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
     }*/


}
