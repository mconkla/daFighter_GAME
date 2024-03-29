﻿using System.Collections;
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

    
    private GameObject dmgIndicator;
    private triggerColliderSystem myTriggerSystem;
    private int lastframe;

    // Start is called before the first frame update
    void Start()
    {
        
        myTriggerSystem = this.gameObject.GetComponentInParent<triggerColliderSystem>();
        dmgIndicator = myTriggerSystem.dmgIndicator;
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.GetComponent<BoxCollider2D>().enabled = triggerOn;
        setTriggerFalse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == myTriggerSystem.otherPlayer.ToString())
        {
            if (!myTriggerSystem.crouched)
            {
                
                if (!collision.GetComponent<controllerInputs>().blocked)
                {
                    //damage
                    if (this.dmg == 0)
                    {
                        collision.GetComponent<attackSystem>().spawnDamageIndicator = false;
                        collision.GetComponent<playerMove>().grabbed(this.transform);
                    }
                    else if (this.dmg > 0)
                    {
                        collision.GetComponent<attackSystem>().spawnDamageIndicator = true;
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
                            collision.GetComponent<attackSystem>().spawnDamageIndicator = false;
                            collision.GetComponent<playerMove>().grabbed(this.transform);
                        }
                        else if (this.dmg > 0)
                        {
                            collision.GetComponent<attackSystem>().spawnDamageIndicator = true;
                            collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                            collision.GetComponent<playerMove>().knockback(this.transform);
                        }
                    }

                }

            }
            else
            {
                //blocked
                if (!collision.GetComponent<controllerInputs>().crouched && !collision.GetComponent<controllerInputs>().blocked == true)
                {
                    if (this.dmg > 0)
                    {
                        collision.GetComponent<attackSystem>().spawnDamageIndicator = true;
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
                            collision.GetComponent<attackSystem>().spawnDamageIndicator = true;
                            collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                            collision.GetComponent<playerMove>().knockback(this.transform);
                        }
                    }

                }
            }
            
        }
        if (collision.GetComponent<attackSystem>().spawnDamageIndicator == true && Time.frameCount != lastframe && Time.frameCount >5)
        {
            Debug.Log(collision.transform.localPosition + "HAllo");
            GameObject  indicator = Instantiate(dmgIndicator, collision.transform.localPosition,collision.transform.rotation);
            damageIndicators test = indicator.GetComponent<damageIndicators>();
            test.dmg = dmg;
            collision.GetComponent<attackSystem>().spawnDamageIndicator = false;
            lastframe = Time.frameCount;





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
