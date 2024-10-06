using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody2D Character;
    private float horizontal;
    private float vertical;
    private float gravity;
    RaycastHit2D hit;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float ySpeed;
    [SerializeField]
    private Animator animationController;

    private bool yAct = true;
    public static MainCharacter instance;
    private void Awake()
    {
        if (MainCharacter.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
        else 
        {
            Destroy(gameObject);Debug.Log('d');
        }

    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        if (horizontal != 0)
        {
            Character.position= transform.position+new Vector3(runSpeed * horizontal*0.02f,0,0);
            Character.transform.localScale = new Vector3(horizontal, 1, 1);
        }
        animationController.SetFloat("Speed", Mathf.Abs(runSpeed * horizontal));

        if (yAct)
        {

            if (vertical > 0)
            {
                Character.velocity = new Vector3(0, ySpeed, 0);
                yAct = false;
                Debug.Log("saltando");
                animationController.SetBool("Jump", true);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Character.gravityScale = -Character.gravityScale;
                Character.transform.Rotate(180, 0, 0);
                ySpeed = -ySpeed;
                yAct = false;
                animationController.SetBool("Falling", true);
            }
        }
        else
        {

            animationController.SetBool("Jump", false);
            animationController.SetBool("Falling", true);

        }
        hit = Physics2D.Raycast(transform.position, -transform.up, 1);
        Debug.DrawRay(transform.position, transform.position - transform.up * 1, Color.red);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        yAct = true;
        animationController.SetBool("Falling", false);

    }

    private void Run( float speed)
    {

    }
}
