using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_1_health : MonoBehaviour {
    
    public GameObject Attackref;
	
    void Update ()
    {
        Attack attackScript = Attackref.GetComponent<Attack>();
        Text Health_Display = GetComponent<Text>();
        Health_Display.text = attackScript.player1_hp.ToString();
    }
}
