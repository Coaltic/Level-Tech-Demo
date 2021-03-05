using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5;
    public float JumpHeight = 0.04f;
    private float PlayerY;

    public bool jumping;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float Yaxis = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;


            if (jumping)
            {
                PlayerY = JumpHeight;
            }
        
            if (PlayerY >= JumpHeight)
            {
                jumping = false;
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jumping = false;
            PlayerY = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + 5f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - 5f;
        }

        gameObject.transform.Translate(Xaxis, PlayerY, Yaxis);
    }
}
