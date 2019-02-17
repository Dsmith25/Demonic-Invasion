using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image currentHealth;
    public Text ratioText;

    public float health = 100;
    public float maxHealth = 100;
    public float timer = 0f;
    //public float healthTimer = 10f;
    //public float regenAmount = 2f;
    public float damage = 5;
    bool damageTaken = false;
    //public Text GOText;

    // Use this for initialization
    void Start ()
    {
        //GOText.text = "";
    }
    void Update()
    {
        if (damageTaken)
        {
            timer += Time.deltaTime;
        }
        //if (health < maxHealth)
        //{
        //    if (timer >= healthTimer)
        //    {
        //        HealDamage(regenAmount);
        //    }
        //}
        if (health > 100)
        {
            health = 100;
        }
        UpdateHealthBar();
    }
	
	
	void UpdateHealthBar()
    {
        float ratio = health / maxHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + "%";
        if (ratio > 1)
        {
            ratio = 1;
        }
	}

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
            //GOText.text = "Game Over!";
            gameOver();
            Destroy(gameObject);
            
        }
        UpdateHealthBar();
        damageTaken = true;
    }
    void HealDamage(float regenAmount)
    {
        timer = 0f;
        health += regenAmount;
        UpdateHealthBar();
    }

    void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(damage);
            Debug.Log("5 Damage");
        }

    }
}
