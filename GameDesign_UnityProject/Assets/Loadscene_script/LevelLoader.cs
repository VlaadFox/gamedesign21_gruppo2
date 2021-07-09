using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transistion;

   public void LoadNextLevelRoom()
    {
       StartCoroutine( LoadLevel("Room"));
    }
    public void LoadNextLevelTurin()
    {
        StartCoroutine(LoadLevel("ScenaPrincipale"));
    }
    public void LoadNextLevelBank()
    {
        StartCoroutine(LoadLevel("Banca"));
    }
    public void LoadNextLevelSott()
    {
        StartCoroutine(LoadLevel("Sotterraneo"));
    }
    IEnumerator LoadLevel(string name)
    {
        transistion.SetTrigger("start");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(name);
    }
}


