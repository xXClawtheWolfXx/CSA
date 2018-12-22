using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    int currentScene = 0;
    
    public void LoadNextScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene += 1;
        SceneManager.LoadScene(currentScene);

    }
    
}
