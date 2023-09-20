using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    Transform playerTransform;
    Vector3 offset_vec;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; 
        offset_vec = transform.position - playerTransform.position;
    }
    void LateUpdate()
{
transform.position = playerTransform.position + offset_vec; }
    }
