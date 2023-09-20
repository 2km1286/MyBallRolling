using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    AudioSource item_audio;

    public float rotateSpeed;
    Rigidbody rigid;
    public int randomSpeed;
    void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        item_audio = GetComponent<AudioSource>();
        Invoke("Self_Move", 1);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "player")
        {


            Destroy(gameObject);
        }

    }


    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }


    void FixedUpdate()
    {
        rigid.velocity = new Vector2(randomSpeed, rigid.velocity.y);
        Vector2 front = new Vector2(rigid.position.x + randomSpeed * 0.4f, rigid.position.y);
        bool isNotFall = Physics2D.Raycast(front, Vector2.down, 1);

        if (!isNotFall)
            randomSpeed = -1 * randomSpeed;

    }
    void Self_Move()
    {
        randomSpeed = Random.Range(-2, 3);
        Invoke("Self_Move", 2);
    }
}