﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandling : MonoBehaviour
{

    Animator myAnimator;
    Animator effektAnimator;
    AudioManager myAudioManager;
    attackSystem myAttackSystem;
    controllerInputs myControllerInputs;

    // Start is called before the first frame update
    void Start()
    {
        myControllerInputs = this.gameObject.GetComponent<controllerInputs>();
        myAnimator = this.gameObject.GetComponent<Animator>();
        effektAnimator = this.transform.GetChild(1).GetComponent<Animator>();
        myAudioManager = this.gameObject.GetComponent<AudioManager>();
        myAttackSystem = this.gameObject.GetComponent<attackSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        checkAxes();
        checkLightAttacks();
        checkHeavyAttacks();
    }

    void checkAxes()
    {
       
        myAnimator.SetBool("walk", (myControllerInputs.walkRight || myControllerInputs.walkLeft));
        myAnimator.SetBool("crouch", myControllerInputs.crouched);

        //kann weg
        myAnimator.SetBool("grounded", myControllerInputs.grounded);

        //jump toDo
    }

    void checkLightAttacks()
    {
        if (myAttackSystem.hitted)
        {
            myAudioManager.Play("hitted");
        }
        if (myControllerInputs.lightPunchNormal)
        {
            myAnimator.Play("lightpunchNormal_player");
            myAudioManager.Play("punch");
           
        }
        
        if (myControllerInputs.lightPunchCrouched)
        {
            //toDo
        }
        else if (myControllerInputs.lightPunchAir)
        {
            //toDo
        } 
        myAnimator.SetBool("kick", myControllerInputs.lightKickNormal);
        
        if (myControllerInputs.lightKickCrouched)
        {
            //toDo
        }
        else if (myControllerInputs.lightKickAir)
        {
            //toDo
        }

    }

    void checkHeavyAttacks()
    {

       
        if (myControllerInputs.heavyPunchState > 0.1f)
        {
            effektAnimator.GetComponent<SpriteRenderer>().color = new Color(effektAnimator.GetComponent<SpriteRenderer>().color.r, effektAnimator.GetComponent<SpriteRenderer>().color.g, effektAnimator.GetComponent<SpriteRenderer>().color.b, Mathf.Abs(myControllerInputs.heavyPunchState));
        }
        else if(myControllerInputs.heavyPunchState == -0.2f)
        {
            effektAnimator.GetComponent<SpriteRenderer>().color = new Color(effektAnimator.GetComponent<SpriteRenderer>().color.r, effektAnimator.GetComponent<SpriteRenderer>().color.g, effektAnimator.GetComponent<SpriteRenderer>().color.b, 100);

        }
        
       
        myAnimator.SetBool("heavyPunchNormal", myControllerInputs.heavyPunchNormal);
        myAnimator.SetFloat("heavyPunchState", myControllerInputs.heavyPunchState);

        effektAnimator.SetFloat("heavyPunchState", myControllerInputs.heavyPunchState);
        effektAnimator.SetBool("heavyPunchNormal", myControllerInputs.heavyPunchNormal);

        myAnimator.SetBool("block", myControllerInputs.blocked);






    }


}
