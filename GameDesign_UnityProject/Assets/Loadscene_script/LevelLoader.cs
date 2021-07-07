using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transistion;

   public void LoadNextLevel()
    {
       StartCoroutine( LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadNextLevel1()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transistion.SetTrigger("start");
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}


