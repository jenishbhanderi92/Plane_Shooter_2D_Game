using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float Speed = 10f;
    public float add = 1.1885f;
    public float add2 = 0.9f;
    public float time = 2f;
    public GameObject Plan;
    public GameObject Blast;
    public GameObject Explosion;
    public Coincount Coinc;
    public Pause game;
    float Minx;
    float Maxx;
    float Miny;
    float Maxy;
    public PlayerHealthBar healthBar;
    public float Health = 10f;
    float BarAmount = 1f;
    float Damage = 0;
    public GameObject Dm;
    public AudioSource AudioSource;
    public AudioClip DamageSound;
    public AudioClip ExSound;
    public AudioClip CoinAudio;
  

    // Start is called before the first frame update
    void Start()
    {
            
        Damage = BarAmount / Health;
        findBoundries();
    }

    void findBoundries()
    {
        Camera cam = Camera.main;
        Minx = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + add;
        Maxx = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - add;
        Miny = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + add2;
        Maxy = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - add2;
    }

    // Update is called once per frame
    void Update()
    {
        /*float a = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float b = Mathf.Clamp(transform.position.x + a,Minx,Maxx);
        transform.position = new Vector2(b, transform.position.y);
       
        float c = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        float d = Mathf.Clamp(transform.position.y + c, Miny,Maxy);
        transform.position = new Vector2(transform.position.x, d);*/

        if(Input.GetMouseButton(0))
        {
           Vector2 NewPos =  Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
           transform.position = Vector2.Lerp(transform.position, NewPos, 10 * Time.deltaTime);
        }
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "EB")
        {
            AudioSource.PlayOneShot(DamageSound, 0.5f);
            PlayerHealthbar();
            Destroy(collision.gameObject);
            GameObject s =  Instantiate(Dm, collision.transform.position, Quaternion.identity);
            Destroy(s, 0.2f);
            
            if (BarAmount <= 0)
            {
                AudioSource.PlayClipAtPoint(ExSound, Camera.main.transform.position, 0.5f);
                game.Gameover();
                Destroy(gameObject);
                GameObject Blast = Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(Blast, 2f);   
            }
        }

        if(collision.gameObject.tag == "coin")
        {
            AudioSource.PlayClipAtPoint(CoinAudio, Camera.main.transform.position, 0.5f); 
            Destroy(collision.gameObject);
            Coinc.AddCount();
        }
            
    }

  void PlayerHealthbar()
  {
        if(BarAmount > 0)
        {
            Health -= 1;
            BarAmount -= Damage;
            healthBar.SetAmount(BarAmount);
        }
        
  }



}
