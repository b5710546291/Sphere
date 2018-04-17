using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G001_PickUp : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward *360* Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindObjectOfType<G001_GameController>().GetPickUp();
            Destroy(this.gameObject);
        }

    }
}
