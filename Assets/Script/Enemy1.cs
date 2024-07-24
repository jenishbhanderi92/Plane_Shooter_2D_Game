using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Camera cam;
    public GameObject Enemy1;
    public GameObject Gunshoot;
    public float Spawntime;
    public float Speed;
    public float time = 0.4f;
    public GameObject DieAnimation;
    public Transform []pos; // This is array
    public float Health = 10f;
    float Barsize = 1f;
    float Damege = 0;
    public HealthBar H;
    public GameObject DamageEffect;
    public GameObject coin;
    public AudioSource Audio;
    public AudioClip audioClip;
    public AudioClip DestoySound;
    // Start is called before the first frame update
    void Start()
    {
        Damege = Barsize / Health;
        StartCoroutine(Fire());
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag  == "BulletShot")
        {
            Audio.PlayOneShot(audioClip, 0.5f);
            DamageHelthbar();
            Destroy(collision.gameObject);
            GameObject r = Instantiate(DamageEffect, collision.transform.position, Quaternion.identity);
            Destroy(r,0.2f);
            if (Health <= 0)
            {
                AudioSource.PlayClipAtPoint(DestoySound, Camera.main.transform.position, 0.5f);
                GameObject et = Instantiate(coin, transform.position, Quaternion.identity);
                Destroy(Enemy1);
                GameObject e = Instantiate(DieAnimation, transform.position, Quaternion.identity);
                Destroy(e, time);   
            }
        }  
    }

    public void DamageHelthbar()
    {   
        if(Health > 0)
        {
            Health -= 1;
            Barsize = Barsize - Damege;
            H.a(Barsize);
        }
    }
    void add()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(Gunshoot, pos[i].position, Quaternion.identity);
        }
        
    }


    IEnumerator Fire()
    {
        Audio.Play();
        yield return new WaitForSeconds(Spawntime);
        add();
        StartCoroutine(Fire());
    }
}
