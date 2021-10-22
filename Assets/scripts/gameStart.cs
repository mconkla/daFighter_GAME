using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class gameStart : MonoBehaviour
{
    [HideInInspector]
    public GameObject playerFirst,playerSecond;
    public Transform player1, player2;
    public GameObject player1Text, player2Text;
    public speicher speicher;
    public Health healthBarPlayer1,healthBarPlayer2;

    [HideInInspector]
    public GameObject player1Object, player2Object;
    // Start is called before the first frame update
    void Awake()
    {
        speicher = FindObjectOfType<speicher>();

        playerFirst = speicher.player1;
        playerSecond = speicher.player2;
        player1Object = Instantiate(playerFirst, player1);
        player2Object = Instantiate(playerSecond, player2);




        player1Object.tag = "1";
        player2Object.tag = "2";
        player1Object.transform.GetChild(0).gameObject.tag = "1";
        player2Object.transform.GetChild(0).gameObject.tag = "2";


        player1Object.GetComponent<attackSystem>().healthBar = healthBarPlayer1;
        player2Object.GetComponent<attackSystem>().healthBar = healthBarPlayer2;
        healthBarPlayer1.player = player1Object.GetComponent<attackSystem>();
        healthBarPlayer2.player = player2Object.GetComponent<attackSystem>();


        player1Object.SetActive(true);
        player2Object.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
