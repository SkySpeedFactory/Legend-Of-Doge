using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class HeartSystem : MonoBehaviour
    {
        public GameObject[] lifes;
        PlayerStats playerStats;
        void Start()
        {
            playerStats = FindObjectOfType<PlayerStats>();
            
        }
        void Update()
        {
            playerStats.currentHealth = lifes.Length;
        }
    }
}
