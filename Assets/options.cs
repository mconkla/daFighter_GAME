using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StaticClass.OPTIONS = "test";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void option()
    {
        // hide current buttons
        foreach (Transform child in transform){
            child.gameObject.SetActive(false);
        }
           
        // display new option menu

    }
}
