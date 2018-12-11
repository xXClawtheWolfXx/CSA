using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hi : MonoBehaviour {

    [SerializeField] TMPro.TextMeshProUGUI Numtext;
    int number = 0;
	// Use this for initialization
	void Start () {
        Numtext.text = number.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseNumber()
    {

        number++;
        Numtext.text = number.ToString();
    }
}
