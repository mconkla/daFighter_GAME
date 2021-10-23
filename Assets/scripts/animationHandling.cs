using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandling : MonoBehaviour
{

    Animator myAnimator;
    Animator effectAnimator;
    AudioManager myAudioManager;
    attackSystem myAttackSystem;
    controllerInputs myControllerInputs;


    bool lightPunchPressed, lightKickNormal, lightPunchAirPressed,
        lightKickAirPressed, lightPunchCrouchedPressed, lightKickCrouchedPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        myControllerInputs = this.gameObject.GetComponent<controllerInputs>();
        myAnimator = this.gameObject.GetComponent<Animator>();
        effectAnimator = this.transform.GetChild(1).GetComponent<Animator>();
        myAudioManager = this.gameObject.GetComponent<AudioManager>();
        myAttackSystem = this.gameObject.GetComponent<attackSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        checkAxes();
        checkLightAttacks();
        checkHeavyAttacks();
        checkBlock();
    }

    void checkBlock()
    {
         myAnimator.SetBool("block", myControllerInputs.blocked);
    }

    void checkAxes()
    {
       
        myAnimator.SetBool("walk", (myControllerInputs.walkRight || myControllerInputs.walkLeft));
        myAnimator.SetBool("crouch", myControllerInputs.crouched);
        myAnimator.SetBool("jump", myControllerInputs.jump);

        //kann weg
        myAnimator.SetBool("grounded", myControllerInputs.grounded);

        //jump toDo
    }



    void checkLightAttacks()
    {
        if (myAttackSystem.hitted)
        {
            //myAudioManager.Play("hitted");
        }


        this.groundLightAttacks();
        this.airLightattacks();
        this.crouchLightattacks();

        if (myControllerInputs.lightPunchCrouched)
        {
            //toDo
        }
        else if (myControllerInputs.lightPunchAir)
        {
            //toDo
        } 
        
        if (myControllerInputs.lightKickCrouched)
        {
            //toDo
        }
        else if (myControllerInputs.lightKickAir)
        {
            //toDo
        }

    }

    void groundLightAttacks()
    {
        if (myControllerInputs.lightPunchNormal && !this.lightPunchPressed)
        {
            myAnimator.Play("punch");
            this.lightPunchPressed = true;
            //myAudioManager.Play("punch");
        }
        if (!myControllerInputs.lightPunchNormal)
        {
            this.lightPunchPressed = false;
        }


        if (myControllerInputs.lightKickNormal && !this.lightKickNormal)
        {
            myAnimator.Play("kick");
            this.lightKickNormal = true;
            //myAudioManager.Play("punch");
        }
        if (!myControllerInputs.lightKickNormal)
        {
            this.lightKickNormal = false;
        }
    }

    void airLightattacks()
    {
        if (myControllerInputs.lightPunchAir && !this.lightPunchAirPressed)
        {
            myAnimator.Play("air_punch");
            this.lightPunchAirPressed = true;
            //myAudioManager.Play("punch");
        }
        if (!myControllerInputs.lightPunchAir)
        {
            this.lightPunchAirPressed = false;
        }


        if (myControllerInputs.lightKickAir && !this.lightKickAirPressed)
        {
            myAnimator.Play("air_kick");
            this.lightKickAirPressed = true;
            //myAudioManager.Play("punch");
        }
        if (!myControllerInputs.lightKickAir)
        {
            this.lightKickAirPressed = false;
        }
    }

    void crouchLightattacks()
    {
        if (myControllerInputs.lightPunchCrouched && !this.lightPunchCrouchedPressed)
        {
            myAnimator.Play("crouch_punch");
            this.lightPunchCrouchedPressed = true;
            //myAudioManager.Play("punch");
        }
        if (!myControllerInputs.lightPunchCrouched)
        {
            this.lightPunchCrouchedPressed = false;
        }


        if (myControllerInputs.lightKickCrouched && !this.lightKickCrouchedPressed)
        {
            myAnimator.Play("crouch_kick");
            this.lightKickCrouchedPressed = true;
            //myAudioManager.Play("punch");
        }
        if (!myControllerInputs.lightKickCrouched)
        {
            this.lightKickCrouchedPressed = false;
        }
    }

    void checkHeavyAttacks()
    {
       /*
        if (myControllerInputs.heavyPunchState > 0.1f)
        {
            effectAnimator.GetComponent<SpriteRenderer>().color = new Color(effectAnimator.GetComponent<SpriteRenderer>().color.r, effectAnimator.GetComponent<SpriteRenderer>().color.g, effectAnimator.GetComponent<SpriteRenderer>().color.b, Mathf.Abs(myControllerInputs.heavyPunchState));
        }
        else if(myControllerInputs.heavyPunchState == -0.2f)
        {
            effectAnimator.GetComponent<SpriteRenderer>().color = new Color(effectAnimator.GetComponent<SpriteRenderer>().color.r, effectAnimator.GetComponent<SpriteRenderer>().color.g, effectAnimator.GetComponent<SpriteRenderer>().color.b, 100);

        }
       */

        myAnimator.SetBool("heavyPunchCrouched", myControllerInputs.heavyPunchCrouched);
        myAnimator.SetBool("heavyKickCrouched", myControllerInputs.heavyKickCrouched);
        myAnimator.SetBool("heavyPunchNormal", myControllerInputs.heavyPunchNormal);
        myAnimator.SetBool("heavyKickNormal", myControllerInputs.heavyKickNormal);


        myAnimator.SetFloat("heavyPunchState", myControllerInputs.heavyPunchState);
        myAnimator.SetFloat("heavyKickState", myControllerInputs.heavyKickState);
        

        
      
        

        //effectAnimator.SetFloat("heavyPunchState", myControllerInputs.heavyPunchState);
        //effectAnimator.SetBool("heavyPunchNormal", myControllerInputs.heavyPunchNormal);

       






    }


}
