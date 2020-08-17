using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool hasHealthBar = false;
    public int maxHealth = 10;
    public float currhealth;
    public SimpleHealthBar healthBar;
    public Animator animator;
    public bool isResistive;

    [HideInInspector]
    public bool isDead = false;

    virtual public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currhealth = maxHealth;
        if (hasHealthBar)
        {
            healthBar.UpdateBar(currhealth, maxHealth);
        }
    }

    virtual public void TakeDamage(float amount)
    {
        currhealth-= amount;
        if (hasHealthBar)
        {
            healthBar.UpdateBar(currhealth, maxHealth);
        }
        if (currhealth <= 0)
        {
            print("Died");
            isDead = true;
            animator.SetBool("isDead", true);
        }
        else
        {
            print("Took damage");
            animator.SetTrigger("hit");
        }
    }
}
