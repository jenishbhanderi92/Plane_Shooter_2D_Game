using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }
}
