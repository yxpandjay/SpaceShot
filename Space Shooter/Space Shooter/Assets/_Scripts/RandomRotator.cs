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
                //产生两个陨石，第一个陨石产生位置是碰撞点，碰触方向是两个碰撞体中心连线
                //第二个陨石的位置和第一个陨石分别在大陨石的两边
                Quaternion face_to_other_quaternion = Quaternion.LookRotation(transform.position - other.transform.position);
                GameObject first_stone= Instantiate(Stone, other.transform.position, face_to_other_quaternion);
                face_to_other_quaternion = Quaternion.LookRotation(other.transform.position - transform.position );
                Instantiate(Stone, other.transform.position+ first_stone.transform.forward*2, face_to_other_quaternion);
                //              Vector3  vector3 = new  Vector3 (other.transform.position.x,0, other.transform.position.z);
                //              Instantiate(Stone, vector3, transform.rotation);
            }
            Instantiate(explosion_stone, transform.position, transform.rotation);
            Destroy(gameObject);
        }
           
    }


}
