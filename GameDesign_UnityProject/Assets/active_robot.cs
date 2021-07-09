using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_robot : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(true);


        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
           
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
            StartCoroutine(despawn());
        }
    }
    public IEnumerator despawn()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);

    }
}
