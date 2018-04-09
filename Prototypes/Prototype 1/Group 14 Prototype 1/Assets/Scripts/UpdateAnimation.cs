using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnimation : MonoBehaviour {

    public Animator P1AttackAnim;

    // Use this for initialization
    void Start () {
        P1AttackAnim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
public void UpdateAnimationP1 ()
    {

        P1AttackAnim.enabled = true;
        Debug.Log("Animator enabled!");
    }
}
