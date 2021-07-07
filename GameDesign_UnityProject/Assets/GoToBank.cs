using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBank : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LevelLoader>().LoadNextLevelBank();
    }
}
