using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***********************************************************************/
/**************************陨石移动**********************************/
/***********************************************************************/
public class Asteroid_mover : MonoBehaviour {
    public float speed;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
	
}
