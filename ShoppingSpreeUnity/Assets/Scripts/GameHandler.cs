using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

    void Update() {
        //delete this quit functionality when a Pause Menu is added
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    /*
    void UpdateScore () {
        Text scoreTemp = textGameObject.GetComponent<Text>();
        scoreTemp.text = "Score: " + score;
    }
    */

    public void StartGame() {
        SceneManager.LoadScene("MiniGame");
    }

    public void RestartGame() {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}