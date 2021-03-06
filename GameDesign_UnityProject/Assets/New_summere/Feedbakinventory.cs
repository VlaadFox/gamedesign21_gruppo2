using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedbakinventory : MonoBehaviour
{
    public GameObject coinCanvas;
    public GameObject WrenchCanvas;
    public GameObject CanCanvas;
    public GameObject UsbCanvas;
    public GameObject Toys;

    public void CoinFeed()
    {
        coinCanvas.SetActive(true);
        StartCoroutine(endenergy());
    }
    public void ToysFeed()
    {
        Toys.SetActive(true);
        StartCoroutine(endenergy());
    }
    public void WrenchFeed()
    {
        WrenchCanvas.SetActive(true);
        StartCoroutine(endenergy());
    }
    public void CanFeed()
    {
        CanCanvas.SetActive(true);
        StartCoroutine(endenergy());
    }
    public void UsbFeed()
    {
        UsbCanvas.SetActive(true);
        StartCoroutine(endenergy());
    }
    public IEnumerator endenergy()
    {
        yield return new WaitForSeconds(5f);
        coinCanvas.SetActive(false);
        WrenchCanvas.SetActive(false);
        CanCanvas.SetActive(false);
        UsbCanvas.SetActive(false);
        Toys.SetActive(false);
    }
    
}
