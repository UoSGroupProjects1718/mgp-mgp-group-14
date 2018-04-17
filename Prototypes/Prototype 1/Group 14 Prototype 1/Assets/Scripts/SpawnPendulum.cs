using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPendulum : MonoBehaviour {
    public GameObject pendulum;
    public GameObject AttackRef;
    public bool check = false; //Just a check in the logic of the speedup
    public bool check2 = false; //Check variable for player2
    public bool ChangeSpeed = false;
    public bool ChangeSpeed2 = false; 

    
    public void Update()
    {
        Attack atkref = AttackRef.GetComponent<Attack>();
        if (check == true && (atkref.currentPlayer == 2 || atkref.currentPlayer == 4))
        {
            check = false;
            ChangeSpeed = true;
        }

        if (check2 == true && (atkref.currentPlayer == 1 || atkref.currentPlayer == 5))
        {
            check2 = false;
            ChangeSpeed2 = true;
        }
    }
    public void SpawnAttack()
    {
        Vector3 Position = new Vector3(0, 0.89f, -8.66f);
        pendulum = Instantiate(Resources.Load("Pendulum_Attack"), Position, Quaternion.identity) as GameObject;
        pendulum.name = "Pendulum1";
        Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
        if (ChangeSpeed)
        {
            reference.speed = 2.5f;
            ChangeSpeed = false;
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
        if (ChangeSpeed2)
        {
            reference.speed = 2.5f;
            ChangeSpeed2 = false;
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
    }

    public void SpawnDodge()
    {
        Vector3 Position = new Vector3(0, 0.89f, -8.66f);
        pendulum = Instantiate(Resources.Load("Pendulum_Dodge"), Position, Quaternion.identity) as GameObject;
        pendulum.name = "Pendulum1";
        Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
        if (ChangeSpeed)
        {
            reference.speed = 2.5f;
            ChangeSpeed = false;
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
        if (ChangeSpeed2)
        {
            reference.speed = 2.5f;
            ChangeSpeed2 = false;
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
    }

    public void SpawnHeal()
    {
        Vector3 Position = new Vector3(0, 0.89f, -8.66f);
        pendulum = Instantiate(Resources.Load("Pendulum_Heal"), Position, Quaternion.identity) as GameObject;
        pendulum.name = "Pendulum1";
        Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
        if (ChangeSpeed)
        {
            reference.speed = 2.5f;
            ChangeSpeed = false;
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
        if (ChangeSpeed2)
        {
            reference.speed = 2.5f;
            ChangeSpeed2 = false;
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
    }

    public void SpawnSpeed()
    {
        Vector3 Position = new Vector3(0, 0.89f, -8.66f);
        pendulum = Instantiate(Resources.Load("Pendulum_Speed"), Position, Quaternion.identity) as GameObject;
        pendulum.name = "Pendulum1";
        Movement_Attack_Dodge reference = pendulum.GetComponentInChildren<Movement_Attack_Dodge>();
        if (ChangeSpeed)
        {
            reference.speed = 2.5f;
            ChangeSpeed = false;
            
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
        if (ChangeSpeed2)
        {
            reference.speed = 2.5f;
            ChangeSpeed2 = false;
        }
        else
        {
            reference.speed = Random.Range(1.0f, 1.7f);
        }
    }

    public void Spawn()
    {
        Attack atkref = AttackRef.GetComponent<Attack>();
        
        if (atkref.currentPlayer == 1 || atkref.currentPlayer == 5)
        {
            check = true;
        }
        else if (atkref.currentPlayer == 2 || atkref.currentPlayer == 4)
        {
            check2 = true;
        }
    }
 }

