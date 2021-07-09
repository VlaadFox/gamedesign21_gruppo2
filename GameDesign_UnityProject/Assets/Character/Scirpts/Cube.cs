using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject timer1, timer2, thiss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timer1.SetActive(false);
            timer2.SetActive(false);
            thiss.SetActive(true);
        }
    }
}
