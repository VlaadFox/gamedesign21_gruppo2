using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTurin_quadro : MonoBehaviour
{
    public GameObject canvas;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            canvas.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
            {
                light1.SetActive(true);
                light2.SetActive(true);
                light3.SetActive(true);
                light4.SetActive(true);
                StartCoroutine(delayLoad());
                Debug.Log("gototorino");
            }

            Debug.Log("sononelcollider");

        }
    }
    public IEnumerator delayLoad()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
    }
}
