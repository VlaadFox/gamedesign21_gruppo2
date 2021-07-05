using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_canvas : MonoBehaviour
{
    public GameObject canvas;

    public void delete()
    {
        canvas.SetActive(false);
    }
}
