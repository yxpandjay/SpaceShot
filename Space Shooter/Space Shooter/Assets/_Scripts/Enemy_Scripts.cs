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
    public GameObject explosion_stone;
 //   public int score;
 //   private GameController_Sripts gameController;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        if (other.tag == "Player")
        {
            Instantiate(explosion_enemy, transform.position, transform.rotation);
            //gameController.Game_Over();
        }
        else if(other.tag == "")
           // gameController.Add_score(score);
        Instantiate(explosion_stone, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
