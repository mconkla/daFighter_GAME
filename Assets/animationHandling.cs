using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandling : MonoBehaviour
{

    Animator myAnimator;
    controllerInputs myControllerInputs;

    // Start is called before the first frame update
    void Start()
    {
        myControllerInputs = this.gameObject.GetComponent<controllerInputs>();
        myAnimator = this.gameObject.GetComponent<Animator>();
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

    }


}
