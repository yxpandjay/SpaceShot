using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_Sripts : MonoBehaviour {

    public GameObject Stone;
    public GameObject Ememy;
    public Vector3 Spawn_value;
    public int Stone_ememy_count;
    public float Spawn_wait_time;
    public float Start_wait_time;
    public float Waves_wait_time;

    private int score;
    public Text Score_text;

    public Text Gameover_text;
    private bool gameover_flag;

    public Text Restart_text;
    private bool restart_flag;
    // Use this for initialization
    void Start () {

        score = 0;
        gameover_flag = false;
        Gameover_text.text = "";
        restart_flag = false;
        Restart_text.text = "";
        Updata_score();
        StartCoroutine (Waves());

    }

    private void Update()
    {
        if (restart_flag)
        {
            if (Input.GetKeyDown(KeyCode.R)||(Input.GetTouch(0).phase==TouchPhase.Began&&Input.touchCount>0))//多点触控发生，且点击事件为开始
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator Waves()
    {
        yield return new WaitForSeconds(Start_wait_time);
        while (true)
        {
            for (int i = 0; i < Stone_ememy_count; i++)
            {
                Vector3 Spawn_position = new Vector3(Random.Range(-Spawn_value.x, Spawn_value.x),
                    Spawn_value.y, Spawn_value.z);
                Quaternion Spawn_rotation = Quaternion.identity;
                if(i%3==0) Instantiate(Ememy, Spawn_position, Spawn_rotation);
                else Instantiate(Stone, Spawn_position, Spawn_rotation);
                yield return new WaitForSeconds(Spawn_wait_time);

                if (gameover_flag)
                {
                    restart_flag = true;
                    Restart_text.text = "Press 'R' to Restart";
                }
            }
            yield return new WaitForSeconds(Waves_wait_time);
        }
    }

    void Updata_score()
    {   
        Score_text.text = "Score: "+score;
    }
    public void Add_score (int Value)
    {
        score += Value;
        Updata_score();
    }

    public void Game_Over()
    {
        gameover_flag = true;
        Gameover_text.text = "Game Over";
    }


}
