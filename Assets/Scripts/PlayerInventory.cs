using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public ShieldItem leftShield;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start()
        {
            weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
            
            weaponSlotManager.LoadShieldOnSlot(leftShield, true);
        }
    }
}
