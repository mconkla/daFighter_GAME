using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerInputs : MonoBehaviour
{
    
    public inputModule myInputModule;

//    [HideInInspector]
    public bool 
        crouched,jump, grounded, blocked,crouchBlocked,grabbed,
        heavyAttack,lightAttack,
        walkLeft, walkRight, 
        lightPunchNormal,lightPunchCrouched,lightPunchAir,lightKickNormal,lightKickCrouched,lightKickAir,
        heavyPunchNormal,heavyPunchCrouched,heavyPunchAir,heavyKickNormal,heavyKickCrouched,heavyKickAir
        = false;

    public float heavyPunchState, heavyKickState = 0.0f;
    public int staggerd = 0;
    public float dmgMultiplyer = 1;
    public bool hitted = false;

    // Update is called once per frame
    void Update()
    {
        if (!hitted)
        {
            myInputModule.update();
            InputPlayer();
        }
            

        this.debugInputs();
    }

    void InputPlayer()
    {
        heavyAttack = heavyKickAir || heavyKickCrouched || heavyKickNormal || heavyPunchAir || heavyPunchCrouched || heavyPunchNormal;
        lightAttack = lightKickAir || lightKickCrouched || lightKickNormal || lightPunchAir || lightPunchCrouched || lightPunchNormal;

        this.horizontalInputs();
        this.verticalInputs();
        this.lightInputs();
        this.heavyInputs();
        this.blockInputs();
        this.grabInputs();
        
    }

    private void grabInputs()
    {
        if (myInputModule.grabInputDown)
        {
            grabbed = true;
        }
        if(myInputModule.grabInputUp)//on release
        {
            grabbed = false;
        }
    }

    /*
     * blocked for normal blocking
     * crouchBlocked for crouch blocking
     */
    private void blockInputs()
    {
        if (myInputModule.blockInput && !crouched)
        {
            blocked = true;
        } 
        else if (myInputModule.blockInput && crouched)
        {
            crouchBlocked = true;
        } 
        if (myInputModule.blockInputUp)//on release
        {
            blocked = false;
            crouchBlocked = false;
        }

    }

     /*
     * light punches can only be executed when not blocking
     * light punch normal and light kick normal only executeable when not crouching and being grounded
     * light punch air and light kick air only executeable when not crouched and not grounded
     * light punch crouched and light kick crouched only executeable when crouched and grounded
     */
    private void lightInputs()
    {
        if (!blocked)
        {
            if(!crouched && grounded)
            {
                if (myInputModule.punchInputDown)
                {
                    lightPunchNormal = true;
                }
                else if (myInputModule.punchInputUp)
                {
                    lightPunchNormal = false;
                }
                if (myInputModule.kickInputDown)
                {
                    lightKickNormal = true;
                }
                else if (myInputModule.kickInputUp)
                {
                    lightKickNormal = false;
                }
            }
            else if(!crouched && !grounded)
            {
                if (myInputModule.punchInputDown)
                {
                    lightPunchAir = true;
                }
                else if (myInputModule.punchInputUp)
                {
                    lightPunchAir = false;
                }
                if (myInputModule.kickInputDown)
                {
                    lightKickAir = true;
                }
                else if (myInputModule.kickInputUp)
                {
                    lightKickAir = false;
                }
            }
            else if(crouched && grounded)
            {
                if (myInputModule.punchInputDown)
                {
                    lightPunchCrouched = true;
                }
                else if (myInputModule.punchInputUp)
                {
                    lightPunchCrouched = false;
                }
                if (myInputModule.kickInputDown)
                {
                    lightKickCrouched = true;
                }
                else if (myInputModule.kickInputUp)
                {
                    lightKickCrouched = false;
                }
            }
        }
    }


    /*
     * heavy attacks can only be executed when not blocking
     * heavy punch and kick normal can only be executed when not crouching and being grounded
     * heavy punch and kick crouched can only be executed when being crouched and being grounded
     * heavy punch and kick air can only be executed when not crouching and not grounded
     */
    private void heavyInputs()
    {
        if (!blocked)
        {
            if(!crouched && grounded)
            {
                this.releaseHeavy("normal");
                if (myInputModule.heavyPunchInput && heavyPunchState >= 0)
                {
                    this.heavyPunchStateChanger();
                }
                if (myInputModule.heavyKickInput && heavyKickState >= 0)
                {
                    this.heavyKickStateChanger();
                }
                if (!myInputModule.heavyPunchInputUp)
                {
                    heavyPunchNormal = false;
                }
                if (!myInputModule.heavyKickInputUp)
                {
                    heavyKickNormal = false;
                }
            }
            else if (crouched && grounded)
            {
                this.releaseHeavy("crouched");
                if (myInputModule.heavyPunchInput && heavyPunchState >= 0)
                {
                    this.heavyPunchStateChanger();
                }
                if (myInputModule.heavyKickInput && heavyKickState >= 0)
                {
                    this.heavyKickStateChanger();
                }
                if (!myInputModule.heavyPunchInputUp)
                {
                    heavyPunchCrouched = false;
                }
                if (!myInputModule.heavyKickInputUp)
                {
                    heavyKickCrouched = false;
                }

            }
            else if(!crouched && !grounded)
            {
                this.releaseHeavy("air");
                if (myInputModule.heavyPunchInput && heavyPunchState >= 0)
                {
                    this.heavyPunchStateChanger();
                }
                if (myInputModule.heavyKickInput && heavyKickState >= 0)
                {
                    this.heavyKickStateChanger();
                }
                if (!myInputModule.heavyPunchInputUp)
                {
                    heavyPunchAir = false;
                }
                if (!myInputModule.heavyKickInputUp)
                {
                    heavyKickAir = false;
                }

            }   
        }
    }

    
    /*
     * a heavy attak will multiply normal dmg when hitting 100% on holding the button down
     */
    private void heavyKickStateChanger()
    {
        if(heavyKickState != -1)
        {
            heavyKickState += (1f * Time.deltaTime);
        }
        if (heavyKickState > 1.0f)
        {
            heavyKickState = -1;
            dmgMultiplyer = 1.5f;
        }
    }

    /*
     * a heavy attak will multiply normal dmg when hitting 100% on holding the button down
     */
    private void heavyPunchStateChanger()
    {
        if(heavyPunchState != -0.2f)
        {
            heavyPunchState += (1f * Time.deltaTime);
        }
        if (heavyPunchState > 1.0f)
        {
            heavyPunchState = -0.2f;
            dmgMultiplyer = 1.5f;
        }
    }

    /*
     * if heavy input is being released the heavy state will be set to 0 again
     */
    private void releaseHeavy(string type)
    {
        if (myInputModule.heavyPunchInputUp)
        {
            if (heavyPunchState != -0.2f)
            {
                dmgMultiplyer = 1f;
            }
            switch (type)
            {
                case "normal":
                    heavyPunchNormal = true;
                    break;
                case "crouched":
                    heavyPunchCrouched = true;
                    break;
                case "air":
                    heavyPunchAir = true;
                    break;
            }
            heavyPunchState = 0;
        }
        else if (myInputModule.heavyKickInputUp)
        {
            if (heavyKickState != -1)
            {
                dmgMultiplyer = 1f;
            }
            switch (type)
            {
                case "normal":
                    heavyKickNormal = true;
                    break;
                case "crouched":
                    heavyKickCrouched = true;
                    break;
                case "air":
                    heavyKickAir = true;
                    break;
            }
            heavyKickState = 0;
        } 
    }

   
    /*
     * only walk when not performing any attack block or crouch
     */
    private void horizontalInputs()
    {
         if(!heavyAttack && !lightAttack && !crouched && !blocked)
         {
                if (myInputModule.horizontalInput > 0.5)
                {
                    walkRight = true;
                }
                else if (myInputModule.horizontalInput < -0.5)
                {
                    walkLeft = true;
                }
                else
                {
                    walkLeft = false;
                    walkRight = false;
                }
         }
    }
    
    /*
     * only jump when grounded and not inside an heavy attack
     * 
     */
    private void verticalInputs()
    {
           if (myInputModule.verticalInput > 0.2 && grounded && !heavyAttack)
           {
                jump = true;
                grounded = false;
           }
           else if (myInputModule.verticalInput < -0.5)
           {
                crouched = true;
           }
           else
           {
                jump = false;
                crouched = false;
           }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "floor")
        {
            grounded = true;
        }
    }




    
    private void debugInputs()
    {        
        if (crouched)
        {
            Debug.Log("debugInputs: crouched");
        }
        else if (jump)
        {
            Debug.Log("debugInputs: jump");
        }
        else if (blocked)
        {
            Debug.Log("debugInputs: blocked");
        }


        if (lightPunchNormal)
        {
            Debug.Log("debugInputs: lightPunchNormal");
        }
        else if (lightPunchCrouched)
        {
            Debug.Log("debugInputs: lightPunchCrouched");
        }
        else if (lightPunchAir)
        {
            Debug.Log("debugInputs: lightPunchAir");
        }
        else if (lightKickNormal)
        {
            Debug.Log("debugInputs: lightKickNormal");
        }
        else if (lightKickCrouched)
        {
            Debug.Log("debugInputs: lightKickCrouched");
        }
        else if (lightKickAir)
        {
            Debug.Log("debugInputs: lightKickAir");
        }

        if (heavyPunchNormal)
        {
            Debug.Log("debugInputs: heavyPunchNormal : " + this.dmgMultiplyer);
        }
        else if (heavyPunchCrouched)
        {
            Debug.Log("debugInputs: heavyPunchCrouched : " + this.dmgMultiplyer);
        }
        else if (heavyPunchAir)
        {
            Debug.Log("debugInputs: heavyPunchAir : " + this.dmgMultiplyer);
        }
        else if (heavyKickNormal)
        {
            Debug.Log("debugInputs: heavyKickNormal : " + this.dmgMultiplyer);
        }
        else if (heavyKickCrouched)
        {
            Debug.Log("debugInputs: heavyKickCrouched : " + this.dmgMultiplyer);
        }
        else if (heavyKickAir)
        {
            Debug.Log("debugInputs: heavyKickAir : " + this.dmgMultiplyer);
        }
    }

}
