﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputModule : MonoBehaviour
{
    public bool isPlayer = true;

    public float horizontalInput,verticalInput;
    public bool punchInput, punchInputDown, punchInputUp,
        kickInput, kickInputDown, kickInputUp,
        heavyPunchInput, heavyPunchInputDown, heavyPunchInputUp,
        heavyKickInput, heavyKickInputDown, heavyKickInputUp;

    public bool blockInput, blockInputDown, blockInputUp,
        grabInput, grabInputDown, grabInputUp,
        jumpInput, jumpInputDown, jumpInputUp;

    private string 
        punchInputPlayer, kickInputPlayer, blockInputPlayer, heavyPunchInputPlayer, heavyKickInputPlayer,grabInputPlayer,
        horizontalPlayer, verticalPlayer= "";


    private void Start()
    {
        if (isPlayer)
        {
            horizontalPlayer = "Horizontal" + this.gameObject.tag.ToString();
            verticalPlayer = "Vertical" + this.gameObject.tag.ToString();
            punchInputPlayer = "Fire1" + this.gameObject.tag.ToString();
            kickInputPlayer = "Fire2" + this.gameObject.tag.ToString();
            heavyKickInputPlayer = "Fire3" + this.gameObject.tag.ToString();
            heavyPunchInputPlayer = "Fire4" + this.gameObject.tag.ToString();
            blockInputPlayer = "Bumper" + this.gameObject.tag.ToString();
            grabInputPlayer = "Grab" + this.gameObject.tag.ToString();
        }
    }

    public void update()
    {
        if (isPlayer)
        {
            this.grabInput = Input.GetButton(grabInputPlayer) == true ? true : false;
            this.grabInputDown = Input.GetButtonDown(grabInputPlayer) == true ? true : false;
            this.grabInputUp = Input.GetButtonUp(grabInputPlayer) == true ? true : false;

            this.heavyPunchInput = Input.GetButton(heavyPunchInputPlayer) == true ? true : false;
            this.heavyPunchInputDown = Input.GetButtonDown(heavyPunchInputPlayer) == true ? true : false;
            this.heavyPunchInputUp = Input.GetButtonUp(heavyPunchInputPlayer) == true ? true : false;

            this.heavyKickInput = Input.GetButton(heavyKickInputPlayer) == true ? true : false;
            this.heavyKickInputDown = Input.GetButtonDown(heavyKickInputPlayer) == true ? true : false;
            this.heavyKickInputUp = Input.GetButtonUp(heavyKickInputPlayer) == true ? true : false;

            this.kickInput = Input.GetButton(kickInputPlayer) == true ? true : false;
            this.kickInputDown = Input.GetButtonDown(kickInputPlayer) == true ? true : false;
            this.kickInputUp = Input.GetButtonUp(kickInputPlayer) == true ? true : false;

            this.punchInput = Input.GetButton(punchInputPlayer) == true ? true : false;
            this.punchInputDown = Input.GetButtonDown(punchInputPlayer) == true ? true : false;
            this.punchInputUp = Input.GetButtonUp(punchInputPlayer) == true ? true : false;

            this.verticalInput = Input.GetAxis(verticalPlayer);
            this.horizontalInput = Input.GetAxis(horizontalPlayer);

            this.blockInput = Input.GetButton(blockInputPlayer) == true ? true : false;
            this.blockInputDown = Input.GetButtonDown(blockInputPlayer) == true ? true : false;
            this.blockInputUp = Input.GetButtonUp(blockInputPlayer) == true ? true : false;
   

        }
    }
}
