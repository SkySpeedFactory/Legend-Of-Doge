using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class PlayerAttacker : MonoBehaviour
    {
        AnimatorHandler animatorHandler;
        Animator ac;       
        
        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            ac = GetComponent<Animator>();
        }
        public void HandleLightAttack(WeaponItem weapon)
        {
            ac.SetBool("isInteracting", true);
            ac.SetTrigger("atk1");            
        }

        public void HandleHeavyAttack(WeaponItem weapon)
        {
            ac.SetBool("isInteracting", true);
            ac.SetTrigger("atk2");
        }

        public void HandleDefending(ShieldItem shield)
        {
            ac.SetBool("isInteracting", true);
            ac.SetTrigger("def");
            ac.SetBool("isDefending", true);
        }
       
    }
}
