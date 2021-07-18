using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Energy : MonoBehaviour
{
    [SerializeField] 
    Text energyText;
    [SerializeField] 
    Text timerText;
    [SerializeField] 
    Slider energybar;

    


    // private Inventory inventory;
    public List<string> checklist = new List<string>();

    public GameObject canvas;

    public GameObject Chiosco;
    public GameObject Garage;

    private int maxEnergy = 5;
    private int currentEnergy;
    private int restoreDuration = 10;
    private DateTime nextEnergyTime;
    private DateTime lastEnergyTime;
    private bool isRestoring = false;

    public GameObject endcanvas;


    private void Start()
    {
        
        if (!PlayerPrefs.HasKey("currentEnergy"))
        {
            PlayerPrefs.SetInt("currentEnergy", 5);
            Load();
            StartCoroutine(RestoreEnergy());
        }
        else
        {
            Load();
            StartCoroutine(RestoreEnergy());
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UseEnrgy();
            
        }
    }

    public void UseEnrgy()
    {
        if (currentEnergy >= 1)
        {
            currentEnergy--;
            UpdateEnergy();

            if (isRestoring == false)
            {
                if(currentEnergy+1 == maxEnergy)
                {
                    nextEnergyTime = addDuration(DateTime.Now, restoreDuration);
                }
                StartCoroutine(RestoreEnergy());

            }
        }
        else
        {
            Debug.Log("insufficient Energy!!");
            endcanvas.SetActive(true);
            StartCoroutine(endenergy());
           
        }
    }
    public void UseEnrgy4()
    {
        if (currentEnergy >= 1)
        {
            
            currentEnergy = -1;
            UpdateEnergy();

            if (isRestoring == false)
            {
                if (currentEnergy + 1 == maxEnergy)
                {
                    nextEnergyTime = addDuration(DateTime.Now, restoreDuration);
                }
                StartCoroutine(RestoreEnergy());

            }
        }
        else 
        {
            Debug.Log("insufficient Energy!!");
            endcanvas.SetActive(true);
            StartCoroutine(endenergy());

        }
    }

    private IEnumerator RestoreEnergy()
    {
        UpdateEnergyTimer();
        isRestoring = true;

        while (currentEnergy < maxEnergy)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextEnergyTime;
            bool isEnergyAdding = false;

            while (currentDateTime > nextDateTime)
            {
                if (currentEnergy < maxEnergy)
                {
                    isEnergyAdding = true;
                    currentEnergy++;
                    UpdateEnergy();
                    DateTime timeToAdd = lastEnergyTime > nextDateTime ? lastEnergyTime : nextDateTime;
                    nextDateTime = addDuration(timeToAdd, restoreDuration);
                }
                else
                {
                    break;
                }
            }
            if (isEnergyAdding == true)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextDateTime;
            }

            UpdateEnergyTimer();
            UpdateEnergy();
            Save();
            yield return null;



        }

        isRestoring = false;

    }
    
    private DateTime addDuration(DateTime datetime, int duration)
    {
       //return datetime.AddMinutes(duration);
        return datetime.AddSeconds(duration);
    }

    private void UpdateEnergy()
    {
        energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
        energybar.maxValue = maxEnergy;
        energybar.value = currentEnergy;
    }
    private void UpdateEnergyTimer()
    {
        if(currentEnergy>= maxEnergy)
        {
            timerText.text = "Full";
            return;
        }

        TimeSpan time = nextEnergyTime - DateTime.Now;
        string timeValue = String.Format("{0:D2}:{1:D1}", time.Minutes, time.Seconds);
        timerText.text = timeValue;
    }

    private DateTime StringToDate(string datetime)
    {
        if (string.IsNullOrEmpty(datetime))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(datetime);
        }
    }

    private void Load()
    {
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        lastEnergyTime = StringToDate(PlayerPrefs.GetString("lastEnergyTime"));
    }
    private void Save()
    {
        PlayerPrefs.SetInt("currentEnergy", currentEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastEnerguTime", lastEnergyTime.ToString());
    }

    public void check()
    {
        if (currentEnergy < 2)
        {

            
            FindObjectOfType<Dialog_trigger>().TriggerDialogue2();
            Debug.Log("NonHaiEnergia");

        }
        else
        {
            
            FindObjectOfType<Dialog_trigger>().TriggerDialogue3();
            
            UseEnrgy();
            UseEnrgy();
            
            Debug.Log("HaiEnergia");

        }
    }
    public void checkFinal()
    {
        if (currentEnergy == 5)
        {

            UseEnrgy4();
            Chiosco.GetComponent<needEnergy>().enabled = false;

            Debug.Log("HaiEnergiaend");
        }
        else if (currentEnergy >= 0 && currentEnergy < 5)
        {

            FindObjectOfType<InfoOBJ_trigger>().TriggerDialogue();
            Debug.Log("NonHaiEnergiaend");
            canvas.SetActive(true);
            

        }
    }

    public IEnumerator endenergy()
    {
        yield return new WaitForSeconds(3f);
        endcanvas.SetActive(false);

    }
}
