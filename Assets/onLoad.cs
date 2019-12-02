using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLoad : MonoBehaviour
{

    [HideInInspector]
    public int playerNumber;

    [HideInInspector]
    public Transform MainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        MainCamera = FindObjectOfType<CameraScript>().transform;
        playerNumber = this.gameObject.tag == "1" ? 1 : 2;
        MainCamera.GetChild(playerNumber-1).GetComponent<Health>().player = this.gameObject.GetComponent<attackSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
