using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attackSystem : MonoBehaviour
{
    
    [HideInInspector]
    public string myText = "Hallo";
    [Range(0.1f, 3f)]
    public float punchDMG = 1f;
    [Range(0.5f, 4.5f)]
    public float kickDMG = 2f;


    public Health healthBar;

    
   
    private controllerInputs myControllerInputs;
    private triggerColliderSystem myTriggerColliderSystem;

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
            myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().timeStamp = Time.time;
            myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().triggerOn = true;
            myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg = punchDMG;
            myText = "lightPunchNormal : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightPunchCrouched)
        {
            myText = "lightPunchCrouched : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightPunchAir)
        {
            myText = "lightPunchAir : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightKickNormal)
        {
            myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().timeStamp = Time.time;
            myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().triggerOn = true;
            myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg = kickDMG;
            myText = "lightKickNormal : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightKickCrouched)
        {
            myText = "lightKickCrouched : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.lightKickAir)
        {
            myText = "lightKickAir : " + myTriggerColliderSystem.lightPunchNormalTrigger.GetComponent<triggerScript>().dmg;
        }
        else if (myControllerInputs.heavyPunchNormal)
        {
            myText = "heavyPunching Normal" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyPunchCrouched)
        {
            myText = "heavyPunching Crouched" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyPunchAir)
        {
            myText = "heavyPunching Air" + myControllerInputs.heavyPunchState;
        }
        else if (myControllerInputs.heavyKickNormal)
        {
            myText = "heavyKick Normal" + myControllerInputs.heavyKickState;
        }
        else if (myControllerInputs.heavyKickCrouched)
        {
            myText = "heavyKick Crouched" + myControllerInputs.heavyKickState;
        }
        else if (myControllerInputs.heavyKickAir)
        {
            myText = "heavyKick Air" + myControllerInputs.heavyKickState;
        }
        if (myControllerInputs.blocked)
        {
            myText = "BLOCKING : ";
        }
    }
}
