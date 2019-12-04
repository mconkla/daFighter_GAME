using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public attackSystem player;

    [HideInInspector]
    public SpriteRenderer sprite;

    [HideInInspector]
    public bool dead = false;

    public CameraScript mainCam;


    private void Awake()
    {
        }
    // Start is called before the first frame update
    void Start()
    {
        sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();


        
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void onHit(float attackDamage)
    {
        player.hitted = true;
        player.timeStamp = Time.time;


        if (sprite.size.x > 0 + attackDamage)
        {
            sprite.size += new Vector2(-attackDamage, 0);

            if(attackDamage > 0)
            {
                mainCam.TriggerShake();
            }
        }

        else
        {
            dead = true;
            sprite.size = new Vector2(0, 0);
        }
    }

    
}
