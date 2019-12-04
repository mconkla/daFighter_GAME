using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textShow : MonoBehaviour
{
    public attackSystem mySystem;
    public gameStart gameStart;
    public Text attackText;
    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "1")
        {
            mySystem = gameStart.player1Object.GetComponent<attackSystem>();
            Debug.Log(mySystem.tag);

        }
        else if(this.tag == "2")
        {
            mySystem = gameStart.player2Object.GetComponent<attackSystem>();
            Debug.Log(mySystem.tag);
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackText.text = mySystem.myText;
        
    }
}
