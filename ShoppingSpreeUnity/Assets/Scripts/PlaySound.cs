using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaySound : MonoBehaviour {

        public AudioSource play;
        public AudioSource pause;
        public bool LocalPaused = PauseHandler.paused;
 
        void Update() {
                LocalPaused = PauseHandler.paused;
                if(LocalPaused){
                        play.Pause();
                        pause.UnPause();
                } else {
                        play.UnPause();
                        pause.Pause();    
                }
        }
}
