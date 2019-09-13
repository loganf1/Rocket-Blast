using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Transform ground;

    public Rigidbody2D rocket;
    public rocketHealth health;

    private float maxVelocityX = 2f;

    private float maxVelocityY = 4f;

    private float rotateSpeed = 0.5f;
   
    void Start()
    {
        rocket = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.UpArrow) && (health.fuel) > 0) {
            Thrust(yAxis);
        }
        
        Rotate(transform, xAxis * -rotateSpeed);
        ClampVelocity();
    }

    private void ClampVelocity() 
    {
        float x = Mathf.Clamp(rocket.velocity.x, -maxVelocityX, maxVelocityX);
        float y = Mathf.Clamp(rocket.velocity.y, -maxVelocityY, maxVelocityY);

        rocket.velocity = new Vector2(x, y);
    }

    private void Thrust(float amount) 
    {
        Vector2 force = transform.up * amount;

        rocket.AddForce(force);
    }

    private void Rotate(Transform t, float amount) 
    {
        t.Rotate(0, 0, amount);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == ("Coin"))
        {
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == ("Fuel")) 
        {
            Destroy(c.gameObject);
            health.changeFuel(100);
        }
        if (c.gameObject.tag == "Repair")
        {
            Destroy(c.gameObject);
            health.changeHealth(1000);
        }

        if (c.gameObject.tag == ("Bird"))
        {
            Destroy(c.gameObject);
            //Make explosion animation for bird
            health.changeHealth(-1000);
        }
    }
}
