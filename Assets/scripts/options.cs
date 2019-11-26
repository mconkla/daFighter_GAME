using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{

    public GameObject OptionsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //StaticClass.OPTIONS = "test";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToOption()
    {
        // hide current buttons
        
       this.gameObject.SetActive(false);
        // display new option menu
        OptionsCanvas.gameObject.SetActive(true);
    }
    public void ToStartmenu()
    {
        this.gameObject.SetActive(true);
        OptionsCanvas.gameObject.SetActive(false);
    }

    public void switchtoKeyboard()
    {

    }
    public void switchtoController()
    {

    }
}
