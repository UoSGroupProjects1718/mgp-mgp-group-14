using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnimation : MonoBehaviour {

    public Animator P1AttackAnim;
    public WaitForSeconds count = new WaitForSeconds(1); //This is a delay
    public bool AttackAnimation = false;

    // Use this for initialization
    void Start () {
        P1AttackAnim = GetComponent<Animator>();
        
    }
	
    public IEnumerator AnimatorControl()
    {
        AttackAnimation = true;
        P1AttackAnim.enabled = true;
        P1AttackAnim.SetBool("AnimControl", true);
        yield return count;
        AttackAnimation = false;
        P1AttackAnim.SetBool("AnimControl", false);
        Debug.Log("Animator enabled!");
    }
}
