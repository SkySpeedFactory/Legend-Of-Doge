using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    [CreateAssetMenu(menuName = "Items/Shield Item")]
    public class ShieldItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;

        [Header("Defend Animation")]
        public string OH_Shield_Defend_1;
    }
}
