using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerScript : MonoBehaviour
{

    [HideInInspector]
    public float timeStamp;
    [HideInInspector]
    public bool triggerOn = false;
    [HideInInspector]
    public float dmg = 0f;
    //test:


    private int otherPlayer;
    // Start is called before the first frame update
    void Start()
    {
        otherPlayer = this.gameObject.GetComponentInParent<triggerColliderSystem>().otherPlayer;
        
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<BoxCollider2D>().enabled = triggerOn;
        setTriggerFalse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == otherPlayer.ToString())
        {
            if (!collision.GetComponent<controllerInputs>().blocked)
            {
                collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                collision.GetComponent<playerMove>().knockback(this.transform);

                this.dmg = 0f;
            }
            else
            {
                if (Mathf.Sign(collision.transform.localScale.x) + Mathf.Sign(this.transform.localScale.x) != 0)
                {
                    collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                    collision.GetComponent<playerMove>().knockback(this.transform);
                    this.dmg = 0f;

                }
            }
        }
    }

    private void setTriggerFalse()
    {
       if (triggerOn && Time.time - timeStamp > 0.001f)
       {
           triggerOn = false;
       }
    }
}
