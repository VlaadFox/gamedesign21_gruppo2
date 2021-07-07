using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExit : MonoBehaviour
{
    public string exitName;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("LastExitName", exitName);
    }
}
