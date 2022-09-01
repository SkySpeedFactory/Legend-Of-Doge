using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class EnemyWeaponHolderSlot : MonoBehaviour
    {
        public Transform parentOverride;
        public bool isLeftHandSlot;
        public bool isRightHandSlot;

        public GameObject currentWeaponModel;
        public GameObject currentShieldModel;


        public void UnloadWedapon()
        {
            if (currentWeaponModel != null)
            {
                currentWeaponModel.SetActive(false);
            }
        }
        public void UnloadWeaponAndDestroy()
        {
            if (currentWeaponModel != null)
            {
                Destroy(currentWeaponModel);
            }
        }
        public void UnloadShield()
        {
            if (currentShieldModel != null)
            {
                currentShieldModel.SetActive(false);
            }
        }

        public void UnloadShieldAndDestroy()
        {
            if (currentShieldModel != null)
            {
                Destroy(currentShieldModel);
            }
        }
        public void LoadWeaponModel(WeaponItem weaponItem)
        {
            UnloadWeaponAndDestroy();

            if (weaponItem == null)
            {
                return;
            }
            GameObject model = Instantiate(weaponItem.modelPrefab) as GameObject;
            if (model != null)
            {
                if (parentOverride != null)
                {
                    model.transform.parent = parentOverride;
                }
                else
                {
                    model.transform.parent = transform;
                }

                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localPosition = Vector3.one;
            }

            currentWeaponModel = model;
        }
        public void LoadShieldModel(ShieldItem shieldItem)
        {
            UnloadShieldAndDestroy();
        
            if (shieldItem == null)
            {
                return;
            }
            GameObject model = Instantiate(shieldItem.modelPrefab) as GameObject;
            if (model != null)
            {
                if (parentOverride != null)
                {
                    model.transform.parent = parentOverride;
                }
                else
                {
                    model.transform.parent = transform;
                }
        
                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localPosition = Vector3.one;
            }
        
            currentShieldModel = model;
        }
    }
}
