using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toy_collectionable : MonoBehaviour
{
    private Inventory inventory;
    public GameObject imgUIInventarioGameboy;
    public GameObject canvas;
    public GameObject toy;
    private bool toys;
    



    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        toys = inventory.listInventoryItems.Contains("Gameboy");
        if (toys)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Interactions"))
        {
            Destroy(this);
              Destroy(toy);
              Gettoy();
            canvas.SetActive(false);
            FindObjectOfType<Feedbakinventory>().ToysFeed();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        canvas.SetActive(true);
    }
    private void OnTriggerExit(Collider collider)
    {
        canvas.SetActive(false);
    }
    public void Gettoy()
    {
       
        inventory.isFull[4] = true;
        Instantiate(imgUIInventarioGameboy, inventory.slots[4].transform, false);
        inventory.listInventoryItems.Add("Gameboy");
        Debug.Log("Ho ricevuto il gameboy");
        
    }
}
