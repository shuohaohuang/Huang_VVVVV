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
    private float runSpeed;
    [SerializeField]
    private float ySpeed;

    private bool yAct = true;
    public static MainCharacter mainCharacter;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        mainCharacter = this;
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

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        yAct = true;
        Debug.Log(0);
    }

}
