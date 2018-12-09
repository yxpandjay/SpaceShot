using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Scripts : MonoBehaviour {

    public float Fire_rate_time;
    private float next_time;
    public GameObject Shot;
    public Transform Shot_spawn;
    public float Speed;

    public GameObject explosion_enemy;

    public int score;
    private GameController_Sripts gameController;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > next_time)
        {
            next_time += Fire_rate_time;
            Instantiate(Shot, Shot_spawn.position, Shot_spawn.rotation);

        }	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        if (other.tag == "Bolt" || other.tag == "Asteroid")
        {
            gameController.Add_score(score);
            Destroy(gameObject);
            Instantiate(explosion_enemy, transform.position, transform.rotation);
        }
    }
}
