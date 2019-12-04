using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class launch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchDual()
    {

        SceneManager.LoadScene("Characterselect");

    }

    public void launchSingle()
    {



    }

    public void launchMultiplayer()
    {
       
        
        

        SceneManager.LoadScene(2);
    }
}
