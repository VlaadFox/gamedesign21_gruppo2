using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prova : MonoBehaviour
{
    private static Prova _instance;

    public static Prova Instance { get { return _instance; } }


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            //Debug.Log($"Distrutto player nella posizione {this.transform.position}");
        }
        else
        {
            _instance = this;
        }
    }
}
