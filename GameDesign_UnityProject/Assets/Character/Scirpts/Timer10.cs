using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer10 : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeValue = 90;
    public Text timerText;
    public bool timerIsRunning = false;

    //[SerializeField] private GameObject npc;

    private void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
                if (timeValue < 300)
                {
                    GetComponent<Text>().color = Color.red;
                }
            }
            else
            {
                Debug.Log("Tempo finito");
                //npcON();
                FindObjectOfType<LevelLoader>().LoadNextLevelMenu();
                timeValue = 0;
                //timeValue += 90;
                timerIsRunning = false;
            }
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    /*public void npcON()
    {
        npc.SetActive(true);
    }*/
}
