using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {
    public float distance = 10.0f;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(0f, 0f, distance);
	}
	    
	// Update is called once per frame
	void Update () {
		
	}
}
