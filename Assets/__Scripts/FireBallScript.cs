using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public GameObject explosionVFX;
    public float blastRadius;
    public float projectileSpeed = 1.5f;

    private EnemyAttack _enemyAttack;

    private void Start()
    {
        _enemyAttack = GetComponentInParent<EnemyAttack>();
    }


    private void Update()
    {
        float step = projectileSpeed * Time.deltaTime;
        Vector3 endPos = _enemyAttack.currentPlayerPosition;
        endPos.y -= 1.0f;
        transform.position = Vector3.MoveTowards(transform.position, endPos, step);
    }

    void OnTriggerEnter(Collider other)
    {
        // Destory fireball if collided
        Destroy(gameObject);
        // Deploy explosion effects
        Instantiate(explosionVFX, transform.position, transform.rotation);

        // Deal Damage
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Health health = nearbyObject.GetComponent<Health>();

            // Check if nearby enemies have a health script and apply damage
            if (health)
            {
                if (!health.isResistive)
                {
                    health.TakeDamage(5);
                }
            } 
            
        }
    }
}
