using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace IH
{
    public class EnemyStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;            
               

        enum enemyState { Waiting, Sensing, Chasing, Attacking, Victory, Death }
        private enemyState state;

        [SerializeField] float attackingDistance;
        [SerializeField] float detectionDistance;
        [SerializeField] float sensingDistance;
        [SerializeField] float attackDelay = 2;
        private float timer = 0;

        [SerializeField] NavMeshAgent enemy;
        [SerializeField] Transform player;

        Collider m_ObjectCollider;
        Animator animator;
        PlayerStats playerStats;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            m_ObjectCollider = GetComponent<Collider>();
            animator = GetComponent<Animator>();
            playerStats = FindObjectOfType<PlayerStats>();
            state = enemyState.Waiting;

        }

        void Update()
        {

            switch (state)
            {
                case enemyState.Waiting:
                    OnWaiting();
                    break;
                case enemyState.Sensing:
                    Sensing();
                    break;
                case enemyState.Chasing:
                    OnChasing();
                    break;
                case enemyState.Attacking:
                    int rand = Random.Range(0, 3);
                    if (rand == 0)
                    {
                        Attack();
                    }
                    if (rand == 1)
                    {
                        Attack2();
                    }
                    if (rand == 2)
                    {
                        Attack3();
                    }
                    break;
                case enemyState.Victory:
                    OnVictory();
                    break;
                case enemyState.Death:
                    break;
            }
            timer += Time.deltaTime;
            animator.SetFloat("Speed", enemy.velocity.normalized.x);
        }

        void Attack()
        {
            float dist = Vector3.Distance(player.position, transform.position);
            
            if (timer >= attackDelay)
            {
                animator.SetBool("attacking", true);                
                timer = 0;
            }
            else if (timer < attackDelay)
            {
                animator.SetBool("attacking", false);                
            }

            if (playerStats.currentHealth <= 0)
            {
                state = enemyState.Victory;
            }
            else if (dist > attackingDistance)
            {
                state = enemyState.Chasing;
            }
        }
        void Attack2()
        {
            float dist = Vector3.Distance(player.position, transform.position);
            
            if (timer >= attackDelay)
            {
                animator.SetBool("attacking1", true);
                timer = 0;
            }
            else if (timer < attackDelay)
            {
                animator.SetBool("attacking1", false);
            }

            if (playerStats.currentHealth <= 0)
            {
                state = enemyState.Victory;
            }
            else if (dist > attackingDistance)
            {
                state = enemyState.Chasing;
            }
        }
        void Attack3()
        {
            float dist = Vector3.Distance(player.position, transform.position);
            
            if (timer >= attackDelay)
            {
                animator.SetBool("attacking2", true);
                timer = 0;
            }
            else if (timer < attackDelay)
            {
                animator.SetBool("attacking2", false);
            }

            if (playerStats.currentHealth <= 0)
            {
                state = enemyState.Victory;
            }
            else if (dist > attackingDistance)
            {
                state = enemyState.Chasing;
            }
        }

        void OnWaiting()
        {
            float dist = Vector3.Distance(player.position, transform.position);

            if (dist <= sensingDistance)
            {
                state = enemyState.Sensing;
            }
        }
        void Sensing()
        {
            animator.Play("Sensing");
        
            float dist = Vector3.Distance(player.position, transform.position);
        
            if (dist <= detectionDistance)
            {
                state = enemyState.Chasing;
            }
        }
        void OnChasing()
        {

            if (enemy.pathPending)
                return;

            animator.SetBool("attacking", false);

            enemy.SetDestination(player.transform.position);

            if (Vector3.Distance(player.position, transform.position) <= attackingDistance)
            {
                state = enemyState.Attacking;
                enemy.ResetPath();
            }
            else if (Vector3.Distance(player.position, transform.position) > detectionDistance + 5f)
            {
                state = enemyState.Waiting;
                enemy.ResetPath();
            }
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 1;
            return maxHealth;
        }
        void DamageAnim()
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                animator.Play("Damage01");
            }
            if (rand == 1)
            {
                animator.Play("Damage00");
            }
        }
        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            DamageAnim();

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnDeath();
                state = enemyState.Death;
            }
        }
        void OnDeath()
        {
            m_ObjectCollider.isTrigger = true;
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                animator.Play("Dead00");
            }
            if (rand == 1)
            {
                animator.Play("Dead01");
            }
            Destroy(gameObject, 30f);
        }
        void OnVictory()
        {
            animator.SetBool("attacking", false);
            animator.Play("Victory");
        }
    }

}