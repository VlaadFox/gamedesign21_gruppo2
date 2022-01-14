using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryShowUI : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject inventoryMenuUI;
    public GameObject playerController;
    public GameObject canvasMenuPausa;
    public GameObject canvasMiniMap;
    public GameObject emptyTexts;
    public GameObject firstButtonInventory;

    private Inventory inventory;
    private bool hasWrench = false;
    private bool hasEnter = false;
    private bool hasUSB = false;
    private bool hasCoin = false;
    private bool hasmoney = false;


    public GameObject textMissioneDog_red;
    public GameObject textMissioneDog_green;

    public GameObject textMissioneOil_red;
    public GameObject textMissioneOil_green;
    public GameObject textMissioneOil_dom;
    public GameObject textMissioneUsb_red;
    public GameObject textMissioneUsb_green;
    public GameObject textMissioneUsb_dom;
    public GameObject textMissioneMole_red;
    public GameObject textMissioneMole_green;

    void Start()
    {
        inventoryMenuUI.SetActive(false);
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetButtonDown("Inventario"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        /*if (GameIsPaused && Input.GetKeyDown(KeyCode.Escape))
            Resume();*/
    }

    //

    public void Resume()
    {
        inventoryMenuUI.SetActive(false);
        emptyTexts.SetActive(false);
        canvasMenuPausa.SetActive(true);
        canvasMiniMap.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //AudioListener.pause = false; utile se mettiamo musica/audio
        Cursor.visible = false;
        playerController.GetComponent<CharacterController>().enabled = true;
    }

    void Pause()
    {
        inventoryMenuUI.SetActive(true);
        canvasMenuPausa.SetActive(false);
        canvasMiniMap.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //AudioListener.pause = true; utile se mettiamo musica/audio
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.GetComponent<CharacterController>().enabled = false;

        if(hasWrench = inventory.listInventoryItems.Contains("Wrench"))
        {
            textMissioneOil_green.SetActive(true);
            textMissioneOil_red.SetActive(false);
        }

        if(hasEnter = inventory.listInventoryItems.Contains("entrato"))
        {
            textMissioneDog_green.SetActive(true);
            textMissioneDog_red.SetActive(false);
        }

        if(hasmoney = inventory.listInventoryItems.Contains("money"))
        {
            textMissioneUsb_green.SetActive(true);
            textMissioneUsb_red.SetActive(false);
        }
        if (hasUSB = inventory.listInventoryItems.Contains("USB"))
        {
            textMissioneUsb_red.SetActive(true);
            textMissioneUsb_dom.SetActive(false);
        }
        if (hasCoin = inventory.listInventoryItems.Contains("ToretCoin"))
        {
            textMissioneOil_red.SetActive(true);
            textMissioneOil_dom.SetActive(false);
        }
       

        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(firstButtonInventory);
    }
}
