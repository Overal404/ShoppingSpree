using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseSound : MonoBehaviour {

        private static PauseSound instance = null;
        // TO DO: Acess paused bool from PauseHandler 
        // private bool LocalPaused = PauseHandler.paused;
        private bool LocalPaused = true;

        public static PauseSound Instance{
                get {return instance;}
        }

        void Awake(){
                if (instance != null && instance != this){
                        Destroy(this.gameObject);
                        return;
                } else {
                        instance = this;
                }
                if(! LocalPaused){
                        PlaySound.Instance.gameObject.GetComponent<AudioSource>().Pause();
                } 
                
        }
}
