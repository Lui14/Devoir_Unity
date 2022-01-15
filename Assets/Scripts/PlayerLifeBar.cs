using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    public float maxHealth = 100f;
    PlayerMovement Player;
    public Image bar;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = currentHealth / maxHealth;


        bar.fillAmount = 0.01f * currentHealth;
        if (bar.fillAmount < 0.3f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (bar.fillAmount < 0.6f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead !");
            gameOver.SetActive(true);
        }
    }

    public void SetHealthBarColor(Color healthColor)
    {
        bar.color = healthColor;
    }

}

