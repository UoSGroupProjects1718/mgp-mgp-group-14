﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Moves
{
	attack,
	dodge
}


public class Attack : MonoBehaviour {

	public int currentPlayer;

	//public GameManager gameManager;
	//public bool player1;
	//public bool player2;
    public int player1_hp;
    public int player2_hp;
    public bool Dodge1;
    public bool Dodge2;
    public bool p1Attack;
    public bool p2Attack;


	Moves player1Move;
	Moves player2Move;


	bool Pend;          //Keeps track to when the pendulum is moving right and left.
	bool isMoving;       //Keeps track to when the pendulum is moving and when it stopped.


	// Use this for initialization
	void Start () {
		
        player1_hp = 3; //Sets player 1 health to 3
        player2_hp = 3; //Sets player 2 health to 3
        Dodge1 = false; //Sets player 1 dodge to false
        Dodge2 = false; //Sets player 2 dodge to false
        p1Attack = false; //Sets player 1 attack to false
        p2Attack = false; //Sets player 2 attack to false
		Pend = false; //Sets the pend to false
		isMoving = false; //Sets the isMoving to fasle for the pendulum
		currentPlayer = 1; //Sets the current player to 1
	}
	
	// Update is called once per frame
	void Update () {
		if (player2_hp == 0 && player1_hp >= 1) //If the player 2 health is 0 and player 1 health is higher or equal to 1 then load player 1 win scene
		{
			//Debug.Log ("Player health is at 0 and we should be loading a new scene");
			SceneManager.LoadScene ("Player 1 Win");
		}

		if (player1_hp == 0 && player2_hp >= 1) //If the player 1 health is 0 and player 2 health is higher or equal to 1 then load player 2 win scene
		{
			//Debug.Log ("Player health is at 0 and we should be loading a new scene");
			SceneManager.LoadScene ("Player 2 Win");
		}

		if (player1_hp == 0 && player2_hp == 0) //If the player 1 health and player 2 health is 0 then load the draw screen
		{
			//Debug.Log ("Player health is at 0 and we should be loading a new scene");
			SceneManager.LoadScene ("Player Draw");
		}
	}
		
	void FixedUpdate()
	{
		StopPendulum();

		if (isMoving == true)           //Keeps the pendulum moving until you tap to stop it.
		{
			if (Pend == false)
			{

				if (transform.eulerAngles.z <= 46 || transform.eulerAngles.z > 315)
				{
					transform.Rotate(0, 0, -1);                      //When the pendulum rotation is between those values it moves to the left.
					//Until it reaches -45 degrees.
				}
				else if (transform.eulerAngles.z == 315)
				{
					Pend = true;

				}

			}
			else if (Pend == true)
			{
				if (transform.eulerAngles.z < 45 || transform.eulerAngles.z >= 315)
				{                                                                   //Here is moving to the right until it reaches 46 degrees.
					transform.Rotate(0, 0, 1);                                      //Then will start moving to the left again.

				}
				else if (transform.eulerAngles.z == 46)
				{
					Pend = false;

				}

			}
		}
	}

	public void StopPendulum()

	//When you click you trigger the bool that keeps tracking the movement, and then it calculates the angle of the pendulum
	// to know if it's an attack dodge or miss.
	//We can add more attacks and dodges at different angles or even change the shape and the movement angles of the pendulum.
	{
		if (Input.GetKeyDown("mouse 0"))
		{
			isMoving = false;
			if (transform.eulerAngles.z <= 40 && transform.eulerAngles.z >= 22)
			{
				print("HIT");
				this.GetComponent<Attack>().Fight();
			}
			else if (transform.eulerAngles.z <= 351 && transform.eulerAngles.z >= 330)
			{
				print("Dodge");
				this.GetComponent<Attack>().Dodge();
				this.GetComponent<Attack>().Fight();
			}
			else
			{
				print("Miss");
			}
		}
	}

	public void PlayerAttack()
	{
		if (currentPlayer == 1) //If the current player equals 1
		{
			player1Move = Moves.attack;
            player2_hp -= 1; //Minus 1 from the player 2 health
            p1Attack = true;
			GameObject g = GameObject.Find("Player 2 health"); //Look for the game object named "Player 2 health"
			Player_2_health bScript =  g.GetComponent<Player_2_health>();
			bScript.updateHealthPlayer2(player2_hp); //Update the player 2 health script
			//Debug.Log("Player 1 attack");
			currentPlayer = 2; //Sets the current player to 2
			//Debug.Log("Player 2 turn");

		}

	

		//gameManager.NextTurn ();
	}

	public void Player2Attack()
	{
		if (currentPlayer == 2)
		{
			player2Move = Moves.attack;
			p2Attack = false;
			player1_hp -= 1; //Minus 1 from player 1 health
			GameObject g = GameObject.Find("Player 1 health"); //Look for the game object named "Player 1 health"
			Player_1_health bScript2 =  g.GetComponent<Player_1_health>();
			bScript2.updateHealthPlayer1(player1_hp); //Update the player 1 health script
			//Debug.Log("Player 2 attack");
			currentPlayer = 1; //Sets the current player to 1
			//Debug.Log("Player 1 turn");
		}
	}

	public void Dodge()
	{
		if (currentPlayer == 1)
		{
			Debug.Log("Player 1 dodge");
            Dodge1 = true;
			currentPlayer = 2; //Sets the current player to 2
		}
			

		//gameManager.NextTurn ();
	}
	public void Dodgep2 ()
	{
		if (currentPlayer == 2)
		{
			Debug.Log("Player 2 dodge");
			Dodge2 = true;
			currentPlayer = 1; //Sets the current player to 1
		}
	}

	public void Fight()
	{
        if (Dodge1 == true && p2Attack == true)
        {
            print("Dodge succesful!");
        }  else if (Dodge2 == true && p1Attack == true)
        {
            print("Dodge succesful!");
        }
        else
        {
            PlayerAttack();
        }
		
	}
}
	