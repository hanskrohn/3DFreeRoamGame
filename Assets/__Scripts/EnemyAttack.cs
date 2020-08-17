using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Bomb, Sword, Fireball
}

public class EnemyAttack : MonoBehaviour
{

    public AttackType attackType = AttackType.Sword;    // Default to sword
    public GameObject player;
    public GameObject grenade;
    public GameObject projectile;
    public GameObject projectilePosition;
    public float timeBeforeDeletion = 3.0f;
    public Vector3 currentPlayerPosition;

    private EnemyMovement _enemyMovement;
    private Health _health;
    private Health _playerHealth;
    private bool _isDistanceCheck = false;
    private float _timeLeft = 3.0f;
    private float _attackRate = 2.0f;
    private float _nextAttack;

    private Animator _animator;

    void Start()
    {
        _enemyMovement = GetComponentInChildren<EnemyMovement>();
        _health = GetComponentInChildren<Health>();  // Health of the enemy
        _animator = GetComponentInChildren<Animator>();    
        _playerHealth = player.GetComponentInChildren<Health>(); // Health of the player

    }

    void Update()
    {
        // If enemy is alive, check whether to attack or not
        if (!_health.isDead)
        {
            if (attackType == AttackType.Bomb)
            {
                BombAttack();
            }
            if (attackType == AttackType.Fireball)
            {
                FireballAttack();
            }
            else
            {
                SwordAttack();
            }
        }
    }

    void FireballAttack()
    {
        if (_enemyMovement.playerDistance < 20.0f && !_playerHealth.isDead)
        {
            if (!_isDistanceCheck)
            {
                _isDistanceCheck = true;
            }
            else
            {
                _timeLeft -= Time.deltaTime;
            }

            if (_timeLeft <= 0.0f && Time.time > _nextAttack)
            {
                _nextAttack = Time.time + (_attackRate * 2.0f);
                currentPlayerPosition = player.transform.position;

                // Spawn fireball at hand of boss
                GameObject fireball = Instantiate(projectile, projectilePosition.transform.position, projectilePosition.transform.rotation) as GameObject;
                fireball.transform.parent = transform;

                // If fireball doesn't explode then delete
                Destroy(fireball, timeBeforeDeletion);
            }
        }
        else
        {
            _animator.SetBool("attack", false);
            _isDistanceCheck = false;
            _timeLeft = 3.0f;
        }
      
    }

    void BombAttack()
    {
        if (_enemyMovement.playerDistance < 5.0f && !_playerHealth.isDead)
        {
            if (!_isDistanceCheck)
            {
                _isDistanceCheck = true;
            }
            else
            {
                _timeLeft -= Time.deltaTime;
            }

            if (_timeLeft <= 0.0f && Time.time > _nextAttack)
            {
                _nextAttack = Time.time + _attackRate;
                _animator.SetBool("attack", true);
                GameObject go = Instantiate(grenade, transform.position, transform.rotation);
                go.GetComponent<Rigidbody>().AddForce(transform.forward * 300);
            }
      
        }
        else
        {
            _animator.SetBool("attack", false);
            _isDistanceCheck = false;
            _timeLeft = 3.0f;
        }
    }

    void SwordAttack()
    {
        if (_enemyMovement.playerDistance < 3.0f && !_playerHealth.isDead)
        {
            if (!_isDistanceCheck)
            {
                _isDistanceCheck = true;
            }
            else
            {
                _timeLeft -= Time.deltaTime;
            }

            if (_timeLeft <= 0.0f && Time.time > _nextAttack)
            {
                _nextAttack = Time.time + _attackRate;
                _animator.SetBool("attack", true);
                _playerHealth.TakeDamage(0.5f);
            }
        }
        else
        {
            _animator.SetBool("attack", false);
            _isDistanceCheck = false;
            _timeLeft = 3.0f;
        }
    }

}
