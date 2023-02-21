using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoooom : MonoBehaviour {

       public float thrust = 100f;
       private Rigidbody rb;

       void Start () {
             rb = GetComponent<Rigidbody>();
       }

       void FixedUpdate() {
             rb.AddForce(transform.forward * thrust);
       }
}
