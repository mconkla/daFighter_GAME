using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerColliderSystem : MonoBehaviour
{
    public GameObject lightPunchNormalTrigger, lightKickNormalTrigger, heavyPunchNormalTrigger, heavyKickNormalTrigger;
    public GameObject lightPunchCrouchTrigger, lightKickCrouchTrigger, heavyPunchCrouchTrigger, heavyKickCrouchTrigger;
    public GameObject lightPunchAirTrigger, lightKickAirTrigger, heavyPunchAirTrigger, heavyKickAirTrigger,grabbTrigger;

    
 

    [HideInInspector]
    public int otherPlayer;

    [HideInInspector]
    public attackSystem parentObject;

    [HideInInspector]
    public float localScale;
    [HideInInspector]
    public bool crouched;


    // Start is called before the first frame update
    void Awake()
    {
        otherPlayer = this.gameObject.tag == "1" ? 2 : 1;
        parentObject = this.transform.GetComponentInParent<attackSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        localScale = parentObject.transform.localScale.x;
        crouched = parentObject.myControllerInputs.crouched;

    }

    
    
}
