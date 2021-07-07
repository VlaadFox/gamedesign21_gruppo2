using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transistion;

   public void LoadNextLevelRoom()
    {
       StartCoroutine( LoadLevel(2));
    }
    public void LoadNextLevelTurin()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadNextLevelBank()
    {
        StartCoroutine(LoadLevel(3));
    }
    public void LoadNextLevelSott()
    {
        StartCoroutine(LoadLevel(4));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transistion.SetTrigger("start");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}


