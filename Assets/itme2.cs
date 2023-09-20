using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itme2 : MonoBehaviour
{

    AudioSource item_audio;

    Rigidbody rigid;
    void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        item_audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "player")
        {


            Destroy(gameObject);
        }

    }
}