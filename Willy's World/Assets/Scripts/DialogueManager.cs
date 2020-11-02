using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public int secondsToWait;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    private void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start of conversation");

        animator.SetBool("isOpen", true);
        
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
        Debug.Log("DisplayNextSentence triggered " + sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StartCoroutine(WaitForSec());
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");
        animator.SetBool("isOpen", false);
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(secondsToWait);
        Debug.Log("End of conversation");
        DisplayNextSentence();
    }
}
