using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;

    public GameObject[] slots;

    public List<string> listInventoryItems = new List<string>(); 
}
