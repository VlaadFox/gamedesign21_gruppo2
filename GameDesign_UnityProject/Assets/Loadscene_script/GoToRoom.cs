using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRoom : MonoBehaviour
{
    public GameObject DOG;
    public GameObject canvas_a;
    private Inventory inventory;
    private bool hasEnter = false;

    public  GameObject AudioCane;

    private AudioSource audioAperturaPorte;
    private bool triggerAudio = false;
    private void OnTriggerEnter(Collider other)
    {
        canvas_a.SetActive(true);
       // DOG.SetActive(true);

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
        {
            audioAperturaPorte.Play();
            triggerAudio = true;

            AudioCane.GetComponent<AudioSource>().enabled = false;
            
            if (triggerAudio)
            {
                FindObjectOfType<Energy>().UseEnrgy();
                FindObjectOfType<LevelLoader>().LoadNextLevelRoom();   
            }
           // FindObjectOfType<Dialog_trigger>().Getenter();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas_a.SetActive(false);
    }
    private void Update()
    {
        if(hasEnter = inventory.listInventoryItems.Contains("entrato"))
        {
            DOG.SetActive(true);
        }
    }
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        audioAperturaPorte = GameObject.FindGameObjectWithTag("audioPortaCane").GetComponent<AudioSource>();
    }

}

