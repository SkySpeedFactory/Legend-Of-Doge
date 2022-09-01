using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movespeed;
    [SerializeField] bool isRunning;
    [SerializeField] float rotSpeed;
    Vector3 rotation;
    Animator animatorController;
    private Transform SwordPolyart;
    
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }
    void Update()
    {
        Movement();
        Rotate();
                

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }
    private void FixedUpdate()
    {
        
    }

    void Movement()
    {
        float runMultiplier;

        if (isRunning)
        {
            runMultiplier = 2;
        }
        else
        {
            runMultiplier = 1;
        }

        Vector3 velocity = Vector3.forward * Input.GetAxis("Vertical");// + Vector3.right* Input.GetAxis("Horizontal")

        velocity = velocity.normalized * movespeed * runMultiplier * Time.deltaTime;
        transform.Translate(velocity);

        //animatorController.SetFloat("movementX", Input.GetAxis("Horizontal"));
        animatorController.SetFloat("movementY", Input.GetAxis("Vertical") * runMultiplier);
    }
    void Rotate()
    {
        rotation = Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;
        transform.Rotate(rotation); 

    }

    

    /*void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = Vector3.up * Time.deltaTime * jumpForce;
            transform.Translate(jump);

            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);// Alternative/Tutorial
        }
        
    }*/
}






/*
 * [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] float jumpForce;
    Vector3 velocityZf;
    Vector3 velocityZr;
    Vector3 velocityX;
    Vector3 rotation;
    Vector3 jump;
    bool isRunning;

    Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        //Jump();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    void Attack()
    {
        animatorController.SetTrigger("attack");
    }
    void Movement()
    {
        float runMultiplier;
        if (isRunning)
        {
            runMultiplier = 2;
        }
        else
        {
            runMultiplier = 1;
        }
        Vector3 velocity = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
        velocity = velocity.normalized * moveSpeed * runMultiplier * Time.deltaTime;
        transform.Translate(velocity);
        animatorController.SetFloat("moveSpeed", Input.GetAxis("Vertical") * runMultiplier);


        //animatorController.SetFloat("movementX", Input.GetAxis("Horizontal"));
        //animatorController.SetFloat("moveSpeed", Input.GetAxis("Horizontal"));

        /*velocityZf = Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * moveSpeedForward;        
        velocityX = Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeedStrafe;
        transform.Translate(velocityZf);        
        transform.Translate(velocityX);*/
    
