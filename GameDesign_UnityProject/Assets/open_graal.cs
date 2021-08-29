using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_graal : MonoBehaviour
{
    public GameObject canvas;
    public GameObject canvas2;

    private bool dosecond;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);


    }
    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
        canvas2.SetActive(false);
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
            {
                dosecond = inventory.listInventoryItems.Contains("primo");
                if (dosecond)
                {
                    FindObjectOfType<LevelLoader>().LoadNextLevelMole();
                }
                if (!dosecond)
                {
                    canvas2.SetActive(true);
                }
            }
        }
    }
}

