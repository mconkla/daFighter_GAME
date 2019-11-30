using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class attackSystem : MonoBehaviour
{
    public Health healthBar;

    [Range(0f, 2f)]
    public float delayToHit = 0.2f;
    [Range(0.1f, 3f)]
    public float punchDMG = 1f;
    [Range(0.5f, 4.5f)]
    public float kickDMG = 2f;

    [HideInInspector]
    public string myText = "Hallo";

    private float DMG = 0;
    private controllerInputs        myControllerInputs;
    private triggerColliderSystem   myTriggerColliderSystem;
    private triggerScript           currentTriggerScript;

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
            myText = "lightPunchNormal : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightPunchCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.lightPunchCrouchTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightPunchCrouched : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightPunchAir)
        {
            currentTriggerScript = myTriggerColliderSystem.lightPunchAirTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightPunchAir : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightKickNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickNormalTrigger.GetComponent<triggerScript>();
            DMG = kickDMG;
            myText = "lightKickNormal : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightKickCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickCrouchTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightKickCrouched : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightKickAir)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickAirTrigger.GetComponent<triggerScript>();
            DMG = punchDMG;
            myText = "lightKickAir : " + currentTriggerScript.dmg;
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

        if (currentTriggerScript != null)
        {
            currentTriggerScript.timeStamp = Time.time;
            spawnTriggerDelayed(currentTriggerScript);
            currentTriggerScript.dmg = DMG;
            currentTriggerScript = null;
        }

        if (myControllerInputs.blocked)
        {
            myText = "BLOCKING : ";
        }

        async void spawnTriggerDelayed(triggerScript currentTriggerScript)
        {
            Debug.Log("Waiting");
            await Task.Delay(TimeSpan.FromSeconds(delayToHit));
            currentTriggerScript.triggerOn = true;
            Debug.Log("Done!");
        }
    }
}
