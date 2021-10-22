using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public float jump = 10.0f;
    public CircleCollider2D upperBody;

    private bool hitted;

    [Range(0f,1f)]
    public float m_MovementSmoothing = .05f;

    private Vector3 m_Velocity = Vector3.zero;

    private Transform otherPlayer;

    controllerInputs myControllerInputs;


  

    // Use this for initialization
    void Start()
    {
        onLoad();
        
    }

    // Update is called once per frame
    void Update()
    {
        hitted = myControllerInputs.wasHit;
        if (!hitted) { 
        controlHorizontal();
        controlVertical();
        checkLookDir();
        }


    }

    void controlHorizontal()
    {
        
        if (myControllerInputs.walkRight)
        {
            Vector3 targetVelocity = new Vector2(speed * 0.10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            

        }
        if (myControllerInputs.walkLeft)
        {
            Vector3 targetVelocity = new Vector2(-speed * 0.10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            
        }

        
    }

    void controlVertical() { 

        if (myControllerInputs.jump)
        {
            rb.AddRelativeForce(new Vector2(0f, jump),ForceMode2D.Force);
           
          //  rb.AddForce();
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
        moveDirection.y = Mathf.Abs(moveDirection.y);
        rb.AddForce(moveDirection.normalized * 150f);
        
    }
    public void grabbed(Transform enemy)
    {
        this.transform.position =new Vector2(this.transform.position.x, this.transform.position.y +1);
    }

    void checkLookDir()
    {

        if (this.transform.position.x > otherPlayer.position.x)
        {
            this.gameObject.transform.localScale = new Vector3(-1 * Mathf.Abs(this.gameObject.transform.localScale.x), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1 * Mathf.Abs(this.gameObject.transform.localScale.x), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);

        }

    }
    void onLoad()
    {
        myControllerInputs = this.gameObject.GetComponent<controllerInputs>();
        otherPlayer = FindObjectsOfType<playerMove>()[(this.gameObject.tag == "1" ? 1 : 2) - 1].gameObject.transform;
    }
}
