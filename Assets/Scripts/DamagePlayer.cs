using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class DamagePlayer : MonoBehaviour
    {
        [SerializeField] int damage = 1;
        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
        }
    }
}
