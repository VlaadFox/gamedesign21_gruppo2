using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject timer1, timer2, timer3, timer4, thiss;

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
            timer3.SetActive(false);
            timer4.SetActive(false);
            thiss.SetActive(true);
        }
    }
}
