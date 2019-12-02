using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandling : MonoBehaviour
{

    Animator myAnimator;
    Animator effektAnimator;
    controllerInputs myControllerInputs;

    // Start is called before the first frame update
    void Start()
    {
        myControllerInputs = this.gameObject.GetComponent<controllerInputs>();
        myAnimator = this.gameObject.GetComponent<Animator>();
        effektAnimator = this.transform.GetChild(1).GetComponent<Animator>();
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
        if (myControllerInputs.lightPunchNormal)
        {
            myAnimator.Play("lightpunchNormal_player");
           
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

       
        if (myControllerInputs.heavyPunchState > 0.1)
        {
            myAnimator.Play("player_big_heavypunch_load");
            effektAnimator.Play("player_big_heavypunch_load_effekt");
            effektAnimator.GetComponent<SpriteRenderer>().color = new Color(effektAnimator.GetComponent<SpriteRenderer>().color.r, effektAnimator.GetComponent<SpriteRenderer>().color.g, effektAnimator.GetComponent<SpriteRenderer>().color.b, Mathf.Abs(myControllerInputs.heavyPunchState));

           




        }
        else if(myControllerInputs.heavyPunchState == -0.2f)
        {
            effektAnimator.GetComponent<SpriteRenderer>().color = new Color(effektAnimator.GetComponent<SpriteRenderer>().color.r, effektAnimator.GetComponent<SpriteRenderer>().color.g, effektAnimator.GetComponent<SpriteRenderer>().color.b, 0);

        }
        /* if (myControllerInputs.heavyPunchNormal)
         {
             myAnimator.Play("player_big_heavypunch_exit");
             effektAnimator.Play("player_big_heavypunch_exit_effekt");

         }
         */
        if (Mathf.Abs(myControllerInputs.dmgMultiplyer) <= 1f && Mathf.Abs(myControllerInputs.dmgMultiplyer) > 0.95f && myControllerInputs.heavyPunchNormal)
        {
            myAnimator.Play("player_big_heavypunch_exit");
            effektAnimator.Play("player_big_heavypunch_exit_effekt_perfekt");
        }
        else if (Mathf.Abs(myControllerInputs.dmgMultiplyer) > 1f || Mathf.Abs(myControllerInputs.dmgMultiplyer) <= 0.95f && myControllerInputs.heavyPunchNormal)
        {
            myAnimator.Play("player_big_heavypunch_exit");
            effektAnimator.Play("player_big_heavypunch_exit_effekt");
        }
        myAnimator.SetBool("heavyPunchNormal", myControllerInputs.heavyPunchNormal);
        effektAnimator.SetBool("heavyPunchNormal", myControllerInputs.heavyPunchNormal);

        myAnimator.SetBool("block", myControllerInputs.blocked);






    }


}
