using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public GameObject otherPlayer;
    private bool grounded;
    public float groundDistance = 0.2f;
    private Vector3 down = new Vector3(0.0f, -1.0f, 0.0f);
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool RaycastLeft = Physics2D.Raycast(transform.position, down, groundDistance) != null;
        bool RaycastRight = Physics2D.Raycast(transform.position, down, groundDistance) != null;
        Vector3 pos;
        Vector3 distance;
        pos = otherPlayer.transform.position;
        distance = pos - this.transform.position ;
        //Debug.Log(distance);
        Debug.Log(RaycastLeft);
        

    }
}
