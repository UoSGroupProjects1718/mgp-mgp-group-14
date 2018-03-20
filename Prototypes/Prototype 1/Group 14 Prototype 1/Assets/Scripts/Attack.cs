using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum Moves
{
	attack,
	dodge
}


public class Attack : MonoBehaviour {

	public int currentPlayer;

    public int player1_hp;
    public int player2_hp;

    public Button player1_Attackb;
    public Button player2_Attackb;

    public Button player1_Dodgeb;
    public Button player2_Dodgeb;

    public Button player1_Speed;
    public Button player2_Speed;

    public bool is1Clicked;
    public bool is2Clicked;
    public bool is1dClicked;
    public bool is2dClicked;
    public bool is1sClicked;
    public bool is2sClicked;

    public GameObject Ref_to_attack;
    public GameObject Ref_to_pendulum;

    public bool Attack1Success;
    public bool Attack2Success;
    public bool Dodge1Success;
    public bool Dodge2Success;

    public bool SpeedUpPendP1;
    public bool SpeedUpPendP2;

    Moves player1Move;
	Moves player2Move;

	// Use this for initialization
	void Start () 
	{
        player1_hp = 100; //Sets player 1 health to 100
        player2_hp = 100; //Sets player 2 health to 100
		currentPlayer = 1; //Sets the current player to 1
        player1_Attackb.onClick.AddListener(isAttackClicked);
        player2_Attackb.onClick.AddListener(isAttack2Clicked);
        player1_Dodgeb.onClick.AddListener(isDodgeClicked);
        player2_Dodgeb.onClick.AddListener(isDodge2Clicked);
        player1_Speed.onClick.AddListener(is1SpeedClicked);
        player2_Speed.onClick.AddListener(is2SpeedClicked);
        
        is1Clicked = false;
        is2Clicked = false;
        is1dClicked = false;
        is2dClicked = false;
        is1sClicked = false;
        is2sClicked = false;
        Attack1Success = false;
        Attack2Success = false;
        Dodge1Success = false;
        SpeedUpPendP1 = false;
        SpeedUpPendP2 = false;
     }

    public void HealUp()
    {
        if (currentPlayer == 1)
        {
            player1_hp += 15;
        }
        else if (currentPlayer == 2)
        {
            player2_hp += 15;
        } else if (currentPlayer == 3)
        {
            player1_hp += 15;
        } else if (currentPlayer == 4)
        {
            player2_hp += 15;
        }
    }
    public void is1SpeedClicked()
    {
        is1sClicked = true;
    }
    public void is2SpeedClicked()
    {
        is2sClicked = true;
    }
    public void SpeedUpPendulumP1()
    {
        if (currentPlayer != 5)
        {
            SpeedUpPendP1 = true;
        }
        else
        {
            SpeedUpPendP1 = false;
        }
        
    }

    public void isDodgeClicked()
    {
        is1dClicked = true;
    }
    public void isDodge2Clicked()
    {
        is2dClicked = true;
    }
    public void isAttackClicked()
    {
        is1Clicked = true;
    }
    public void isAttack2Clicked()
    {
        is2Clicked = true;
    }
	// Update is called once per frame
	void Update () 
	{
		if (player2_hp == 0 && player1_hp >= 1) //If the player 2 health is 0 and player 1 health is higher or equal to 1 then load player 1 win scene
		{
			SceneManager.LoadScene ("Player 1 Win");
		}

		if (player1_hp == 0 && player2_hp >= 1) //If the player 1 health is 0 and player 2 health is higher or equal to 1 then load player 2 win scene
		{
			SceneManager.LoadScene ("Player 2 Win");
		}

		if (player1_hp == 0 && player2_hp == 0) //If the player 1 health and player 2 health is 0 then load the draw screen
		{
			SceneManager.LoadScene ("Player Draw");
		}
        if (currentPlayer == 1 && Input.GetMouseButtonDown(0) && (is1Clicked == true || is1dClicked == true || is1sClicked == true))
        {
            currentPlayer = 2;
        }else if (currentPlayer == 2 && Input.GetMouseButtonDown(0) && (is2Clicked == true || is2dClicked == true || is2sClicked == true))
        {
            Player3Attack();
		}else if (currentPlayer == 5 && Input.GetMouseButtonDown(0) && (is1Clicked == true || is1dClicked == true || is1sClicked == true))
		{
			Calculate2();
		}
		 
		if (currentPlayer == 2 && Input.GetMouseButton(0))
		{
			player2_Attackb.interactable = true;
			player2_Dodgeb.interactable = true;
            player2_Speed.interactable = true;
        }
		else if (currentPlayer == 1 && Input.GetMouseButton(0))
		{
			player1_Attackb.interactable = true;
			player1_Dodgeb.interactable = true;
            player1_Speed.interactable = true;
        }
		else if (currentPlayer == 4 && Input.GetMouseButton(0))
		{
			player1_Attackb.interactable = false;
			player1_Dodgeb.interactable = false;
            player1_Speed.interactable = false;
            player2_Attackb.interactable = true;
			player2_Dodgeb.interactable = true;
            player2_Speed.interactable = true;
        }
		else if (currentPlayer == 5 && Input.GetMouseButton(0))
		{
			player1_Attackb.interactable = true;
			player1_Dodgeb.interactable = true;
            player1_Speed.interactable = true;
            player2_Attackb.interactable = false;
			player2_Dodgeb.interactable = false;
            player2_Speed.interactable = false;
        }

	}

