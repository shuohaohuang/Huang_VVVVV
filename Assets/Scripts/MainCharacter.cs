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

    [SerializeField]
    private float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        if (horizontal != 0)
        {
            Character.position= transform.position+new Vector3(speed*horizontal*0.02f,0,0);
        }
        if (vertical > 0) 
        {
           Character.velocity= new Vector3(0,speed,0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Character.gravityScale=-Character.gravityScale;
            Character.transform.Rotate(180, 0, 0);
            speed = -speed;
        }
        
    }
}
