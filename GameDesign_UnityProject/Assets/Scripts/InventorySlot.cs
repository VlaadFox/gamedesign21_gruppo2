using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    public GameObject emptyTexts;
    public GameObject txtInfoMoneta;
    public GameObject txtInfoUSB;
    public GameObject txtInfoLattinaLavori;
    public GameObject txtinfoLattinaEnergia;
    public GameObject txtInfoWrench;
    public GameObject txtInfoGameboy;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0) // mi serve per dichiarare che un determinato slot sia vuoto in modo da poter pickare oggetti dentro
        {
            inventory.isFull[i] = false;
        }
    }

    /*public void DropItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }*/

    public void InfoItem()
    {
        foreach (Transform child in transform)
        {   
            switch (child.GetComponent<Spawn>().item.name)
            {
                case "ToretCoin":
                    Debug.Log("moneta");
                    emptyTexts.SetActive(true);
                    txtInfoUSB.SetActive(false);
                    txtinfoLattinaEnergia.SetActive(false);
                    txtInfoLattinaLavori.SetActive(false);
                    txtInfoGameboy.SetActive(false);
                    txtInfoWrench.SetActive(false);
                    txtInfoMoneta.SetActive(true);
                    break;
                case "itemLattinaOlio":
                    Debug.Log("lattina olio");
                    emptyTexts.SetActive(true);
                    txtInfoUSB.SetActive(false);
                    txtinfoLattinaEnergia.SetActive(false);
                    txtInfoLattinaLavori.SetActive(true);
                    txtInfoGameboy.SetActive(false);
                    txtInfoWrench.SetActive(false);
                    txtInfoMoneta.SetActive(false);
                    break;
                case "itemLattinaEnergia":
                    Debug.Log("lattina olio");
                    emptyTexts.SetActive(true);
                    txtInfoUSB.SetActive(false);
                    txtinfoLattinaEnergia.SetActive(true);
                    txtInfoLattinaLavori.SetActive(false);
                    txtInfoGameboy.SetActive(false);
                    txtInfoWrench.SetActive(false);
                    txtInfoMoneta.SetActive(false);
                    break;
                case "itemUsb":
                    Debug.Log("lattina olio");
                    emptyTexts.SetActive(true);
                    txtInfoUSB.SetActive(true);
                    txtinfoLattinaEnergia.SetActive(false);
                    txtInfoLattinaLavori.SetActive(false);
                    txtInfoGameboy.SetActive(false);
                    txtInfoWrench.SetActive(false);
                    txtInfoMoneta.SetActive(false);
                    break;
                case "itemWrench":
                    Debug.Log("lattina olio");
                    emptyTexts.SetActive(true);
                    txtInfoUSB.SetActive(false);
                    txtinfoLattinaEnergia.SetActive(false);
                    txtInfoLattinaLavori.SetActive(false);
                    txtInfoGameboy.SetActive(false);
                    txtInfoWrench.SetActive(true);
                    txtInfoMoneta.SetActive(false);
                    break;    
                case "itemGameboy":
                    Debug.Log("lattina olio");
                    emptyTexts.SetActive(true);
                    txtInfoUSB.SetActive(false);
                    txtinfoLattinaEnergia.SetActive(false);
                    txtInfoLattinaLavori.SetActive(false);
                    txtInfoGameboy.SetActive(true);
                    txtInfoWrench.SetActive(false);
                    txtInfoMoneta.SetActive(false);
                    break; 
                default:
                    Debug.Log("Seleziona un oggetto");
                    break;
            }
        }
    }
}
