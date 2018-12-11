using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {

    //config params
    static bool isTalking = false;
    string characterName;
    string dialogueString;


    [SerializeField] TextAsset textFile;
    [SerializeField] TextMeshProUGUI characterNameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    // cached refs
    PlayerMovement playerMovement;


    // Use this for initialization
    void Start () {
        playerMovement = FindObjectOfType<PlayerMovement>();
        
        
    }
	
	// Update is called once per frame
	void Update () {

		if (!isTalking)
        { 
            playerMovement.Move();
        }
	}

    public void IsTalkingChecked()
    {
        isTalking = true;
        GetNewLines();
        SetNameAndText();

    }

    private void SetNameAndText()
    {
        characterNameText.text = characterName;
        dialogueText.text = dialogueString;
    }

    public void GetNewLines()
    {
        List<string> lines = textFile.text.Split('\n').ToList<string>();
        Debug.Log(lines[0]);
        Debug.Log(lines.Count());
         
        for (int i = 0; i < lines.Count; i++)
        {
            List<string> nameAndText = lines[i].Split(';').ToList<string>();
            
            characterName = nameAndText[0];
            dialogueString = nameAndText[1];
            nameAndText.Clear();
            
        }
    }
}
