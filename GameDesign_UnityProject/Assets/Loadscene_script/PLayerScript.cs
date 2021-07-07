using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerScript : MonoBehaviour
{
    public static PLayerScript instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
