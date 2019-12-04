using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speicher : MonoBehaviour
{
    public GameObject[] characterList;

    public GameObject player1, player2;

    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setChar(string name,string player)
    {
        if (player.Equals("1"))
        {
            switch (name)
            {
                case "BigBob":
                    player1 = characterList[0];
                    break;

                case "RobotChickenMan70":
                    player1 = characterList[2];
                    break;

                case "Beegee":
                    player1 = characterList[1];
                    break;

                default:
                    break;
            }
        }
        else
        {
            switch (name)
            {
                case "BigBob":
                    player2 = characterList[0];
                    break;

                case "RobotChickenMan70":
                    player2 = characterList[2];
                    break;

                case "Beegee":
                    player2 = characterList[1];
                    break;

                default:
                    break;
            }
        }


    }
}