	public void PlayerAttack()
	{
		if (currentPlayer == 1) //If the current player equals 1
		{
           // player2_Attackb.interactable = true;
            player1_Attackb.interactable = false;
           // player2_Dodgeb.interactable = true;
            player1_Dodgeb.interactable = false;
            player1_Speed.interactable = false;


            is1Clicked = false;
            is1dClicked = false;
            is2Clicked = false;
            is2dClicked = false;
            is1sClicked = false;
            is2sClicked = false;
        }


	}

	public void Player2Attack()
	{
		if (currentPlayer == 2 )
		{
            player2_Attackb.interactable = false;
            //player1_Attackb.interactable = true;
            player2_Dodgeb.interactable = false;
            //player1_Dodgeb.interactable = true;
            player2_Speed.interactable = false;

            is1Clicked = false;
            is1dClicked = false;
            is2Clicked = false;
            is2dClicked = false;
            is1sClicked = false;
            is2sClicked = false;
        }
	}

    public void Player3Attack()
    {
        currentPlayer = 3;
        if (currentPlayer == 3)
        {
            if (Attack1Success == true && Attack2Success == true)
            {
                //Debug.Log("Something!");
                player2_hp -= 10;
                

                player1_hp -= 10;
                
            }
            else if (Attack1Success == true && Dodge2Success == true)
            {
                //Debug.Log("Something2!");
            }
            else if (Dodge1Success == true && Attack2Success == true)
            {
                //Debug.Log("Something3!");
            }
            else if (Dodge1Success == true && Dodge2Success == true)
            {
                //Debug.Log("Something!4");
            }
            else if (Attack1Success == true && Dodge2Success == false)
            {
                //Debug.Log("Something!5");
                player2_hp -= 10;
                
            }
            else if (Dodge1Success == false && Attack2Success == true)
            {
               // Debug.Log("Something!6");
                player1_hp -= 10;
                
            }
            Attack1Success = false;
            Attack2Success = false;
            Dodge1Success = false;
            Dodge2Success = false;
            //SpeedUpPendP1 = false;
            //SpeedUpPendP2 = false;
            currentPlayer = 4;
        }
    }

	public void Player2Attack2()
	{
		if (currentPlayer == 4 )
		{
			player2_Attackb.interactable = false;
			//player1_Attackb.interactable = true;
			player2_Dodgeb.interactable = false;
            //player1_Dodgeb.interactable = true;
            player2_Speed.interactable = false;

            is1Clicked = false;
			is1dClicked = false;
			is2Clicked = false;
			is2dClicked = false;
            is1sClicked = false;
            is2sClicked = false;
            currentPlayer = 5;
		}

	}

	public void Player1Attack2()
	{
		if (currentPlayer == 5) //If the current player equals 5
		{
			// player2_Attackb.interactable = true;
			player1_Attackb.interactable = false;
			// player2_Dodgeb.interactable = true;
			player1_Dodgeb.interactable = false;
            player1_Speed.interactable = false;

            is1Clicked = false;
			is1dClicked = false;
			is2Clicked = false;
			is2dClicked = false;
            is1sClicked = false;
            is2sClicked = false;

        }


	}

	public void Calculate2()
	{
		currentPlayer = 6;

		if (currentPlayer == 6)
		{
			if (Attack1Success == true && Attack2Success == true)
			{
				//Debug.Log("Something!");
				player2_hp -= 10;


				player1_hp -= 10;

			}
			else if (Attack1Success == true && Dodge2Success == true)
			{
				//Debug.Log("Something2!");
			}
			else if (Dodge1Success == true && Attack2Success == true)
			{
				//Debug.Log("Something3!");
			}
			else if (Dodge1Success == true && Dodge2Success == true)
			{
				//Debug.Log("Something!4");
			}
			else if (Attack1Success == true && Dodge2Success == false)
			{
				//Debug.Log("Something!5");
				player2_hp -= 10;

			}
			else if (Dodge1Success == false && Attack2Success == true)
			{
				// Debug.Log("Something!6");
				player1_hp -= 10;

			}
			Attack1Success = false;
			Attack2Success = false;
			Dodge1Success = false;
			Dodge2Success = false;
			//SpeedUpPendP1 = false;
            //SpeedUpPendP2 = false;
            currentPlayer = 1;
		}
	}
	
}
	