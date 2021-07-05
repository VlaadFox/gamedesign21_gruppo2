using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_manager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public GameObject canvas;
    public GameObject cliccaCanvas;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue (Dialogo_padre dialogue)
    {

        Debug.Log("Starting conversation with" + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }



    public void DisplayNextSentence()
    {
        if(sentences.Count== 0 )
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


   void EndDialogue()
   {
        Debug.Log("End conversation");
       canvas.SetActive(false);
       cliccaCanvas.SetActive(true);

    }

    
}