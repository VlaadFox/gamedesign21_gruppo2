using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class energy2 : MonoBehaviour
{



    public GameObject CameraChiosco;
    public GameObject luceChiosco;
    public GameObject luceraggio;
    public GameObject raggioChiosco;
    public GameObject raggioChioscodef;

    public GameObject CameraGa;

    public GameObject luceraggio2;
    public GameObject raggioGa;
    public GameObject raggioGadef;


    // private Inventory inventory;
    public List<string> checklist = new List<string>();

    public GameObject canvas;
    public GameObject canvasdel;

    private Inventory inventory;

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
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (!PlayerPrefs.HasKey("currentEnergy"))
        {
            PlayerPrefs.SetInt("currentEnergy", 5);
            Load();

        }
        else
        {
            Load();

        }
    }
    private void Update()
    {
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
    }










    private void Load()
    {
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");

    }


    public bool checkFinal()
    {
        if (currentEnergy == 5)
        {
            //FindObjectOfType<Energy>().UseEnrgy4();
            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<Energy>().UseEnrgy();


            //UseEnrgy4();
            secondo();
            canvas.SetActive(false);
            canvasdel.SetActive(false);
            // secondo();
            CameraChiosco.SetActive(true);
            luceChiosco.SetActive(true);

            raggioChiosco.SetActive(true);
            StartCoroutine(finisccutChiosco());

            Debug.Log("cutscene");

            Debug.Log("HaiEnergiaend");
            return true;
        }
        else if (currentEnergy >= 0 && currentEnergy < 5)
        {


            Debug.Log("NonHaiEnergiaend");
            canvas.SetActive(true);

            return false;
        }
        else
        {
            return false;
        }
    }


    public bool checkFinal2()
    {
        if (currentEnergy == 5)
        {
            FindObjectOfType<Energy>().UseEnrgy4();
            // UseEnrgy4();
            primo();
            canvas.SetActive(false);
            canvasdel.SetActive(false);
            // secondo();
            CameraGa.SetActive(true);


            raggioGa.SetActive(true);
            StartCoroutine(finisccutGarage());

            Debug.Log("cutscene");

            Debug.Log("HaiEnergiaend");
            return true;
        }
        else if (currentEnergy >= 0 && currentEnergy < 5)
        {


            Debug.Log("NonHaiEnergiaend");
            canvas.SetActive(true);

            return false;
        }
        else
        {
            return false;
        }
    }

    IEnumerator finisccutChiosco()
    {
        yield return new WaitForSeconds(4);
        luceraggio.SetActive(true);
        CameraChiosco.SetActive(false);
        luceChiosco.SetActive(false);
        raggioChiosco.SetActive(false);
        raggioChioscodef.SetActive(true);



    }

    public GameObject cameratombino;
    public GameObject lighttombino;
    public GameObject lighttombinodef;
    IEnumerator finisccutGarage()
    {
        yield return new WaitForSeconds(3);


        luceraggio2.SetActive(true);
        CameraGa.SetActive(false);
        raggioGa.SetActive(false);
        raggioGadef.SetActive(true);
        cameratombino.SetActive(true);
        lighttombino.SetActive(true);
        StartCoroutine(finisccutGarage2());

    }
    IEnumerator finisccutGarage2()
    {
        yield return new WaitForSeconds(4);



        cameratombino.SetActive(false);
        lighttombino.SetActive(false);
        lighttombinodef.SetActive(true);

    }

    public IEnumerator endenergy()
    {
        yield return new WaitForSeconds(3f);
        endcanvas.SetActive(false);

    }
    public void primo()
    {

        inventory.listInventoryItems.Add("primo");
        Debug.Log("primo fatto");

    }
    public void secondo()
    {

        inventory.listInventoryItems.Add("secondo");
        Debug.Log("secondo fatto");

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
            FindObjectOfType<Dialog_trigger>().Scale();

            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<Energy>().UseEnrgy();


            Debug.Log("HaiEnergia");

        }
    }
}
