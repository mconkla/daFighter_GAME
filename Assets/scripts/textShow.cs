using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textShow : MonoBehaviour
{
    public attackSystem mySystem;
    public Text attackText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackText.text = mySystem.myText;
        
    }
}
