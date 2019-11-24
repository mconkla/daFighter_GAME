using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10.0f;
    public float jump = 10.0f;



    [HideInInspector]
    public string horizontal, vertical= "";


    public bool grounded = true;

    // Use this for initialization
    void Start()
    {
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


        if (Input.GetAxis(horizontal) > 0.5)
        {
            //Debug.Log(Input.GetAxis(horizontal).ToString());
            rb.AddForce(new Vector2(speed, 0));
            this.gameObject.transform.localScale = new Vector3(1, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        }
        else if (Input.GetAxis(horizontal) < -0.5)
        {
            rb.AddForce(new Vector2(-speed, 0));
            this.gameObject.transform.localScale = new Vector3(-1, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        }

        if (Input.GetAxis(vertical) > 0.2 && grounded)
        {
            grounded = false;
            rb.AddForce(new Vector2(speed * Mathf.Sign(Input.GetAxis(horizontal)), jump));
        }
        else if (Input.GetAxis(vertical) < -0.5)
        {
            //do something -> crouch
        }

      

        }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "floor")
        {
            grounded = true;
        }
    }
    
}
