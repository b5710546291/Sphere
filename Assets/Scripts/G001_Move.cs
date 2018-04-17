using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G001_Move : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -G001_GameController.speed * Time.deltaTime, Space.World);
        if (transform.position.z < -10)
        {
            Destroy(this.gameObject);
        }

    }
}
