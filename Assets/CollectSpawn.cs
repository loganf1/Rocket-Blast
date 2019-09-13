using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawn : MonoBehaviour
{
    public GameObject fuel;
    public GameObject coin;
    public GameObject repair;
    public GameObject rocket;

    private System.Random gen = new System.Random();
    private System.Random choose = new System.Random();
    public GameObject[] clones;
    private float lastSpawnTimeCoin, lastSpawnTimeFuel, lastSpawnTimeRepair, lastDestroyTime;
    private int index;

    int pick;
    int xPos;
    int yPos;
    Vector3 translate;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTimeCoin = 0;
        lastSpawnTimeFuel = 0;
        lastSpawnTimeRepair = 0;
        lastDestroyTime = 0;
        index = 0;
        clones = new GameObject[10000];
    }

    // Update is called once per frame
    void Update()
    {
        float lastTime = Time.deltaTime;
        lastSpawnTimeCoin += lastTime;
        lastSpawnTimeFuel += lastTime;
        lastSpawnTimeRepair += lastTime;
        lastDestroyTime += lastTime;
        pick = choose.Next(0, 3);

        if(pick == 0) 
        {
            if (lastSpawnTimeCoin > 10)
            {
                xPos = gen.Next(-9, 10);
                yPos = gen.Next(10, 20);
                translate = new Vector3(xPos, yPos, 0);
                clones[index++] = Instantiate(coin, rocket.transform.position + translate, transform.rotation);
                lastSpawnTimeCoin -= 2;
            }
        }
        else if(pick == 1) 
        {
            if (lastSpawnTimeRepair > 20)
            {
                xPos = gen.Next(-9, 10);
                yPos = gen.Next(10, 20);
                translate = new Vector3(xPos, yPos, 0);
                clones[index++] = Instantiate(repair, rocket.transform.position + translate, transform.rotation);
                lastSpawnTimeRepair -= 3;
            }
        }
        else 
        {
            if (lastSpawnTimeFuel > 10)
            {
                xPos = gen.Next(-9, 10);
                yPos = gen.Next(10, 20);
                translate = new Vector3(xPos, yPos, 0);
                clones[index++] =  Instantiate(fuel, rocket.transform.position + translate, transform.rotation);
                lastSpawnTimeFuel -= 1;
            }
        }

        if (lastDestroyTime > 10)
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
