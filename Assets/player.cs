using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    Rigidbody rigid;
    public float JumpPower;
    bool isJump = false;

    AudioSource item_audio;
    public Manager game_manager;
    
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        item_audio = GetComponent<AudioSource>();
       
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            Vector3 vec = new Vector3(0, JumpPower, 0);
            rigid.AddForce(vec, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, 0, v);
        rigid.AddForce(vec, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "floor")
        {
            isJump = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
     
        if (other.tag == "Finish")
        {
            if (game_manager.itemCount == game_manager.totalItemCount)
            {
                if (game_manager.stage == 2)
                {
                    SceneManager.LoadScene("game1");
                }
                else
                {
                    game_manager.stage++;
                    SceneManager.LoadScene("game" + game_manager.stage);
                }
            }
            else
            {
                SceneManager.LoadScene("game" + game_manager.stage);
            }
        }
    }
}