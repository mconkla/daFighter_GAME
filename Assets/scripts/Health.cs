using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public playerMove player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.punch)
        {
            Debug.Log("Hallo");
            onHit();
            player.punch = false;
        }
    }


    public void onHit()
    {
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().size += new Vector2(-0.1f, 0);
    }
}
