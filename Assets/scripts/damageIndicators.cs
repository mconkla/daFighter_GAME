using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageIndicators : MonoBehaviour
{
    [HideInInspector]
    public float dmg;
    public float yPosOffset =1;
    public float spread = 1;
    public float speed =1;
    public float maxage=1;
    public Text text;
   

    private float start;
    // Start is called before the first frame update
    void Start()
    {
        text.transform.position += new Vector3(Random.value* spread,yPosOffset * 10,0) ;
        start = Time.time;
        text.text = dmg.ToString();
        Debug.Log("instantiate");
    }

    // Update is called once per frame
    void Update()
    {
        if (maxage < (Time.time - start))
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
       text.transform.position += new Vector3(0, speed * Time.deltaTime,0);
        //Debug.Log(this.gameObject.transform.position);
        Debug.Log("move");
    }
}
