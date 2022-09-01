using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace IH
{
    public class SmallEnemy : MonoBehaviour
    {
        public int healthLevel = 2;
        public int maxHealth;
        public int currentHealth;

        enum enemyState { Waiting, Sensing, Chasing, Attacking, Victory, Death }
        private enemyState state;

        [SerializeField] float attackingDistance;
        [SerializeField] float detectionDistance;
        [SerializeField] float sensingDistance;
        [SerializeField] float attackDelay = 2;
        [SerializeField] float DeathDelay = 60;
        private float timer = 0;

        [SerializeField] NavMeshAgent enemy;
        [SerializeField] Transform player;
        [SerializeField] GameObject AttackCollider;

        Collider m_ObjectCollider;
        Animator animator;
        PlayerStats playerStats;

        AudioSource audioSource;
        public AudioClip attackClip;
        public AudioClip hitClip;
        public AudioClip senseClip;
        public AudioClip deathClip;

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            m_ObjectCollider = GetComponent<Collider>();
            animator = GetComponent<Animator>();
            playerStats = FindObjectOfType<PlayerStats>();
            state = enemyState.Waiting;
            audioSource = GetComponent<AudioSource>();
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
                    Attack();                    
                    break;
                case enemyState.Victory:
                    OnVictory();
                    break;
                case enemyState.Death:
                    OnDeath();
                    break;
            }
            timer += Time.deltaTime;
            animator.SetFloat("Speed", enemy.velocity.normalized.x);
        }
        #region Sound
        public void AttackSound()
        {
            audioSource.clip = attackClip;
            audioSource.Play();
        }
        public void DeathSound()
        {
            audioSource.clip = deathClip;
            audioSource.Play();
        }
        public void HitSound()
        {
            audioSource.clip = hitClip;
            audioSource.Play();
        }public void SenseSound()
        {
            audioSource.clip = senseClip;
            audioSource.Play();
        }
        public void StopSound()
        {
            audioSource.clip = attackClip;
            audioSource.clip = deathClip;
            audioSource.clip = hitClip;
            audioSource.clip = senseClip;
            audioSource.Stop();
        }
        #endregion
        void Attack()
        {
            float dist = Vector3.Distance(player.position, transform.position);
            transform.LookAt(player);
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
        public void DoDamage()
        {
            AttackCollider.SetActive(true);
            StartCoroutine(DamageTimer());
        }

        public IEnumerator DamageTimer()
        {
            yield return new WaitForSeconds(0.3f);
            AttackCollider.SetActive(false);
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
            animator.Play("SenseSomethingRPT");

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
            animator.SetTrigger("moved");
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

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;
            if (state != enemyState.Death)
            {
                animator.Play("GetHit");
            }

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                
                state = enemyState.Death;              
                
            }
        }
        void OnDeath()
        {
            animator.Play("Die");
            m_ObjectCollider.isTrigger = true;
            Destroy(gameObject, DeathDelay);
        }

        void OnVictory()
        {
            animator.SetBool("attacking", false);
            animator.Play("Victory");
        }
    }
}
