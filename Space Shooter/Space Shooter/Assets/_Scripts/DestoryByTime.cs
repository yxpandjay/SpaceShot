using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {
    public float Life_time;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, Life_time);
	}
	
	
}