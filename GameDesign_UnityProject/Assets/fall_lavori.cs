using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_lavori : MonoBehaviour
{

    public GameObject playerpos;
    public GameObject playeref;
    public Animator transistion;
    private Vector3 pos;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        pos = playerpos.transform.position;
        playeref = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            transistion.SetTrigger("start");
            transistion.SetTrigger("end");
            StartCoroutine(despawn());
           
            StartCoroutine(avviso());
        }
    }
    public IEnumerator despawn()
    {
        yield return new WaitForSeconds(1f);
        playeref.transform.position = pos;
       
    }
   
    public IEnumerator avviso()
    {
        yield return new WaitForSeconds(1f);
        canvas.SetActive(true);
        StartCoroutine(avvisooff());
    }
    public IEnumerator avvisooff()
    {
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);

    }
}
