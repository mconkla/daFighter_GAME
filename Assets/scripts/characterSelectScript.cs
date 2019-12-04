using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class characterSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    private MyButton button;
    void Start()
    {
        button = GetComponent<MyButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSelect()
    {
        button.interactable = false;
        MyEventSystem eventSystem = (MyEventSystem)(this.GetComponent<MyEventSystemProvider>().eventSystem);
        eventSystem.submitted = true;
        
        eventSystem.speicher.setChar(this.transform.GetChild(0).GetComponent<Text>().text, eventSystem.tag);
            
    }
  
}
