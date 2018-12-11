using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Dialogue : MonoBehaviour {

    //config params
    static bool isTalking = false;
    


    [SerializeField] TextAsset textFile;
    

    // cached refs
    PlayerMovement playerMovement;


    // Use this for initialization
    void Start () {
        playerMovement = FindObjectOfType<PlayerMovement>();
        
        
    }
	
	// Update is called once per frame
	void Update () {

		if (isTalking)
        {
            
        }
        else
        {
            playerMovement.Move();
        }
	}

    public void IsTalkingChecked()
    {
        isTalking = true;
        GetNewLines();
    }

    public void GetNewLines()
    {
        string[] lines = textFile.text.Split('\n');
        //Debug.Log(lines.Length);
         
        for (int i = 0; i < lines.Length; i++)
        {
            Debug.Log(lines[i]);
        }
    }
}
