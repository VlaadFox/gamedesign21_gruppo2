using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTurin_quadro : MonoBehaviour
{
    public GameObject canvas;
    public GameObject light;

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
                light.SetActive(true);
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
