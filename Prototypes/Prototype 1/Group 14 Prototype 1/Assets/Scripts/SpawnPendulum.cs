using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPendulum : MonoBehaviour {
    public GameObject pendulum;
    public GameObject AttackRef;


    public void Spawn()
    {
        Vector3 Position = new Vector3(0, 0.89f, -8.66f);

        
        pendulum = Instantiate(Resources.Load("Pendulum"), Position, Quaternion.identity) as GameObject;
        pendulum.name = "Pendulum1";
        Attack atkref = AttackRef.GetComponent<Attack>();

        if (atkref.SpeedUpPend == true)
        {
            Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
            reference.speed = 2.5f;
        }
        else if (atkref.SpeedUpPend == false)
        {
            Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
            reference.speed = 1.5f;
        }

    }
  
 }

