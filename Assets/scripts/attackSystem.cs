using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSystem : MonoBehaviour
{
    [HideInInspector]
    public string punchInput,kickInput = "";
    [HideInInspector]
    public int otherPlayer;
    [HideInInspector]
    public bool punch, kick = false;

    public Health healthBar;

    [Range (0.01f,0.5f)]
    public float punchDMG = 0.01f;
    [Range(0.01f, 0.5f)]
    public float kickDMG = 0.05f;

    // Start is called before the first frame update
    void Start()
    {

        punchInput = "Fire1" + this.gameObject.tag.ToString();
        kickInput = "Fire2" + this.gameObject.tag.ToString();
        otherPlayer = this.gameObject.tag == "1" ? 2 : 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void dmgTaken(float dmg)
    {
        healthBar.onHit(dmg);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == otherPlayer.ToString())
        {

            if (Input.GetButton(punchInput))
            {
                Debug.Log("Punc" + punchInput);
                collision.GetComponent<attackSystem>().dmgTaken(punchDMG);

            }
            else if (Input.GetButton(kickInput))
            {
                collision.GetComponent<attackSystem>().dmgTaken(kickDMG);
            }
        }
    }
}
