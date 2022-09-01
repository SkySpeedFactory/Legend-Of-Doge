using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;

        public int currentWeaponDamage;
        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = false;
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }
        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                
                if (playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }
            if (collision.tag == "BossEnemy")
            {
                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }
            if (collision.tag == "Enemy")
            {
                SmallEnemy smallEnemy = collision.GetComponent<SmallEnemy>();

                if (smallEnemy != null)
                {
                    smallEnemy.TakeDamage(currentWeaponDamage);
                }
            }
            if (collision.tag == "Enemy")
            {
                ChestEnemy chestEnemy = collision.GetComponent<ChestEnemy>();

                if (chestEnemy != null)
                {
                    chestEnemy.TakeDamage(currentWeaponDamage);
                }
            }
            if (collision.tag == "MiniBoss")
            {
                MiniBoss miniBoss = collision.GetComponent<MiniBoss>();

                if (miniBoss != null)
                {
                    miniBoss.TakeDamage(currentWeaponDamage);
                }
            }
        }
    }
}
