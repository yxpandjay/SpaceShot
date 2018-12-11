using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***********************************************************************/
/**************************爆炸效果随时间消失***************************/
/***********************************************************************/
public class DestoryByTime : MonoBehaviour {
    public float Life_time;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, Life_time);
	}
	
	
}