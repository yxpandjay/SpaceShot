using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Script : MonoBehaviour
{

    public float speed;
    private GameController_Sripts gameController;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

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

    void OnTriggerEnter(Collider other)
    {
        if (gameController.gameover_flag_to_check == false)
        {
            if (other.tag == "Boundary")
            return;
    //      if (other.tag == "Player"|| other.tag == "Asteroid" || other.tag == "Enemy")
            if(other.tag == "Asteroid"|| other.tag == "Enemy" || other.tag == "Asteroid_big")
            Destroy(gameObject);
        }
            
        
    }

}