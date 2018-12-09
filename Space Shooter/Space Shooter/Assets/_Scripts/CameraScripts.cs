using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour {

    // Use this for initialization
    public Camera Main_camera;
    
    public float rate;
	void Start () {
        Main_camera = Camera.main;
        Main_camera.aspect = rate;

    }
	
	
}
