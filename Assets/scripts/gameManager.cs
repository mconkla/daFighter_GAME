using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public Health player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOver();
    }


    void gameOver()
    {
        if(player1.dead || player2.dead)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
