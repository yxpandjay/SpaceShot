using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Script : MonoBehaviour
{

    public float speed;
    public GameObject explosion_player;
    public GameObject explosion_stone;
    
    private GameController_Sripts gameController;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        if (other.tag == "Player")
        {
            Instantiate(explosion_player, transform.position, transform.rotation);
            gameController.Game_Over();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}