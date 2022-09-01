using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class WeaponSlotManager : MonoBehaviour
    {
        EnemyWeaponHolderSlot leftHandSlot;
        EnemyWeaponHolderSlot rightHandSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;

        private void Awake()
        {
            EnemyWeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<EnemyWeaponHolderSlot>();
            foreach (EnemyWeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponItem);                
                LoadLeftWeaponDamageCollider();
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
            }
            
        }
        public void LoadShieldOnSlot(ShieldItem shieldItem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadShieldModel(shieldItem);
                
            }
            else
            {
                rightHandSlot.LoadShieldModel(shieldItem);
                
            }
        }

        #region Handle Weapons Damage Collider

        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentShieldModel.GetComponentInChildren<DamageCollider>();
        }
        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenLeftDamageCollider()
        {
            leftHandDamageCollider.EnableDamageCollider();
        }
        public void CloseLeftDamageCollider()
        {
            leftHandDamageCollider.DisableDamageCollider();
        }
        public void OpenRightDamageCollider()
        {
            rightHandDamageCollider.EnableDamageCollider();
        }
        public void CloseRightDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
        }
        #endregion 
    }
}
