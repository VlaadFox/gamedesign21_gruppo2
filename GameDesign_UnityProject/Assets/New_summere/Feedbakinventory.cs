using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedbakinventory : MonoBehaviour
{
    public GameObject coinCanvas;


    public void CoinFeed()
    {
        coinCanvas.SetActive(true);
        StartCoroutine(endenergy());
    }
    public IEnumerator endenergy()
    {
        yield return new WaitForSeconds(3f);
        coinCanvas.SetActive(false);

    }
    
}
