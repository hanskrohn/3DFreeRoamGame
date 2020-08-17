using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public GameObject expCube;
    private PointSystem _pointSystem;

    override public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currhealth = maxHealth;
        _pointSystem = Object.FindObjectOfType<PointSystem>();
    }

    override public void TakeDamage(float amount)
    {
        currhealth-= amount;
        if (currhealth <= 0)
        {
            if (gameObject.tag == "Green")
            {
                _pointSystem.points += 10;
            } else if (gameObject.tag == "Blue")
            {
                _pointSystem.points += 5; 
            }
            _pointSystem.pointsText.text = "Points: " + _pointSystem.points.ToString();
            isDead = true;
            animator.SetBool("isDead", true);
            // Drop 4 exp orbs
            DropExp();
            Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void DropExp()
    {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(expCube, new Vector3(transform.position.x + i, transform.position.y + 1.5f, transform.position.z + i), transform.rotation);
            }
    }
}
