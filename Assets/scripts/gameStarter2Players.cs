using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStarter2Players : MonoBehaviour
{
    public MyEventSystem player1,player2;

    public GameObject startScreen,sureScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        askAgain();
        checkInput();
    }

    void askAgain()
    {
        if (player2.submitted && player1.submitted)
        {
           foreach( MyButton button in startScreen.GetComponentsInChildren<MyButton>())
           {
                button.interactable = false;
           }
            sureScreen.transform.GetChild(2).GetComponent<MyButton>().interactable = true;
            sureScreen.SetActive(true);
            foreach (MyEventSystem systemEvent in this.GetComponentsInChildren<MyEventSystem>())
            {
                systemEvent.SetSelectedGameObject(sureScreen.transform.GetChild(2).gameObject);
            }
            player2.submitted = player1.submitted = false;
        }
        
    }
    public void resetSelect()
    {
        if (!player2.submitted && !player1.submitted)
        {
            foreach (MyButton button in startScreen.GetComponentsInChildren<MyButton>())
            {
                button.interactable = true;
            }
            sureScreen.transform.GetChild(2).GetComponent<MyButton>().interactable = false;
            sureScreen.SetActive(false);
            player1.SetSelectedGameObject(startScreen.transform.GetChild(2).gameObject);
            player2.SetSelectedGameObject(startScreen.transform.GetChild(6).gameObject);

        }
        else
        {
            SceneManager.LoadScene(0);
        }
        player2.submitted = player1.submitted = false;

    }
    void checkInput()
    {
        if (Input.GetButton("Fire21") || Input.GetButton("Fire22")){
            startScreen.SetActive(false);
            sureScreen.SetActive(true);
            foreach (MyEventSystem systemEvent in this.GetComponentsInChildren<MyEventSystem>())
            {
                systemEvent.SetSelectedGameObject(sureScreen.transform.GetChild(2).gameObject);
            }
        }
    }
}
