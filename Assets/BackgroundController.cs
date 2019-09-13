using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject rocket;
    public Image m_Image;
    public Sprite m_Sprite;
    bool doOnce = true;

    void Start()
    {
        m_Image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(rocket.transform.position.x, rocket.transform.position.y, transform.position.z);
        if (rocket.transform.position.y > 100 && doOnce)
        {
            m_Image.sprite = m_Sprite;
            transform.position += new Vector3(0, 100, 0);
            doOnce = false;
        }
    }
}