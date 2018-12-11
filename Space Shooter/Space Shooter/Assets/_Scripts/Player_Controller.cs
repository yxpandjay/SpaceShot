using UnityEngine;
using System.Collections;

/***********************************************************************/
/**************************玩家函数**********************************/
/***********************************************************************/

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Player_Controller : MonoBehaviour
{
	public float speed;
    public float tilt;
    public Done_Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public GameObject explosion_player;
    private GameController_Sripts gameController;

    private void Start()
    {   //检测游戏主函数存在并且给出提示
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

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate ()
	{
        //pc键盘和移动端重力感应都可以用
		float moveHorizontal = Input.acceleration.x *3+Input.GetAxis("Horizontal");//
		float moveVertical = Input.acceleration.y *3+Input.GetAxis("Vertical");//

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
    }

    void OnTriggerEnter(Collider other)
    {   //游戏结束后不再发生碰撞事件
        if (gameController.gameover_flag_to_check == false)
        {
            if (other.tag == "Boundary")
            return;
            if (other.tag == "Bolt_enemy" || other.tag == "Asteroid" || other.tag == "Enemy" || other.tag == "Asteroid_big")
            {
                Instantiate(explosion_player, transform.position, transform.rotation);
                Destroy(gameObject);
                gameController.Game_Over();
            }
            
        }
            
    }
}
