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




    [HideInInspector]
    public string horizontal, vertical= "";

    [HideInInspector]

    attackSystem myAttackSystem;

    public bool grounded = true;

    // Use this for initialization
    void Start()
    {
        horizontal = "Horizontal" + this.gameObject.tag.ToString();
        vertical = "Vertical" + this.gameObject.tag.ToString();
        fire = "Fire1"+ this.gameObject.tag.ToString();
        otherPlayer = this.gameObject.tag == "1" ? 2 : 1;
        myAttackSystem = this.gameObject.GetComponent<attackSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    void getInput()
    {


        if (Input.GetAxis(horizontal) > 0.5)
        {
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

            if (!myAttackSystem.blocked)
            {
                Vector3 targetVelocity = new Vector2(-speed * 0.10f, rb.velocity.y);
                // And then smoothing it out and applying it to the character
                rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            }

           // rb.AddForce(new Vector2(-speed, 0));
            this.gameObject.transform.localScale = new Vector3(-1 * Mathf.Abs(this.gameObject.transform.localScale.y), this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        }

        if (Input.GetAxis(vertical) > 0.2 && grounded)
        {
            if (!myAttackSystem.blocked)
            {
                grounded = false;
                rb.AddForce(new Vector2(0f, jump));
                //rb.AddForce(new Vector2(speed * Mathf.Sign(Input.GetAxis(horizontal)), jump));
            }
        }
        else if (Input.GetAxis(vertical) < -0.5)
        {
            //do something -> crouch
        }

      

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
            grounded = true;
        }
    }
    
}
