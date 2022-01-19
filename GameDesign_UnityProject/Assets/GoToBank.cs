using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBank : MonoBehaviour
{
    private bool hasUSB = false;
    private bool hasmoney = false;
    private Inventory inventory;
    public GameObject Banca;

    private AudioSource audioAperturaPorte;
    private bool triggerAudio = false;

    public GameObject canvas_a;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        audioAperturaPorte = GameObject.FindGameObjectWithTag("audioPortaBanca").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canvas_a.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        canvas_a.SetActive(false);
    }
   

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasUSB = inventory.listInventoryItems.Contains("USB");
            Debug.Log("onstay");
        }
        if (hasUSB && (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions")))
        {
            Debug.Log("haiusb");
            audioAperturaPorte.Play();
            triggerAudio = true;
            
            if (triggerAudio)
            {
                FindObjectOfType<Energy>().UseEnrgy();
                FindObjectOfType<LevelLoader>().LoadNextLevelBank();
            }
        }
        if(!hasUSB)
        {
            canvas_a.SetActive(false);
        }
    }
    private void Update()
    {
        hasmoney = inventory.listInventoryItems.Contains("money");
        if (hasmoney)
        {
            Banca.SetActive(true);
        }
    }
}
