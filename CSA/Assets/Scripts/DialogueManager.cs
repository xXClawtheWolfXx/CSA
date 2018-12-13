using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {



    private Queue<string> sentences;

	// Use this for initialization
	void Start () {

        sentences = new Queue<string>();
	}
	
    public void StartDialouge()
    {
        sentences.Clear();

        foreach (string sentence in sentences )
        {

        }
    }
	
}
