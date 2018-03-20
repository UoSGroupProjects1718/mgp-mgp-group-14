using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPendulum : MonoBehaviour {
    public GameObject pendulum;
    public GameObject AttackRef;
    public bool check = false; //Just a check in the logic of the speedup


    public void Spawn()
    {
        Vector3 Position = new Vector3(0, 0.89f, -8.66f);

        
        pendulum = Instantiate(Resources.Load("Pendulum"), Position, Quaternion.identity) as GameObject;
        pendulum.name = "Pendulum1";
        Attack atkref = AttackRef.GetComponent<Attack>();

        if (atkref.SpeedUpPendP1 == true && atkref.currentPlayer == 1)
        {
            if (check == true)
            {
                Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
                reference.speed = 1.5f;
                check = false;
            }
            else if (check == false)
            {
                Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
                reference.speed = 2.5f;
                atkref.SpeedUpPendP1 = false;
            }
        }
        else if (atkref.SpeedUpPendP1 == true && atkref.currentPlayer == 2)
        {
            Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
            reference.speed = 2.5f;
            atkref.SpeedUpPendP1 = false;
        }
        else if (atkref.SpeedUpPendP1 == false && (atkref.currentPlayer == 1 || atkref.currentPlayer == 2))
        {
            Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
            reference.speed = 1.5f;
        }
        else if (atkref.SpeedUpPendP1 == true && atkref.currentPlayer == 4)
        {
            Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
            reference.speed = 1.5f;
        }
        else if (atkref.SpeedUpPendP1 == true && atkref.currentPlayer == 5)
        {
            Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
            reference.speed = 2.5f;
            atkref.SpeedUpPendP1 = false;
            if (atkref.is1sClicked == true)
            {
                check = true;
            }
        }
    }
 }

