using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;
    public GameObject explosion_player;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        if (other.tag == "Player")
        {
            Instantiate(explosion_player, transform.position, transform.rotation);
            gameController.Game_Over();
        }
        else
            gameController.Add_score(score);
        Instantiate(explosion_stone, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }


}
