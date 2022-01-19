using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Delet_canvas_object : MonoBehaviour
{
    public GameObject canvas, continuebutton;


    public GameObject playerController;

    public void delete()
    {
        canvas.SetActive(false);
        continuebutton.SetActive(false);
        playerController.GetComponent<ThirdPersonController>().enabled = true;
        //Time.timeScale = 1f;
    }
    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player");
    }
}
