using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IH
{
    public class PlayerStats : MonoBehaviour
    {
        public GameObject[] lifes;
        public int currentHealth;
        bool isDefending;

        AnimatorHandler animatorHandler;
        Animator ac;
        
        InputHandler inputHandler;
        UIManager uiManager;

        AudioSource audioSource;
        public AudioClip attackClip;
        public AudioClip hitClip;
        public AudioClip senseClip;
        public AudioClip deathClip;
        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            ac = GetComponent<Animator>();
            inputHandler = GetComponent<InputHandler>();
            audioSource = GetComponent<AudioSource>();

        }
        void Start()
        {
            currentHealth = lifes.Length;
        }
        private void Update()
        {
            isDefending = ac.GetBool("isDefending");
            
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
        }
        public void SenseSound()
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

        public void TakeDamage(int damage)
        {
            if (isDefending)
            {
                damage = 0;
            }
            currentHealth = currentHealth - damage;
            Destroy(lifes[currentHealth].gameObject);
            if (currentHealth > 0)
            {
                ac.SetBool("isInteracting", true);
                ac.SetTrigger("hit");
            }

            if (currentHealth <= 0)
            {
                
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Die", true);
                LevelManager.instance.GameOver();
            }
        }
    }

}