using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCombat : MonoBehaviour
{
    public int Health;
    public int Damage { get; private set; } = 1;
    [SerializeField]GameObject AttackCollider;
    Collider SwordCollider;
    
    private bool blocking;
    Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Attack();


        }
        if (Input.GetMouseButtonUp(0))
        {
            AttackCollider.SetActive(false);
        }

        if (Input.GetMouseButton(1))
        {
            Defend();
        }
        else
        {
            animatorController.SetBool("defending", false);
        }
    }
        
    public void Attack()
    {
               
        animatorController.SetTrigger("attack");
        AttackCollider.SetActive(true);
        
    }
    void Defend()
    {
        animatorController.SetBool("defending", true);
    }
    

     
}
