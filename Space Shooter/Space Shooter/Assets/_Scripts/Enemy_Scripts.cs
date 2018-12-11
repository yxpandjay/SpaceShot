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
    public GameObject Player_object;

    public int score;
    private GameController_Sripts gameController;

    private void Start()
    {

        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController_Sripts>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' scripts");
        }
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > next_time)
        {
            next_time += Fire_rate_time;
            Instantiate(Shot, Shot_spawn.position, Shot_spawn.rotation);

        }
        //朝向玩家的四元数
        Quaternion face_to_player_quaternion = Quaternion.LookRotation(transform.position-Player_object.transform.position );
        transform.rotation = face_to_player_quaternion;

    }

    void OnTriggerEnter(Collider other)
    {
        if (gameController.gameover_flag_to_check == false)
        {
            if (other.tag == "Boundary")
                return;
            if (other.tag != "Bolt_enemy")
            {
                if (other.tag != "Player")
                    gameController.Add_score(score);
                Destroy(gameObject);
                Instantiate(explosion_enemy, transform.position, transform.rotation);
            }
        }
    }
}
