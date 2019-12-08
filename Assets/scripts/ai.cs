using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public GameObject otherPlayer;
    [Range(1, 3)]
    public int difficulty = 1;
    public float maxDelay = 1;
    private bool grounded;
    public float groundDistance = 0.2f;
    private Vector3 down = new Vector3(0.0f, -1.0f, 0.0f);
    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Angriffe
    //Sprumgamgriff
    //crouchangriff
    //normal

    //kick
    //punch
    //heavykick
    //heavyPunch


    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        pos = otherPlayer.transform.position;
        distance = pos - this.transform.position;

        moveaway();
        evade();
        defense();
        attack();


    }

    float delayTime()
    {
        float value = 0;
        for (int n = 0; n < difficulty; n++)
        {
            float newValue = Random.value * maxDelay;
            value = (newValue > value) ? newValue : value;
        }
        return value;
    }

    void moveaway()
    {
        if (distance.x < 3.5f)
        {
            if (otherPlayer.GetComponent<controllerInputs>().grounded == true)
            {
                if (otherPlayer.GetComponent<controllerInputs>().crouched == true)
                {
                    if (otherPlayer.GetComponent<controllerInputs>().crouchBlocked == true)
                    {
                    }
                    else
                    {
                        //jump Back
                    }
                }
                else
                {
                    //move back
                }
            }
            else
            {
                //moveback
                //jump back
            }

        }
    }

    void evade()
    {
        float delay = delayTime();
        if (otherPlayer.GetComponent<controllerInputs>().grounded == true)
        {
            if (otherPlayer.GetComponent<controllerInputs>().crouched == true)
            {
                if (otherPlayer.GetComponent<controllerInputs>().crouchBlocked == true)
                {
                }
                else
                {
                    //jump
                }
            }
            else
            {
                //crouch
            }
        }
        else
        {
            //crouch
        }
    }

    void defense()
    {
        // do i want this here ?
        float delay = delayTime();
        if (otherPlayer.GetComponent<controllerInputs>().grounded == true)
        {
            if (otherPlayer.GetComponent<controllerInputs>().crouched == true)
            {
                if (otherPlayer.GetComponent<controllerInputs>().crouchBlocked == true)
                {
                }
                else
                {
                    //crouch block
                }
            }
            else
            {
                //block
            }
        }
        else
        {
            //block
        }

    }

    void attack()
    {
        float delay = delayTime();

        if (distance.x < 3.5f)
        {
            if (this.GetComponent<controllerInputs>().grounded != true)
            {
                if (otherPlayer.GetComponent<controllerInputs>().grounded != true)
                {
                    //air punch
                    //air heavy punch
                }
                else
                {
                    //air kick
                    //air heavy kick
                }
                    return;
            }
            if (otherPlayer.GetComponent<controllerInputs>().grounded == true)
            {
                if (otherPlayer.GetComponent<controllerInputs>().crouched == true)
                {
                    if (otherPlayer.GetComponent<controllerInputs>().crouchBlocked == true)
                    {
                        //heavy kick
                        //crouch heavy punch
                        //crouch heavy kick
                    }
                    else
                    {
                        //kick
                        //heavykick
                        //crouch punch
                        //heavy crouch punch
                        //crouch kick
                        //heavy crouch kick
                    }
                }
                else
                {
                    //pumch
                    //heavy Punch
                    //kick
                    //heavy kick
                    //crouch punch
                    //crouch heavy punch
                    // crouch kick
                    //heavy crouch kick
                }
            }
            else
            {
                //crouch und up
            }
        }
    }

}
