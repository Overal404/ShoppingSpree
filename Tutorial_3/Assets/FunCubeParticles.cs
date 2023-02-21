using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunCubeParticles : MonoBehaviour{

       public GameObject impactParticles;
       public Vector3 SpawnParticlesHere;
       public GameObject newParticles;                            //#1

       void OnCollisionEnter(Collision other){
              //if the impact has enough force
              if (other.relativeVelocity.magnitude > 5) {
                     //get impact location
                     SpawnParticlesHere = other.contacts[0].point;
                     //make particles at that location
                     newParticles = Instantiate (impactParticles, SpawnParticlesHere, other.transform.rotation);                                                             //#2
                     StartCoroutine(DestroyPS(newParticles));   //#3
              }
       }

       IEnumerator DestroyPS(GameObject newPS){         //#4
             yield return new WaitForSeconds(3.0f);
             Destroy(newPS);
             }
}
