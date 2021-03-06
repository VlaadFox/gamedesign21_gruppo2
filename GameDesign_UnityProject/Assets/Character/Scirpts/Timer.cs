using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeValue = 90;
    public Text timerText;
    public bool timerIsRunning = false;

    public GameObject canvasendgame;

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
                if (timeValue < 5)
                {
                    GetComponent<Text>().color = Color.red;
                }
            }
            else
            {
                Debug.Log("Tempo finito");
                //npcON();
                timeValue = 0;
                //timeValue += 90;
                timerIsRunning = false;
                canvasendgame.SetActive(true);
               StartCoroutine( EndGame());
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
        //float milliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /*public void npcON()
    {
        npc.SetActive(true);
    }*/
    
    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("_StartMenu"); 
    }
}
