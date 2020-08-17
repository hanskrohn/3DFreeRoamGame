using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public SimpleHealthBar expBar;
    public int expToNextLevel = 100;
    public Text levelText;
    public GameObject levelUpEffect;
    private Health health;
    private PlayerAttack playerAttack;
    private int _currExp = 0;
    private int _level = 1;
    private const int EXPVALUE = 10;

    private void Start()
    {
        expBar.UpdateBar(_currExp, expToNextLevel);
        levelText.text = "Level: " + _level.ToString();
        health = GetComponentInParent<Health>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Experience")
        {
            _currExp += EXPVALUE;
            if (_currExp >= expToNextLevel)
            {
                // level up
                levelUp();
                _level += 1;
                increaseMaxHealth();
                increaseDamage();
                levelText.text = "Level: " + _level.ToString();
                _currExp -= expToNextLevel;
            }
            expBar.UpdateBar(_currExp, expToNextLevel);
        } 
    }
    
    private void levelUp()
    {
        for (int i = 0; i < 4; i++)
        {
            Destroy(Instantiate(levelUpEffect, new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z), new Quaternion(0, 90 * i, 0, 1), gameObject.transform), 5);
        }
        print("Level Up");
    }

    private void increaseMaxHealth()
    {
        health.maxHealth += 5;
        health.currhealth = health.maxHealth;
        health.healthBar.UpdateBar(health.currhealth, health.maxHealth);
    }

    private void increaseDamage()
    {
        // Increase damage only for sword man
        if (playerAttack)
        {
        playerAttack.attackDamage += 1;
        }
    }

}
