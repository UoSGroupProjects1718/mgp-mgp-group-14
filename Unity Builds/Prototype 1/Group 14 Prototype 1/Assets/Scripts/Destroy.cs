using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    GameObject pendulumfind; 
    void Start () {
        
        pendulumfind = GameObject.FindWithTag("Player");
        Movement_Attack_Dodge reference = pendulumfind.GetComponentInChildren<Movement_Attack_Dodge>();

        if (reference.isMoving == false)
        {
            Debug.Log("no");
            Destroy(pendulumfind, 1);
           
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
