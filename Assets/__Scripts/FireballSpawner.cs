using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpawner : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;
    public float timeBeforeDeletion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Create fireball object
            GameObject fireball = Instantiate(projectile, transform) as GameObject;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            // Apply velocity
            rb.velocity = transform.forward * projectileSpeed;
            // Destroy the fireball after a certain amount of time
            Destroy(fireball, timeBeforeDeletion);
        }
    }
}
