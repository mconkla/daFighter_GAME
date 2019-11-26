using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attackSystem : MonoBehaviour
{
    [HideInInspector]
    public string punchInput,kickInput,blockInput = "";
    [HideInInspector]
    public int otherPlayer;
    [HideInInspector]
    public bool punch, kick,blocked = false;

    public Health healthBar;

    [Range (0.01f,0.5f)]
    public float punchDMG = 0.01f;

    [HideInInspector]
    public string myText = "";

    float dmg = 0f;
    [Range(0.01f, 0.5f)]
    public float kickDMG = 0.05f;

    public CircleCollider2D hitBox;

    [HideInInspector]
    public bool triggerOn = false;

    float timeStamp;


    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<CircleCollider2D>();
        punchInput = "Fire1" + this.gameObject.tag.ToString();
        kickInput = "Fire2" + this.gameObject.tag.ToString();
        blockInput = "Fire3" + this.gameObject.tag.ToString();
        otherPlayer = this.gameObject.tag == "1" ? 2 : 1;

    }

    // Update is called once per frame
    void Update()
    {

        hitBox.enabled = triggerOn;
        InputPlayer();

      
        setTriggerFalse();
       
        
       
    }


    private void InputPlayer()
    {
        if (Input.GetButtonDown(punchInput) && !blocked){

            this.gameObject.GetComponent<Animator>().SetBool("punch", true);

            timeStamp = Time.time;
            triggerOn = true;
            dmg = punchDMG;
            myText = "PUNCH : " + dmg;
            
           

        }
        else if(Input.GetButtonDown(kickInput) && !blocked)
        {

            this.gameObject.GetComponent<Animator>().SetBool("kick", true);
            timeStamp = Time.time;
            triggerOn = true;
            dmg = kickDMG;

            myText = "KICK : " + dmg;
            

        }
        else if (Input.GetButton(blockInput))
        {

            blocked = true;
            myText = "BLOCK : " + dmg;
            this.gameObject.GetComponent<Animator>().SetBool("block", true);
        }
        else if (Input.GetButtonUp(blockInput))
        {
            blocked = false;
            myText = "";
            this.gameObject.GetComponent<Animator>().SetBool("block", false);
            Debug.Log("ICH BLOCKE NICHT MEHR");
        }

    }

    private void setTriggerFalse()
    {
      
        if (triggerOn && Time.time - timeStamp > 0.3)
        {
            triggerOn = false;
            this.gameObject.GetComponent<Animator>().SetBool("kick", false);
            this.gameObject.GetComponent<Animator>().SetBool("punch", false);
            myText = "";
           
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == otherPlayer.ToString())
        {
                
            Debug.Log("PLAYER : " + this.gameObject.tag + " DMG TAKEN : " + dmg);

            if (!collision.GetComponent<attackSystem>().blocked)
            {
                collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                collision.GetComponent<playerMove>().knockback(this.transform);

            }
            else if (collision.GetComponent<attackSystem>().blocked && (collision.transform.localScale.x + this.transform.localScale.x != 0) )
            {
                collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                collision.GetComponent<playerMove>().knockback(this.transform);
            }
            this.dmg = 0f;
            triggerOn = false;
        }

       
    }
    
}
