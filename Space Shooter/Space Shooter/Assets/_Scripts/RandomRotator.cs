using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;
    public GameObject Stone;
    public GameObject explosion_stone;
    public int score;
    private GameController_Sripts gameController;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
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
            if (other.tag != "Player")
            {
               gameController.Add_score(score);
            }
            if (gameObject.tag == "Asteroid_big")
            {
                Instantiate(Stone, other.transform.position, Quaternion.identity);
  //              Vector3  vector3 = new  Vector3 (other.transform.position.x,0, other.transform.position.z);
  //              Instantiate(Stone, vector3, transform.rotation);
            }
            Instantiate(explosion_stone, transform.position, transform.rotation);
            Destroy(gameObject);
        }
           
    }


}
