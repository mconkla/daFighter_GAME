using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public float jump = 10.0f;
    public CircleCollider2D upperBody;


    private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    private float direction = 1;

    controllerInputs myControllerInputs;

  

    // Use this for initialization
    void Start()
    {
        myControllerInputs = this.gameObject.GetComponent<controllerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        controlHorizontal();
        controlVertical();
    }

    void controlHorizontal()
    {
        
        if (myControllerInputs.walkRight)
        {
            Vector3 targetVelocity = new Vector2(speed * 0.10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            direction = 1;
            
        }
        else if (myControllerInputs.walkLeft)
        {
            Vector3 targetVelocity = new Vector2(-speed * 0.10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            direction = -1;
        }

        this.gameObject.transform.localScale = new Vector3(direction * Mathf.Abs(this.gameObject.transform.localScale.y), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

    }

    void controlVertical() { 

        if (myControllerInputs.jump)
        {
            rb.AddForce(new Vector2(0f, jump));
        }
        else if (myControllerInputs.crouched)
        {
            upperBody.enabled = false;
        }
        else
        {
            upperBody.enabled = true;
        }

    }


    public void knockback(Transform enemy)
    {
        
        Vector2 moveDirection;
        moveDirection = this.transform.position - enemy.transform.position;
        rb.AddForce(moveDirection.normalized * 150f);
        
    }

}
