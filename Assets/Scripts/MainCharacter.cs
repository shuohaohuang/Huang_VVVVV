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
        }
        if (yAct)
        {
            if (vertical > 0)
            {
                Character.velocity = new Vector3(0, ySpeed, 0);
                yAct = false;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Character.gravityScale = -Character.gravityScale;
                Character.transform.Rotate(180, 0, 0);
                ySpeed = -ySpeed;
                yAct = false;
            }
        }
        hit = Physics2D.Raycast(transform.position, -transform.up, 1);
        Debug.DrawRay(transform.position, transform.position - transform.up * 1, Color.red);
        if(hit.collider != null)
            yAct = true;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

}
