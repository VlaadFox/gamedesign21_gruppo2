using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_OBJ : MonoBehaviour
{
   
    public Text dialogueText;

    public GameObject canvas;
    public GameObject cliccaCanvas;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogo_padre dialogue)
    {

        
       

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

   


    void EndDialogue()
    {
        Debug.Log("End conversation");
        canvas.SetActive(false);
        cliccaCanvas.SetActive(true);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)|| Input.GetButtonDown("Continua"))
        {
            DisplayNextSentence();
        }
    }
}
