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

    private triggerColliderSystem myTriggerSystem;

    // Start is called before the first frame update
    void Start()
    {
        myTriggerSystem = this.gameObject.GetComponentInParent<triggerColliderSystem>();        
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<BoxCollider2D>().enabled = triggerOn;
        setTriggerFalse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       bool spawnDamageIndicator = true; 
        if (collision.tag == myTriggerSystem.otherPlayer.ToString())
        {
            if (!myTriggerSystem.crouched)
            {
                
                if (!collision.GetComponent<controllerInputs>().blocked)
                {
                    //damage
                    if (this.dmg == 0)
                    {
                        spawnDamageIndicator = false;
                        collision.GetComponent<playerMove>().grabbed(this.transform);
                    }
                    else if (this.dmg > 0)
                    {
                        collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                        collision.GetComponent<playerMove>().knockback(this.transform);
                    }
                }
                else
                {
                    if (Mathf.Sign(collision.transform.localScale.x) + Mathf.Sign(myTriggerSystem.localScale) != 0)
                    {
                        if (this.dmg == 0)
                        {
                            collision.GetComponent<playerMove>().grabbed(this.transform);
                        }
                        else if (this.dmg > 0)
                        {

                            collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                            collision.GetComponent<playerMove>().knockback(this.transform);
                        }
                    }

                }

            }
            else
            {
                //blocked
                if (!collision.GetComponent<controllerInputs>().crouchBlocked)
                {
                    if (this.dmg > 0)
                    {
                        collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                        collision.GetComponent<playerMove>().knockback(this.transform);
                    }
                }
                else
                {
                    if (Mathf.Sign(collision.transform.localScale.x) + Mathf.Sign(myTriggerSystem.localScale) != 0)
                    {
                        if (this.dmg > 0)
                        {
                            collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                            collision.GetComponent<playerMove>().knockback(this.transform);
                        }
                    }

                }
            }
            
        }
        if (spawnDamageIndicator == true)
        {
            
            GameObject indicator = Instantiate(Resources.Load("DamageIndicator"), myTriggerSystem.GetComponentInParent<Transform>().position-collision.transform.position, Quaternion.identity) as GameObject;
            indicator.GetComponent<DamageIndicators>.dmg = dmg;
            
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
