using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public float jump = 10.0f;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;


    public CircleCollider2D upperBody;

    [HideInInspector]
    public string horizontal, vertical= "";

    [HideInInspector]

    attackSystem myAttackSystem;

    public bool grounded = true;

    // Use this for initialization
    void Start()
    {

        myAttackSystem = this.gameObject.GetComponent<attackSystem>();

        horizontal = "Horizontal" + this.gameObject.tag.ToString();
        vertical = "Vertical" + this.gameObject.tag.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    void getInput()
    {
        

        

        Debug.Log(Input.GetAxis(horizontal));

        if (Input.GetAxis(horizontal) > 0.5)
        {
            this.gameObject.GetComponent<Animator>().SetBool("walk", true);
            this.gameObject.GetComponent<Animator>().SetBool("kick", false);
            this.gameObject.GetComponent<Animator>().SetBool("punch", false);
            this.gameObject.GetComponent<Animator>().SetBool("crouch", false);
            this.gameObject.GetComponent<Animator>().SetBool("block", false);
            //Debug.Log(Input.GetAxis(horizontal).ToString());

            if (!myAttackSystem.blocked) {
                Vector3 targetVelocity = new Vector2(speed * 0.10f, rb.velocity.y);
                // And then smoothing it out and applying it to the character
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            }

           // rb.AddForce(new Vector2(speed, 0));
            this.gameObject.transform.localScale = new Vector3(1 * Mathf.Abs(this.gameObject.transform.localScale.y), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        }
        else if (Input.GetAxis(horizontal) < -0.5)
        {
            this.gameObject.GetComponent<Animator>().SetBool("walk", true);
            this.gameObject.GetComponent<Animator>().SetBool("kick", false);
            this.gameObject.GetComponent<Animator>().SetBool("punch", false);
            this.gameObject.GetComponent<Animator>().SetBool("crouch", false);
            this.gameObject.GetComponent<Animator>().SetBool("block", false);
            if (!myAttackSystem.blocked)
            {
                Vector3 targetVelocity = new Vector2(-speed * 0.10f, rb.velocity.y);
                // And then smoothing it out and applying it to the character
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            }

           // rb.AddForce(new Vector2(-speed, 0));
            this.gameObject.transform.localScale = new Vector3(-1 * Mathf.Abs(this.gameObject.transform.localScale.y), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("walk", false);
           
        }

        if (Input.GetAxis(vertical) > 0.2 && grounded)
        {
            if (!myAttackSystem.blocked)
            {
                this.gameObject.GetComponent<Animator>().SetBool("grounded", false);
               
                grounded = false;
                rb.AddForce(new Vector2(0f, jump));
                //rb.AddForce(new Vector2(speed * Mathf.Sign(Input.GetAxis(horizontal)), jump));
            }
        }
        if (Input.GetAxis(vertical) < -0.5)
        {
            upperBody.enabled = false; 
        }
        else
        {
            upperBody.enabled = true;
        }

        this.gameObject.GetComponent<Animator>().SetBool("crouch", !upperBody.enabled);


    }


    public void knockback(Transform enemy)
    {
        Vector2 moveDirection;
        moveDirection = this.transform.position - enemy.transform.position;
        rb.AddForce(moveDirection.normalized * 150f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "floor")
        {
            this.gameObject.GetComponent<Animator>().SetBool("grounded", true);
            grounded = true;
        }
    }
    
}
