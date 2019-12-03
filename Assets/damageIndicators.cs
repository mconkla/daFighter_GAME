using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageIndicators : MonoBehaviour
{
    public float dmg;
    public float yPosOffset;
    public float speed;
    public float maxage;

    private float start;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent.gameObject.transform.position += new Vector3(0,yPosOffset ,0) ;
        start = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxage > (Time.time - start))
        {
            Destroy(gameObject);
        }
        this.transform.parent.gameObject.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
