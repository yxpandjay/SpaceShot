using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***********************************************************************/
/**************************敌军主函数**********************************/
/***********************************************************************/
public class Enemy_Scripts : MonoBehaviour {

    public float Fire_rate_time;
    private float next_time;
    public GameObject Shot;
    public Transform Shot_spawn;
    public float Speed;

    public GameObject explosion_enemy;
 //   public GameObject Player_object;

    public int score;
    private GameController_Sripts gameController;

    private void Start()
    {

        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
        next_time = Time.time;
        //检测游戏主函数存在并且给出提示
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
            //朝向玩家的四元数
            GameObject Player_object=GameObject.Find("Player");
            Quaternion face_to_player_quaternion = Quaternion.LookRotation(transform.position-Player_object.transform.position );
            transform.rotation = face_to_player_quaternion;
            Instantiate(Shot, Shot_spawn.position, Shot_spawn.rotation);


        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        //游戏结束后不再发生碰撞事件
        if (gameController.gameover_flag_to_check == false)
        {
            if (other.tag == "Boundary")
                return;
            if (other.tag != "Bolt_enemy")
            {
                //敌机本身与非玩家碰撞会加分
                if (other.tag != "Player")
                    gameController.Add_score(score);
                Destroy(gameObject);
                Instantiate(explosion_enemy, transform.position, transform.rotation);
            }
        }
    }
}
