using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {
    public GameObject textGameObject;
    private int counter;
    public int counterWin = 6;

    public float theTimer;
    public Text timerText;
    public float startTime = 45;

    public bool isEnd = true;

    void Start () {
          counter =0;
          UpdateCounter();
          theTimer = startTime;

          if (isEnd){
               Cursor.lockState = CursorLockMode.None;
               Cursor.visible = true;
          }
    }

    void Update () {

    }

    void FixedUpdate () {
        theTimer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Floor(theTimer);
        if ((theTimer <= 0) && (isEnd == false)){
            SceneManager.LoadScene ("EndLose");
        } else if (counter >= counterWin) {
            SceneManager.LoadScene("EndWin");
        }
    }

    public void AddCounter (int newCounterValue) {
          counter += newCounterValue;
          UpdateCounter();  
     }

    void UpdateCounter () {
           Text scoreTextB = textGameObject.GetComponent<Text>();
            scoreTextB.text = "Items: " + counter;
     }


    public void PlayAgain() {
        SceneManager.LoadScene("MiniGame");
        theTimer = startTime;
        counter = 0;
    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}