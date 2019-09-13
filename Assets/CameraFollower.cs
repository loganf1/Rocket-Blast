using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public GameObject rocket;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 2, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rocket.transform.position + offset;
    }
}
