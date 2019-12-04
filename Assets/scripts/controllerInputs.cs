using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerInputs : MonoBehaviour
{


    [HideInInspector]
    public string horizontal, vertical = "";
    [HideInInspector]
    public string punchInput, kickInput, blockInput, heavyPunch, heavyKick,grabbInput = "";

    [HideInInspector]
    public float heavyPunchState, heavyKickState = 0.0f;

    [HideInInspector]
    public bool crouched,jump, grounded, blocked,crouchBlocked,grabbed = false;

    [HideInInspector]
    public bool heavyAttack,lightAttack = false;

    [HideInInspector]
    public int staggerd = 0;

    [HideInInspector]
    public bool walkLeft, walkRight, lightPunchNormal,lightPunchCrouched,lightPunchAir,lightKickNormal,lightKickCrouched,lightKickAir,
        heavyPunchNormal,heavyPunchCrouched,heavyPunchAir,heavyKickNormal,heavyKickCrouched,heavyKickAir= false;

    [HideInInspector]
    public float dmgMultiplyer = 1;

    // Start is called before the first frame update

    public Text debugText;
    private string testText = "";

    [HideInInspector]
    public bool hitted = false;

    void Start()
    {
        horizontal = "Horizontal" + this.gameObject.tag.ToString();
        vertical = "Vertical" + this.gameObject.tag.ToString();
        punchInput = "Fire1" + this.gameObject.tag.ToString();
        kickInput = "Fire2" + this.gameObject.tag.ToString();
        heavyKick = "Fire3" + this.gameObject.tag.ToString();
        heavyPunch = "Fire4" + this.gameObject.tag.ToString();
        blockInput = "Bumper" + this.gameObject.tag.ToString();
        grabbInput = "Grabb" + this.gameObject.tag.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hitted)
        InputPlayer();
    }

    void InputPlayer()
    {
        debugText.text = testText;

        heavyAttack = heavyKickAir || heavyKickCrouched || heavyKickNormal || heavyPunchAir || heavyPunchCrouched || heavyPunchNormal;
        lightAttack = lightKickAir || lightKickCrouched || lightKickNormal || lightPunchAir || lightPunchCrouched || lightPunchNormal;

        //Axen Input
        if (Input.GetAxis(horizontal) > 0.5 && !heavyAttack && !lightAttack)
        {
            if (!blocked && !crouched && !heavyAttack)
            {
                Debug.Log("Hallo");
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
            if (heavyPunchState > 1.0f)
            {

                heavyPunchState = -0.2f;
                testText = "Standing HP";
                heavyPunchNormal = true;
                dmgMultiplyer = heavyPunchState;
            }
        }
        else if (Input.GetButton(heavyPunch) && heavyPunchState >= 0 && !blocked && crouched && grounded)
        {
            heavyPunchState += (1f * Time.fixedDeltaTime);
            if (heavyPunchState > 1)
            {
                heavyPunchState = -0.2f;
                testText = "Crouching HP";
                heavyPunchCrouched = true;
            }
        }
        else if (Input.GetButton(heavyPunch) && heavyPunchState >= 0 && !blocked && !crouched && !grounded)
        {
            heavyPunchState += (1f * Time.fixedDeltaTime);
            if (heavyPunchState > 1)
            {
                heavyPunchState = -1;
                testText = "Air HP";
                heavyPunchAir = true;
            }
        }
        else if (Input.GetButtonUp(heavyPunch) && !blocked)//on release
        {
            if (heavyPunchState != -0.2f)
            {
                heavyPunchNormal = true;
                heavyPunchCrouched = true;
                heavyPunchAir = true;
                if (heavyPunchNormal)
                {

                    testText = "Standing HP";

                }
                else if (heavyPunchCrouched)
                {
                    testText = "Crouching HP";

                }
                else if (heavyPunchAir)
                {
                    testText = "Air HP";

                }

            }
            dmgMultiplyer = heavyPunchState;
            heavyPunchState = 0;
        }


        //Heavy Kicks
        else if (Input.GetButton(heavyKick) && heavyKickState >= 0 && !blocked && !crouched && grounded)
        {
            heavyKickState += (1f * Time.fixedDeltaTime);
            if (heavyKickState > 1)
            {
                heavyKickState = -1;
                testText = "Standing HK";
                heavyKickNormal = true;
            }
        }
        else if (Input.GetButton(heavyKick) && heavyKickState >= 0 && !blocked && crouched && grounded)
        {
            heavyKickState += (1f * Time.fixedDeltaTime);
            if (heavyKickState > 1)
            {
                heavyKickState = -1;
                testText = "Crouching HK";
                heavyKickCrouched = true;
            }
        }
        else if (Input.GetButton(heavyKick) && heavyKickState >= 0 && !blocked && !crouched && !grounded)
        {
            heavyKickState += (1f * Time.fixedDeltaTime);
            if (heavyKickState > 1)
            {
                heavyKickState = -1;
                testText = "Air HK";
                heavyKickAir = true;
            }
        }
        else if (Input.GetButtonUp(heavyKick) && !blocked)//on release
        {
            if (heavyKickState != -1)
            {
                heavyKickNormal = true;
                heavyKickCrouched = true;
                heavyKickAir = true;
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
            dmgMultiplyer = heavyPunchState;
            heavyKickState = 0;
        }
        //blocking
        else if (Input.GetButton(blockInput) && !crouched)
        {
            blocked = true;
            testText = "Blocking";
        }
        else if (Input.GetButton(blockInput) && crouched)
        {
            crouchBlocked = true;
            testText = "CrouchBlocking";
        }
        else if (Input.GetButtonUp(blockInput))//on release
        {
            blocked = false;
            crouchBlocked = false;
            testText = "Released Blocking";
        }

        //grabbing
        else if (Input.GetButtonDown(grabbInput))
        {
            grabbed = true;
        }
        //reset attacks
        else
        {
            lightPunchNormal = false;
            lightPunchCrouched = false;
            lightPunchAir = false;

            lightKickNormal = false;
            lightKickCrouched = false;
            lightKickAir = false;

            heavyPunchNormal = false;
            heavyPunchCrouched = false;
            heavyPunchAir = false;

            heavyKickNormal = false;
            heavyKickCrouched = false;
            heavyKickAir = false;


            grabbed = false;

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
