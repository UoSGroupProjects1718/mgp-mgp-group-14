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

    public int Player1Combo = 0;
    public int Player2Combo = 0;

    public GameObject ButtonControl;
    public GameObject P2ButtonControl;

	public Text player_turn;

    public GameObject Player1Ref;

    public Button player1_Attackb;
    public Button player2_Attackb;

    public Button player1_Dodgeb;
    public Button player2_Dodgeb;

    public Button player1_Speed;
    public Button player2_Speed;

    public Button player1_Heal;
    public Button player2_Heal;

    public bool is1Clicked;
    public bool is2Clicked;
    public bool is1dClicked;
    public bool is2dClicked;
    public bool is1sClicked;
    public bool is2sClicked;
    public bool is1hClicked;
    public bool is2hClicked;

    public GameObject Ref_to_spawn;
    public GameObject Ref_to_pendulum;

    public bool Attack1Success;
    public bool Attack2Success;
    public bool Dodge1Success;
    public bool Dodge2Success;

    public bool Heal1Success;
    public bool Heal2Success;
    public bool Speed1Success;
    public bool Speed2Success;

    public bool SpeedUpPendP1;
    public bool SpeedUpPendP2;

    public bool HealP1;
    public bool HealP2;

    Moves player1Move;
	Moves player2Move;

	// Use this for initialization
	void Start () 
	{
		
        player1_hp = 100; //Sets player 1 health to 100
        player2_hp = 100; //Sets player 2 health to 100
		currentPlayer = 1; //Sets the current player to 1
        //player1_Attackb.onClick.AddListener(isAttackClicked);
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
        is1hClicked = false;
        is2hClicked = false;
        Attack1Success = false;
        Attack2Success = false;
        Dodge1Success = false;
        SpeedUpPendP1 = false;
        SpeedUpPendP2 = false;
        HealP1 = false;
        HealP2 = false;
        Heal1Success = false;
        Heal2Success = false;
        Speed1Success = false;
        Speed2Success = false;
		player_turn.text = "Player 1 Turn";
     }

    //public void HealUp()
    //{
    //    if (currentPlayer == 1)
    //    {
    //        player1_hp += 15;
    //    }
    //    else if (currentPlayer == 2)
    //    {
    //        player2_hp += 15;
    //    } else if (currentPlayer == 3)
    //    {
    //        player1_hp += 15;
    //    } else if (currentPlayer == 4)
    //    {
    //        player2_hp += 15;
    //    }
    //}
    public void isHealClicked()
    {
        is1hClicked = true;
        DisableAllButtons();
    }
    public void isHeal2Clicked()
    {
        is2hClicked = true;
        DisableAllButtons();
    }
    public void is1SpeedClicked()
    {
        is1sClicked = true;
        DisableAllButtons();
    }
    public void is2SpeedClicked()
    {
        is2sClicked = true;
        DisableAllButtons();
    }

    //public void SpeedUpPendulumP1()
    //{
    //    if (currentPlayer != 5)
    //    {
    //        SpeedUpPendP1 = true;
    //    }
    //    else
    //    {
    //        SpeedUpPendP1 = false;
    //        Speed1Success = false;
    //    }
        
    //}

    public void isDodgeClicked()
    {
        is1dClicked = true;
        DisableAllButtons();
    }
    public void isDodge2Clicked()
    {
        is2dClicked = true;
        DisableAllButtons();
    }
    public void isAttackClicked()
    {
        is1Clicked = true;
        DisableAllButtons();
    }
    public void isAttack2Clicked()
    {
        is2Clicked = true;
        DisableAllButtons();
    }

    private void DisableAllButtons()
    {
        ButtonControl.SetActive(false);
        P2ButtonControl.SetActive(false);
    }

    private void SetupPlayerButtons()
    {
        //Debug.Log("SetupPlayerButtons: " + currentPlayer.ToString());
        if (currentPlayer == 2 || currentPlayer == 4)
        {
			player_turn.text = "Player 2 Turn";
            ButtonControl.SetActive(false);
            P2ButtonControl.SetActive(true);
        }
        else if (currentPlayer == 1 || currentPlayer == 5)
        {
			player_turn.text = "Player 1 Turn";
            ButtonControl.SetActive(true);
            P2ButtonControl.SetActive(false);
        }
    }

    public void CompletePendulum()
    {
        // Debug.Log("In Complete Pendulum");


        if (Speed1Success == true)
        {
            SpawnPendulum SpawnScriptRef = Ref_to_spawn.GetComponent<SpawnPendulum>();
            Speed1Success = false;
            SpawnScriptRef.Spawn();
        }
        else if (Speed2Success == true)
        {
            SpawnPendulum SpawnScriptRef = Ref_to_spawn.GetComponent<SpawnPendulum>();
            Speed2Success = false;
            SpawnScriptRef.Spawn();
        }
        PlayerAttack();
        currentPlayer++;

        if (currentPlayer == 3)
        {
            Player3Attack();

        }
        else if (currentPlayer == 6)
        {
            Calculate2();
        }

        SetupPlayerButtons();
    }

	// Update is called once per frame
	void Update () 
	{
		if (player2_hp <= 0 && player1_hp >= 1) //If the player 2 health is 0 and player 1 health is higher or equal to 1 then load player 1 win scene
		{
			SceneManager.LoadScene ("Player 1 Win");
		}

		if (player1_hp <= 0 && player2_hp >= 1) //If the player 1 health is 0 and player 2 health is higher or equal to 1 then load player 2 win scene
		{
			SceneManager.LoadScene ("Player 2 Win");
		}

		if (player1_hp <= 0 && player2_hp <= 0) //If the player 1 health and player 2 health is 0 then load the draw screen
		{
			SceneManager.LoadScene ("Player Draw");
		}
	}

	public void PlayerAttack()
	{
		if (currentPlayer == 1 || currentPlayer == 5) //If the current player equals 1
		{
            is1Clicked = false;
            is1dClicked = false;
            is2Clicked = false;
            is2dClicked = false;
            is1sClicked = false;
            is2sClicked = false;
            is1hClicked = false;
            is2hClicked = false;
        }

        if (currentPlayer == 2 || currentPlayer == 4)
        {
            is1Clicked = false;
            is1dClicked = false;
            is2Clicked = false;
            is2dClicked = false;
            is1sClicked = false;
            is2sClicked = false;
            is1hClicked = false;
            is2hClicked = false;
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
                player2_hp -= 20;

                player1_hp -= 20;
                
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

            if (Heal1Success == true)
            {
                player1_hp += 15;
            }

            if (Heal2Success == true)
            {
                player2_hp += 15;
            }

            if (Attack1Success)
            {

                UpdateAnimation ScriptRef = Player1Ref.GetComponent<UpdateAnimation>();
                StartCoroutine(ScriptRef.AnimatorControl());
                Player1Combo += 1;
            }
            else if (Attack1Success == false)
            {
                Player1Combo = 0;
            }

            if (Attack2Success)
            {
                Player2Combo += 1;
            }
            else if (Attack2Success == false)
            {
                Player2Combo = 0;
            }

            if (Player1Combo >= 3)
            {
                player2_hp -= 10;
                Player1Combo = 0;
            }

            if (Player2Combo >= 3)
            {
                player1_hp -= 10;
                Player2Combo = 0;
            }
            Attack1Success = false;
            Attack2Success = false;
            Dodge1Success = false;
            Dodge2Success = false;
            Heal1Success = false;
            Heal2Success = false;
        
            //SpeedUpPendP1 = false;
            //SpeedUpPendP2 = false;
            currentPlayer = 4;
        }
    }

	public void Calculate2()
	{
		currentPlayer = 6;

       // Debug.Log("In Calculate 2");

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

            if (is1hClicked == true)
            {
                player1_hp += 15;
            }

            if (is2hClicked == true)
            {
                player2_hp += 15;
            }
            if (Attack1Success)
            {

                UpdateAnimation ScriptRef = Player1Ref.GetComponent<UpdateAnimation>();
                StartCoroutine(ScriptRef.AnimatorControl());
                Player1Combo += 1;
            }
            else if (Attack1Success == false)
            {
                Player1Combo = 0;
            }

            if (Attack2Success)
            {
                Player2Combo += 1;
            }
            else if (Attack2Success == false)
            {
                Player2Combo = 0;
            }

            if (Player1Combo >= 3)
            {
                player2_hp -= 10;
                Player1Combo = 0;
            }

            if (Player2Combo >= 3)
            {
                player1_hp -= 10;
                Player2Combo = 0;
            }
            Attack1Success = false;
			Attack2Success = false;
			Dodge1Success = false;
			Dodge2Success = false;
            Heal1Success = false;
            Heal2Success = false;;
            //SpeedUpPendP1 = false;
            //SpeedUpPendP2 = false;
            currentPlayer = 1;
            //Debug.Log("Set currentPlayer to 1");
        }
	}
	
}
	