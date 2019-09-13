using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rocketHealth : MonoBehaviour
{
    private float maxHealth = 10000;
    public float health;

    private float maxFuel = 10000;
    public float fuel;

    public Text healthText;
    public Text fuelText;

    public Image healthBar;
    public Image fuelBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
        fuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            //game over
        }
        fuel -= 1;
        if(fuel == 0) {
            Destroy(gameObject);
        }
        setFuel(fuel, maxFuel);
        healthText.text = "Health: " + health;
        
    }

    public void changeHealth(int change)
    {
        health += change;
        if (health <= 0) {
            health = 0;
            Destroy(gameObject);
        }
        setHealth(health, maxHealth);
    }

    public void changeFuel(int change) 
    {
        if(fuel < maxFuel) 
        {
            fuel += change;
            if(fuel > maxFuel) 
            {
                fuel = maxFuel;
            }
        }
        setFuel(fuel, maxFuel);
    }

    public void setHealth(float health, float maxHealth) 
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void setFuel(float fuel, float maxFuel) 
    {
        fuelBar.fillAmount = fuel / maxFuel;
    }
}
