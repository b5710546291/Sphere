using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G001_Controller : MonoBehaviour
{
    int currentLane = 0;
    bool jumping = false;

    public Animator anim;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > -1)
        {

            //transform.Translate(Vector3.left);
            currentLane--;
            anim.SetInteger("Lane", currentLane);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 1)
        {
            //transform.Translate(Vector3.right);
            currentLane++;
            anim.SetInteger("Lane", currentLane);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumping)
        {
            jumping = true;
            anim.SetBool("Jump", jumping);
            //transform.Translate(Vector3.up, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) && jumping)
        {
            jumping = false;
            anim.SetBool("Jump", jumping);
            //transform.Translate(Vector3.down, Space.World);
        }
    }
}
