using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement_Attack_Dodge : MonoBehaviour
{
    public bool Pend = false;          //Keeps track to when the pendulum is moving right and left.

    public bool isMoving = true;       //Keeps track to when the pendulum is moving and when it stopped.

    public EdgeCollider2D ColliderRef;
    public BoxCollider2D SymbolRef;
    public bool Hit;
    public bool Dodge;
	public Text IsHit;
    public GameObject AttackRef;

	public Animator hitAnim;
	public Animator missAnim;

	[Range(1.0f, 5.0f)]
    public float speed = 1.5f;

    void Start()
    {
        Hit = false;
        Dodge = false;
        AttackRef = GameObject.Find("Attack/dodge");
        Attack something = AttackRef.GetComponent<Attack>();

        
        IsHit = GameObject.Find("IsHit").GetComponent<Text>();
        //EdgeCollider2D ColliderRef = GetComponentInChildren<EdgeCollider2D>();
        //BoxCollider2D SymbolRef = GetComponentInChildren<BoxCollider2D>();

    }

    void FixedUpdate()
    {
        StopPendulum();

        if (isMoving == true)           //Keeps the pendulum moving until you tap to stop it.
        {
            if (Pend == false)
            {

                if (transform.eulerAngles.z <= 49 || transform.eulerAngles.z > 315)
                {
                    transform.Rotate(0, 0, -1 * speed);                      //When the pendulum rotation is between those values it moves to the left.
                                                                     //Until it reaches -45 degrees.
                }
                else if (transform.eulerAngles.z >= 313 || transform.eulerAngles.z <= 316)
                {
                    Pend = true;

                }

            }
            else if (Pend == true)
            {
                if (transform.eulerAngles.z < 45 || transform.eulerAngles.z >= 312)
                {                                                                   //Here is moving to the right until it reaches 46 degrees.
                    transform.Rotate(0, 0, 1 * speed);                                      //Then will start moving to the left again.

                }
                else if (transform.eulerAngles.z >= 44 || transform.eulerAngles.z <= 49) 
                {
                    Pend = false;

                }

            }
        }
        else if (isMoving == false)
        {
            speed = 0f;
            Destroy(GameObject.FindWithTag("WORK"), 1);
        }
    }
    

    public void StopPendulum()

    //When you click you trigger the bool that keeps tracking the movement, and then it calculates the angle of the pendulum
    // to know if it's an attack dodge or miss.
    //We can add more attacks and dodges at different angles or even change the shape and the movement angles of the pendulum.
    {
        if (Input.GetKeyDown("mouse 0") && isMoving)
        {
            isMoving = false;
            AttackRef = GameObject.Find("Attack/dodge");
            Attack something = AttackRef.GetComponent<Attack>();
            
			if (ColliderRef.IsTouching(SymbolRef)) {
                Debug.Log("InPendulum");
				if (something.is1Clicked == true) {
					something.Attack1Success = true;
					//Debug.Log("HIT");
					IsHit.text = "Attack Success";

					//hitAnim.SetTrigger("Hit");
					//animation.Play("Hit");
				}
                if (something.is2Clicked == true) {
					something.Attack2Success = true;
					//Debug.Log("HIT2");
					hitAnim.SetTrigger("Hit");
					IsHit.text = "Attack Success";
                }
                 if (something.is1dClicked)
                {
                    something.Dodge1Success = true;
                    IsHit.text = "Dodge Success";
                }
                 if (something.is2dClicked)
                {
                    something.Dodge2Success = true;
                    IsHit.text = "Dodge Success";
                }
                 if (something.is1hClicked)
                {
                    something.Heal1Success = true;
                    IsHit.text = "Heal Success";
                }
                 if (something.is2hClicked)
                {
                    something.Heal2Success = true;
                    IsHit.text = "Heal Success";
                }
                 if (something.is1sClicked)
                {
                    something.Speed1Success = true;
                    IsHit.text = "Speed Success";
                }
                else if (something.is2sClicked)
                {
                    something.Speed2Success = true;
                    IsHit.text = "Speed Success";
                }

            }  else if (transform.eulerAngles.z > 15 && transform.eulerAngles.z < 345)

            {
				IsHit.text = "Miss";
				missAnim.SetTrigger("Miss");
			}

            something.CompletePendulum();
        }
    }
}