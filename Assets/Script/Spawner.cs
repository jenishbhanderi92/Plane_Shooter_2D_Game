using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject []Enemy;
    public float spawnCount = 10f;
    public Transform t;
    public Pause GameController;
    private bool lastEnemy = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(E());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemy && FindObjectOfType<Enemy>() == null)
        {
            StartCoroutine(GameController.LevelComplete());
        }
        
    }

    void spawn()
    {
        int randomvalue = Random.Range(0, Enemy.Length);
        int rv = Random.Range(-2, 2);
        Instantiate(Enemy[randomvalue], new Vector2(rv,transform.position.y), Quaternion.identity);
    }

    

    IEnumerator E()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            yield return new WaitForSeconds(3f);
            spawn();
        }

        lastEnemy = true;
    }
}
