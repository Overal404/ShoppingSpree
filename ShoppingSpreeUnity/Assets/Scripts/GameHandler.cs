using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

    void Update() {
        
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
}