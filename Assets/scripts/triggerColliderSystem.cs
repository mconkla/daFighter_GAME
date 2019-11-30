using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerColliderSystem : MonoBehaviour
{
    public GameObject lightPunchNormalTrigger, lightKickNormalTrigger, heavyPunchNormalTrigger, heavyKickNormalTrigger;
    public GameObject lightPunchCrouchTrigger, lightKickCrouchTrigger, heavyPunchCrouchTrigger, heavyKickCrouchTrigger;
    public GameObject lightPunchAirTrigger, lightKickAirTrigger, heavyPunchAirTrigger, heavyKickAirTrigger;

    
 

    [HideInInspector]
    public int otherPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        otherPlayer = this.gameObject.tag == "1" ? 2 : 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
