using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Save_position : MonoBehaviour
{
    public GameObject playeref;
    private GameObject player;

    private Vector3 pos;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playeref.transform.position = pos;
        pos = player.transform.position;
    }

}
