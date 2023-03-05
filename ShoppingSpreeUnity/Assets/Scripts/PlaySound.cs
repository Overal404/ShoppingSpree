using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaySound : MonoBehaviour {

        private static PlaySound instance = null;
        // TO DO: Acess paused bool from PauseHandler 
        // private bool LocalPaused = PauseHandler.paused;
        private bool LocalPaused = true;

        public static PlaySound Instance{
                get {return instance;}
        }

        void Awake(){
                if (instance != null && instance != this){
                        Destroy(this.gameObject);
                        return;
                } else {
                        instance = this;
                }
                if(LocalPaused){
                        PlaySound.Instance.gameObject.GetComponent<AudioSource>().Pause();
                }
        }
}
