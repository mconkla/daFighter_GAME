using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attackSystem : MonoBehaviour
{
    [HideInInspector]
    public string punchInput,kickInput,blockInput,heavyPunch,heavyKick = "";
    [HideInInspector]
    public int otherPlayer;
    [HideInInspector]
    public bool punch, kick,blocked = false;

    [HideInInspector]
    public float heavyPunchState = 0;

    public Health healthBar;

    [Range (0.1f,3f)]
    public float punchDMG = 1f;

    [HideInInspector]
    public string myText = "";

    float dmg = 0f;
    [Range(0.5f, 4.5f)]
    public float kickDMG = 2f;

    public CircleCollider2D hitBox;

    [HideInInspector]
    public bool triggerOn = false;

    float timeStamp;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<CircleCollider2D>();
        punchInput = "Fire1" + this.gameObject.tag.ToString();
        kickInput = "Fire2" + this.gameObject.tag.ToString();
        heavyKick = "Fire3" + this.gameObject.tag.ToString();
        heavyPunch = "Fire4" + this.gameObject.tag.ToString();
        blockInput = "Bumper" + this.gameObject.tag.ToString();
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


        if (Input.GetButtonDown(punchInput) && !blocked)
        {

            this.gameObject.GetComponent<Animator>().SetBool("kick", false);
            this.gameObject.GetComponent<Animator>().SetBool("punch", true);

            timeStamp = Time.time;
            triggerOn = true;
            dmg = punchDMG;
            myText = "PUNCH : " + dmg;



        }
        else if (Input.GetButtonDown(kickInput) && !blocked)
        {


            this.gameObject.GetComponent<Animator>().SetBool("punch", false);
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
        else if (Input.GetButtonUp(blockInput))//on release
        {
            blocked = false;
            myText = "";

            this.gameObject.GetComponent<Animator>().SetBool("block", false);
            Debug.Log("ICH BLOCKE NICHT MEHR");
        }


        else if (Input.GetButton(heavyPunch) && heavyPunchState >= 0 && !blocked)
        {
            heavyPunchState += (1f * Time.fixedDeltaTime);


            if (heavyPunchState > 1)
            {
                dmg = (punchDMG * 4);
                myText = "heavyPunch : " + dmg;
                heavyPunchState = -1;

                this.gameObject.GetComponent<Animator>().SetBool("kick", false);
                this.gameObject.GetComponent<Animator>().SetBool("punch", true);

                timeStamp = Time.time;
                triggerOn = true;
            }

        }
        else if (Input.GetButtonUp(heavyPunch) && !blocked)//on release
        {
            if (heavyPunchState != -1) {
            dmg = heavyPunchState * (punchDMG * 2);
            myText = "heavyPunch : " + dmg;

                this.gameObject.GetComponent<Animator>().SetBool("kick", false);
                this.gameObject.GetComponent<Animator>().SetBool("punch", true);

                timeStamp = Time.time;
                triggerOn = true;

            }

            heavyPunchState = 0;
            
            
        }

        else if (Input.GetButtonDown(heavyKick))
        {
           
            myText = "heavyKick ";
        }
        


    }

    private void setTriggerFalse()
    {
      
        if (triggerOn && Time.time - timeStamp > 0.3)
        {
            triggerOn = false;
            myText = "";
            this.gameObject.GetComponent<Animator>().SetBool("kick", false);
            this.gameObject.GetComponent<Animator>().SetBool("punch", false);

        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == otherPlayer.ToString())
        {
                
            if (!collision.GetComponent<attackSystem>().blocked)
            {
                collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                collision.GetComponent<playerMove>().knockback(this.transform);
              
                this.dmg = 0f;
               // triggerOn = false;

            }
            else 
            {
                if (Mathf.Sign(collision.transform.localScale.x) + Mathf.Sign(this.transform.localScale.x )!= 0)
                {
                    collision.GetComponent<attackSystem>().healthBar.onHit(dmg);
                    collision.GetComponent<playerMove>().knockback(this.transform);
                    this.dmg = 0f;
                  //  triggerOn = false;
                }
            }

            



        }


    }
    
}
