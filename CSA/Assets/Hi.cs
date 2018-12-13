using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hi : MonoBehaviour {

    [SerializeField] TMPro.TextMeshProUGUI Numtext;
    int number = 0;


	void Start () {
        Numtext.text = number.ToString();
	}
	
	
	void Update () {
		
	}

    public void IncreaseNumber()
    {

        number++;
        Numtext.text = number.ToString();
    }
}
