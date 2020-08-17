using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeAttack : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    public float attackRange = 1f;
    public float attackRate = 1f;
    public GameObject grenade;

    private float _nextAttack;
    private Animator _animator;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //If Q is pressed, initiate grenade
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Set next attack time
            _nextAttack = Time.time + attackRate;
            // Play attack animation
            _animator.SetTrigger("attack");
            ThrowGrenade();
        }

    }
    private void ThrowGrenade()
    {
        //Instantiate grenade then add force to "throw" it
        GameObject go = Instantiate(grenade, transform.position, transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
