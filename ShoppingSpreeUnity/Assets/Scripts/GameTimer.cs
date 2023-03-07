using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour {
       public int timer = 0;
       private float theTimer = 0f;
       public GameObject timerText;

       void FixedUpdate(){
              theTimer += 0.01f;
              if (theTimer >= 1f){
                     timer -=1;
                     theTimer = 0;
                     UpdateTimer();
              }
      }

      public void UpdateTimer(){
            TMP_Text timeTextTemp = timerText.GetComponent<TMP_Text>();
            timeTextTemp.text = "" + timer;
      }
}
