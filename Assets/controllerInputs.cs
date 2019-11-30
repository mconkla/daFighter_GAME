using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerInputs : MonoBehaviour
{


    [HideInInspector]
    public string horizontal, vertical = "";
    [HideInInspector]
    public string punchInput, kickInput, blockInput, heavyPunch, heavyKick = "";

    [HideInInspector]
    public float heavyPunchState, heavyKickState = 0.0f;

    [HideInInspector]
    public bool crouched,jump, grounded, blocked,grabbed = false;

    [HideInInspector]
    public bool heavyAttack,lightAttack = false;

    [HideInInspector]
    public int staggerd = 0;

    [HideInInspector]
    public bool walkLeft, walkRight, lightPunchNormal,lightPunchCrouched,lightPunchAir,lightKickNormal,lightKickCrouched,lightKickAir,
        heavyPunchNormal,heavyPunchCrouched,heavyPunchAir,heavyKickNormal,heavyKickCrouched,heavyKickAir= false;


    // Start is called before the first frame update

    public Text debugText;
    private string testText = "";

    void Start()
    {
        horizontal = "Horizontal" + this.gameObject.tag.ToString();
        vertical = "Vertical" + this.gameObject.tag.ToString();
        punchInput = "Fire1" + this.gameObject.tag.ToString();
        kickInput = "Fire2" + this.gameObject.tag.ToString();
        heavyKick = "Fire3" + this.gameObject.tag.ToString();
        heavyPunch = "Fire4" + this.gameObject.tag.ToString();
        blockInput = "Bumper" + this.gameObject.tag.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        debugText.text = testText;

        heavyAttack = heavyKickAir || heavyKickCrouched || heavyKickNormal || heavyPunchAir || heavyPunchCrouched || heavyPunchNormal;
        lightAttack = lightKickAir || lightKickCrouched || lightKickNormal || lightPunchAir || lightPunchCrouched || lightPunchNormal;

        //Axen Input
        if (Input.GetAxis(horizontal) > 0.5 && !heavyAttack && !lightAttack)
        {
            if (!blocked && !crouched && !heavyAttack)
            {
                walkRight = true;
            }
        }
        else if (Input.GetAxis(horizontal) < -0.5 && !heavyAttack && !lightAttack)
        {
            if (!blocked && !crouched)
            {
                walkLeft = true;
            }
        }
        else
        {
            walkLeft = false;
            walkRight = false;
        }

        if (Input.GetAxis(vertical) > 0.2 && grounded && !blocked && !heavyAttack)
        {
            jump = true;
            grounded = false;
        }
        else if (Input.GetAxis(vertical) < -0.5)
        {
            crouched = true;
        }
        else
        {
            jump = false;
            crouched = false;
        }
        //Axen Input



        //light punches
        if (Input.GetButtonDown(punchInput) && !blocked && !crouched && grounded)
        {
            testText = "Standing LP";
            lightPunchNormal = true;
        }
        else if (Input.GetButtonDown(punchInput) && !blocked && crouched && grounded)
        {
            testText = "Crouching LP";
            lightPunchCrouched = true;
        }
        else if (Input.GetButtonDown(punchInput) && !blocked && !crouched && !grounded)
        {
            testText = "Air LP";
            lightPunchAir = true;
        }
        //light kicks

        else if (Input.GetButtonDown(kickInput) && !blocked && !crouched && grounded)
        { 
            testText = "Standing LK";
            lightKickNormal = true;         
        }
        else if (Input.GetButtonDown(kickInput) && !blocked && crouched && grounded)
        {
            testText = "Crouching LK";
            lightKickCrouched = true;
        }
        else if (Input.GetButtonDown(kickInput) && !blocked && !crouched && !grounded)
        {
            testText = "Air LK";
            lightKickAir = true;
        }

        //heavy Punches
        else if (Input.GetButton(heavyPunch) && heavyPunchState >= 0 && !blocked && !crouched && grounded)
        {
            heavyPunchState += (1f * Time.fixedDeltaTime);
            heavyPunchNormal = true;
            if (heavyPunchState > 1)
            {
                heavyPunchState = -1;
                testText = "Standing HP";
                heavyPunchNormal = false;
            }
        }
        else if (Input.GetButton(heavyPunch) && heavyPunchState >= 0 && !blocked && crouched && grounded)
        {
            heavyPunchState += (1f * Time.fixedDeltaTime);
            heavyPunchCrouched = true;
            if (heavyPunchState > 1)
            {
                heavyPunchState = -1;
                testText = "Crouching HP";
                heavyPunchCrouched = false;
            }
        }
        else if (Input.GetButton(heavyPunch) && heavyPunchState >= 0 && !blocked && !crouched && !grounded)
        {
            heavyPunchState += (1f * Time.fixedDeltaTime);
            heavyPunchAir = true;
            if (heavyPunchState > 1)
            {
                heavyPunchState = -1;
                testText = "Air HP";
                heavyPunchAir = false;
            }
        }
        else if (Input.GetButtonUp(heavyPunch) && !blocked)//on release
        {
            if (heavyPunchState != -1)
            {
                if(heavyPunchNormal)
                {
                    testText = "Standing HP";
                   
                }
                else if(heavyPunchCrouched)
                {
                    testText = "Crouching HP";
                              
                }
                else if(heavyPunchAir)
                {
                    testText = "Air HP";
                    
                }
            }
            heavyPunchState = 0;

            heavyPunchNormal = false;
            heavyPunchCrouched = false;
            heavyPunchAir = false;
        }


        //Heavy Kicks
        else if (Input.GetButton(heavyKick) && heavyKickState >= 0 && !blocked && !crouched && grounded)
        {
            heavyKickState += (1f * Time.fixedDeltaTime);
            heavyKickNormal = true;
            if (heavyKickState > 1)
            {
                heavyKickState = -1;
                testText = "Standing HK";
            }
        }
        else if (Input.GetButton(heavyKick) && heavyKickState >= 0 && !blocked && crouched && grounded)
        {
            heavyKickState += (1f * Time.fixedDeltaTime);
            heavyKickCrouched = true;
            if (heavyKickState > 1)
            {
                heavyKickState = -1;
                testText = "Crouching HK";
            }
        }
        else if (Input.GetButton(heavyKick) && heavyKickState >= 0 && !blocked && !crouched && !grounded)
        {
            heavyKickState += (1f * Time.fixedDeltaTime);
            heavyKickAir = true;
            if (heavyKickState > 1)
            {
                heavyKickState = -1;
                testText = "Air HK";
            }
        }
        else if (Input.GetButtonUp(heavyKick) && !blocked)//on release
        {
            if (heavyKickState != -1)
            {
                if (heavyKickNormal)
                {
                    testText = "Standing HK";
                }
                else if (heavyKickCrouched)
                {
                    testText = "Crouching HK";
                }
                else if (heavyKickAir)
                {
                    testText = "Air HK";
                }
            }
            heavyKickNormal = false;
            heavyKickCrouched = false;
            heavyKickAir = false;
            heavyKickState = 0;
        }
        else if (Input.GetButton(blockInput))
        {
            blocked = true;
            testText = "Blocking";
        }
        else if (Input.GetButtonUp(blockInput))//on release
        {
            blocked = false;
            testText = "Released Blocking";
        }
        else
        {
            lightPunchNormal = false;
            lightPunchCrouched = false;
            lightPunchAir = false;

            lightKickNormal = false;
            lightKickCrouched = false;
            lightKickAir = false;

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
