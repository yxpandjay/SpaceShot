﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Script : MonoBehaviour
{

    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
    //    if (other.tag == "Player"|| other.tag == "Asteroid" || other.tag == "Enemy")
        if(other.tag == "Asteroid"|| other.tag == "Enemy")
         Destroy(gameObject);
        
    }

}