using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Bullet;
    public Transform pos1;
    public Transform pos2;
    public GameObject flash;
    public AudioSource Audio;
    public float spawntime = 0.5f;

     
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Shoot()); // call Gunshoot
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fire()
    {
        Instantiate(Bullet, pos1.position, Quaternion.identity);
        
        Instantiate(Bullet, pos2.position, Quaternion.identity);
    }

    IEnumerator Shoot() //  same as method
    {
        Audio.Play();
        yield return new WaitForSeconds(spawntime); // For Delay 
        fire();
        flash.SetActive(true);
        yield return new WaitForSeconds(0.04f);
        flash.SetActive(false);
        StartCoroutine(Shoot()); // loop fire 
        
    }   

    // Second method for loop 

    /*  IEnumerator Gunshoot() 
    {
        yield return new WaitForSeconds(spawntime); 
        fire();
         while(true)
        {
            yield return new WaitForSeconds(spawntime); // For Delay 
            fire();
        }
       
    }
     */
}
