using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attackSystem : MonoBehaviour
{
    
    [HideInInspector]
    public string myText = "Hallo";

    private float DMG = 0;

    [Range(0.1f, 3f)]
    public float punchDMG = 1f;

    [Range(0.5f, 4.5f)]
    public float kickDMG = 2f;


    public Health healthBar;

    [HideInInspector]
    public controllerInputs myControllerInputs;
    private triggerColliderSystem myTriggerColliderSystem;
    private triggerScript currentTriggerScript;

    // Start is called before the first frame update
    void Start()
    {
        myControllerInputs = this.gameObject.GetComponent<controllerInputs>();
        myTriggerColliderSystem = this.gameObject.transform.GetChild(0).GetComponent<triggerColliderSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();

    }


    private void InputPlayer()
    {
        if (myControllerInputs.lightPunchNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightPunchNormal : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightPunchCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.lightPunchCrouchTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightPunchCrouched : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightPunchAir)
        {
            currentTriggerScript = myTriggerColliderSystem.lightPunchAirTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightPunchAir : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightKickNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickNormalTrigger.GetComponent<triggerScript>();
            DMG = kickDMG;
            myText = "lightKickNormal : " + myTriggerColliderSystem.lightKickNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightKickCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickCrouchTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightKickCrouched : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightKickAir)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickAirTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightKickAir : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.heavyPunchNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyPunchNormalTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "heavyPunching Normal" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyPunchCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyPunchCrouchTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "heavyPunching Crouched" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyPunchAir)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyPunchAirTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "heavyPunching Air" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyKickNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyKickNormalTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "heavyKick Normal" + myControllerInputs.heavyKickState;
        }
        else if (myControllerInputs.heavyKickCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyKickCrouchTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "heavyKick Crouched" + myControllerInputs.heavyKickState;
        }
        else if (myControllerInputs.heavyKickAir)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyKickAirTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "heavyKick Air" + myControllerInputs.heavyKickState;
        }
        else if (myControllerInputs.grabbed)
        {
            currentTriggerScript = myTriggerColliderSystem.grabbTrigger.GetComponent<triggerScript>();
            DMG = 0;
            
        }

        if (currentTriggerScript != null)
        {
            currentTriggerScript.timeStamp = Time.time;
            currentTriggerScript.triggerOn = true;
            currentTriggerScript.dmg = DMG;
            currentTriggerScript = null;
        }

        if (myControllerInputs.blocked)
        {
            myText = "BLOCKING : ";
        }
    }
}
