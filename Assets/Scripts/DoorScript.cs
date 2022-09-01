using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IH
{
    public class DoorScript : MonoBehaviour
    {
        
        public Transform PlayerCamera;
        [Header("MaxDistance you can open or close the door.")]
        public float MaxDistance = 100;

        private bool opened = false;
        public Animator anim;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Pressed();                
            }
            
        }
        
        void Pressed()
        {
            
            RaycastHit doorhit;
            
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
            {
                Debug.DrawRay(PlayerCamera.transform.position, PlayerCamera.transform.forward,Color.red, MaxDistance);
                if (doorhit.transform.tag == "Door")
                {
                    anim = doorhit.transform.GetComponentInParent<Animator>();
                    opened = !opened;
                    anim.SetBool("Opened", !opened);
                }
            }
        }
    }
}
