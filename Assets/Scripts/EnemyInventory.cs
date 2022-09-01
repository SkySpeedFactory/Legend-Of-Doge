using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class EnemyInventory : MonoBehaviour
    {
        EnemyWeaponSlotManager enemyWeaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;        

        private void Awake()
        {
            enemyWeaponSlotManager = GetComponentInChildren<EnemyWeaponSlotManager>();
        }

        private void Start()
        {
            enemyWeaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            enemyWeaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);            
        }
    }
}
