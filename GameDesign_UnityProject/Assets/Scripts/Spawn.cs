using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;

    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    /*public void SpawnDroppedItem()
    {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
        Instantiate(item, playerPos, Quaternion.identity);
    }*/

    /*public void GetInfoItem()
    {
        Debug.Log(item.name); // item.name mi restituisce il nome del gameObject presente in scena che tiro su
        switch (item.name)
        {
            case "spPickUpDrop":
                Debug.Log("Questa è una sfera");
                txtInfoSfera.SetActive(true);
                txtInfoCartello.SetActive(false);
                break;
            case "CartelloV1.2":
                Debug.Log("Questo è un cartello");
                txtInfoSfera.SetActive(false);
                txtInfoCartello.SetActive(true);
                break;
            default:
                Debug.Log("Seleziona un oggetto");
                break;
        }
    }*/

    public string GetInfoItem()
    {
        return (item.name);
    }
}

/*
perchè funzioni devo mettere lo script "Spawn.cs" nell'immagine UI che uso nell'inventario per rappresentare il gameObject raccolto in scena
e come parametro dello script ci devo mettere il prefab da "Project" dell'oggetto stesso
*/