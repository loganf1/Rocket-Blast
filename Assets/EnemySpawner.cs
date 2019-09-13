using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bird;
    public GameObject rocket;
    public GameObject[] clones;
    private System.Random gen = new System.Random();
    private float lastSpawnTime, lastDestroyTime;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = 0;
        lastDestroyTime = 0;
        index = 0;
        clones = new GameObject[10000];
    }

    // Update is called once per frame
    void Update()
    {
        float lastTime = Time.deltaTime;
        lastSpawnTime += lastTime;
        lastDestroyTime += lastTime;

        if (lastSpawnTime > 3)
        {
            int xPos = gen.Next(-4, 5) ;
            Vector3 translate = new Vector3(xPos, 10, 0);
            clones[index++] = (Instantiate(bird, rocket.transform.position + translate, transform.rotation));
            lastSpawnTime = 0;
        }
        
        if (lastDestroyTime > 5)
        {
            for (int i = 0; i < index - 1; i++)
            {
                if (clones[i] != null && clones[i].transform.position.y < rocket.transform.position.y - 20)
                {
                    GameObject g = clones[i];
                    clones[i] = null;
                    Destroy(g);
                }
            }
            lastDestroyTime = 0;
        }
        
    }
}
