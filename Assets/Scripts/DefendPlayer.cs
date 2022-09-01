using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class DefendPlayer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.TakeDamage(0);
            }
        }
    }
}
