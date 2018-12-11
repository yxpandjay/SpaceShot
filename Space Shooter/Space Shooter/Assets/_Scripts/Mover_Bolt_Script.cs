using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***********************************************************************/
/**************************玩家子弹函数**********************************/
/***********************************************************************/
public class Mover_Bolt_Script : MonoBehaviour
{

    public float speed;
    private GameController_Sripts gameController;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
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
    {
        //游戏结束后不再发生碰撞事件
        if (gameController.gameover_flag_to_check == false)
        {
            if (other.tag == "Boundary")
            return;
  
            if(other.tag == "Asteroid"|| other.tag == "Enemy" || other.tag == "Asteroid_big")
            Destroy(gameObject);
        }
            
        
    }

}