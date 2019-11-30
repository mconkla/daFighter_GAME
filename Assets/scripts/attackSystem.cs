using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class attackSystem : MonoBehaviour
{
    public Health healthBar;
    //Light Punch
    [Range(0.1f, 3f)]
    public float DMGLightPunchNormal = 1f;
    [Range(0f, 2f)]
    public float delayToHitLightPunchNormal = 0.2f;
    [Range(0.1f, 3f)]
        //crouched
    public float DMGLightPunchCrouched = 1f;
    [Range(0f, 2f)]
    public float delayToHitLightPunchCrouched = 0.2f;
        //air
    [Range(0.1f, 3f)]
    public float DMGLightPunchAir = 1f;
    [Range(0f, 2f)]
    public float delayToHitLightPunchAir = 0.2f;
    //Light Kick
    [Range(0.1f, 3f)]
    public float DMGLightKickNormal = 1f;
    [Range(0f, 2f)]
    public float delayToHitLightKickNormal = 0.2f;
        //crouched
    [Range(0.1f, 3f)]
    public float DMGLightKickCrouched = 1f;
    [Range(0f, 2f)]
    public float delayToHitLightKickCrouched = 0.2f;
        //air
    [Range(0.1f, 3f)]
    public float DMGLightKickAir = 1f;
    [Range(0f, 2f)]
    public float delayToHitLightKickAir = 0.2f;

    //heavy Punch
    [Range(0.1f, 3f)]
    public float DMGHeavyPunchNormal = 1f;
    [Range(0f, 2f)]
    public float delayToHitHeavyPunchNormal = 0.2f;
        //crouched
    [Range(0.1f, 3f)]
    public float DMGHeavyPunchCrouched = 1f;
    [Range(0f, 2f)]
    public float delayToHitHeavyPunchCrouched = 0.2f;
        //air
    [Range(0.1f, 3f)]
    public float DMGHeavyPunchAir = 1f;
    [Range(0f, 2f)]
    public float delayToHitHeavyPunchAir = 0.2f;
    //heavy Kick
    [Range(0.1f, 3f)]
    public float DMGHeavyKickNormal = 1f;
    [Range(0f, 2f)]
    public float delayToHitHeavyKickNormal = 0.2f;
        //crouched
    [Range(0.1f, 3f)]
    public float DMGHeavyKickCrouched = 1f;
    [Range(0f, 2f)]
    public float delayToHitHeavyKickCrouched = 0.2f;
        //air
    [Range(0.1f, 3f)]
    public float DMGHeavyKickAir = 1f;
    [Range(0f, 2f)]
    public float delayToHitHeavyKickAir = 0.2f;

    [HideInInspector]
    public string myText = "Hallo";

    private float DMG = 0;
    private float delayToHit = 0.2f;
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
            DMG = DMGLightPunchNormal;
            delayToHit = delayToHitLightPunchNormal;
            myText = "lightPunchNormal : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightPunchCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.lightPunchCrouchTrigger.GetComponent<triggerScript>();
            DMG = DMGLightPunchCrouched;
            delayToHit = delayToHitLightPunchCrouched;
            myText = "lightPunchCrouched : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightPunchAir)
        {
            currentTriggerScript = myTriggerColliderSystem.lightPunchAirTrigger.GetComponent<triggerScript>();
            DMG = DMGLightPunchAir;
            delayToHit = delayToHitLightPunchAir;
            myText = "lightPunchAir : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightKickNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickNormalTrigger.GetComponent<triggerScript>();
            DMG = DMGLightKickNormal;
            delayToHit = delayToHitLightKickNormal;
            myText = "lightKickNormal : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightKickCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickCrouchTrigger.GetComponent<triggerScript>();
            DMG = DMGLightKickCrouched;
            delayToHit = delayToHitLightKickCrouched;
            myText = "lightKickCrouched : " + currentTriggerScript.dmg;
        }
        else if (myControllerInputs.lightKickAir)
        {
            currentTriggerScript = myTriggerColliderSystem.lightKickAirTrigger.GetComponent<triggerScript>();
            DMG = DMGLightKickAir;
            delayToHit = delayToHitLightKickAir;
            myText = "lightKickAir : " + currentTriggerScript.dmg;
        }

        else if (myControllerInputs.heavyPunchNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyPunchNormalTrigger.GetComponent<triggerScript>();
            DMG = DMGHeavyPunchNormal;
            delayToHit = delayToHitHeavyPunchNormal;
            myText = "heavyPunching Normal" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyPunchCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyPunchCrouchTrigger.GetComponent<triggerScript>();
            DMG = DMGHeavyPunchCrouched;
            delayToHit = delayToHitHeavyPunchCrouched;
            myText = "heavyPunching Crouched" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyPunchAir)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyPunchAirTrigger.GetComponent<triggerScript>();
            DMG = DMGHeavyPunchAir;
            delayToHit = delayToHitHeavyPunchAir;
            myText = "heavyPunching Air" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyKickNormal)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyKickNormalTrigger.GetComponent<triggerScript>();
            DMG = DMGHeavyKickNormal;
            delayToHit = delayToHitHeavyKickNormal;
            myText = "heavyKick Normal" + myControllerInputs.heavyKickState;
        }
        else if (myControllerInputs.heavyKickCrouched)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyKickCrouchTrigger.GetComponent<triggerScript>();
            DMG = DMGHeavyKickCrouched;
            delayToHit = delayToHitHeavyKickCrouched;
            myText = "heavyKick Crouched" + myControllerInputs.heavyKickState;
        }
        else if (myControllerInputs.heavyKickAir)
        {
            currentTriggerScript = myTriggerColliderSystem.heavyKickAirTrigger.GetComponent<triggerScript>();
            DMG = DMGHeavyKickAir;
            delayToHit = delayToHitHeavyKickAir;
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
            await Task.Delay(TimeSpan.FromSeconds(delayToHit));
            currentTriggerScript.triggerOn = true;
        }
    }
}
