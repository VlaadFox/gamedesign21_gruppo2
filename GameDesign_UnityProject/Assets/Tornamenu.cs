using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tornamenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Menu());
    }

    public IEnumerator Menu()
    {
        yield return new WaitForSeconds(37f);
        SceneManager.LoadScene("_StartMenu");

    }
}
