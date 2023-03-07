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
        }
    }

    public void AddCounter (int newCounterValue) {
          // U prob wanna do logic here brendan, update counter takes care of
          // the UI so doint worry about that part

          // If the "checkout" object is triggered
          // Loop through the list of items
          // For each item, update the counter base on the value
          counter += newCounterValue;
          UpdateCounter();
           if (counter >= counterWin) {
              SceneManager.LoadScene("EndWin");
            }
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