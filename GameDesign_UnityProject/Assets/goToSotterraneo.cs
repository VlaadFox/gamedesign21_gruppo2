using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToSotterraneo : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvasOpen;
    private bool tombino = false;

    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        tombino = inventory.listInventoryItems.Contains("Tombino");
        if (tombino)
        {
            canvas.SetActive(true);
        }
        if (!tombino)
        {
            canvasOpen.SetActive(true);
        }
        


    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
        {

            if (tombino)
            {
                FindObjectOfType<LevelLoader>().LoadNextLevelSott();
            }

           
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        canvasOpen.SetActive(false);
    }
}
