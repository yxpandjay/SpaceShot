using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***********************************************************************/
/**************************陨石主函数**********************************/
/***********************************************************************/
public class Asteroid_Scripts : MonoBehaviour {
    public float tumble;

    public GameObject Stone;
    public GameObject explosion_stone;
 

    public int score;

    private GameController_Sripts gameController;
    // Use this for initialization
    void Start () {
        
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
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



    void OnTriggerEnter(Collider other)
    {   //游戏结束后不再发生碰撞事件
        if (gameController.gameover_flag_to_check == false)
        {
            if (other.tag == "Boundary")
            return;
            if (other.tag != "Player")
            {
               gameController.Add_score(score);
            }
            //本函数为大小陨石通用，所以在这里判断是不是大陨石，来触发分裂效果
            if (gameObject.tag == "Asteroid_big")
            {
                //产生两个陨石，第一个陨石产生位置是碰撞点，碰触方向是两个碰撞体中心连线
                //第二个陨石的位置和第一个陨石分别在大陨石的两边，并且第二个陨石的位置源于第一个陨石和碰撞体
                Quaternion face_to_other_quaternion = Quaternion.LookRotation(transform.position - other.transform.position);
                //产生一个陨石并且返回第一个陨石的物体值
                GameObject first_stone= Instantiate(Stone, other.transform.position, face_to_other_quaternion);
                //得到第一个陨石的反方向来提供给第二个陨石
                face_to_other_quaternion = Quaternion.LookRotation(other.transform.position - transform.position );
                Instantiate(Stone, other.transform.position+ first_stone.transform.forward*2, face_to_other_quaternion);
               
            }
            Instantiate(explosion_stone, transform.position, transform.rotation);
            Destroy(gameObject);
        }
           
    }


}
