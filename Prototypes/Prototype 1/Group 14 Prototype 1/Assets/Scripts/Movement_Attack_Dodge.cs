using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement_Attack_Dodge : MonoBehaviour
{
    public bool Pend = false;          //Keeps track to when the pendulum is moving right and left.

    public bool isMoving = true;       //Keeps track to when the pendulum is moving and when it stopped.

    public bool Hit;
    public bool Dodge;
	public Text IsHit;
    public GameObject AttackRef;
    [Range(1.0f, 5.0f)]

    public float speed = 1.5f;

    void Start()
    {
        Hit = false;
        Dodge = false;

		IsHit = GameObject.Find("IsHit").GetComponent<Text>();

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
            AttackRef = GameObject.Find("Attack/dodge");
            Attack something = AttackRef.GetComponent<Attack>();
            isMoving = false;
			if (transform.eulerAngles.z <= 25 && transform.eulerAngles.z >= 11) {
				if (something.is1Clicked == true) {
					something.Attack1Success = true;
					something.Dodge1Success = false;
					//Debug.Log("HIT");
					IsHit.text = "Attack Success";
				}

				if (something.is2Clicked == true) {
					something.Attack2Success = true;
					something.Dodge2Success = false;
					//Debug.Log("HIT2");
					IsHit.text = "Attack Success";
				}

			} else if (transform.eulerAngles.z <= 355 && transform.eulerAngles.z >= 344) {

				if (something.is1dClicked == true) {
					something.Attack1Success = false;
					something.Dodge1Success = true;
					//Debug.Log("HIT3");
					IsHit.text = "Dodge Success";
				}
				if (something.is2dClicked == true) {
					something.Attack2Success = false;
					something.Dodge2Success = true;
					// Debug.Log("HIT4");
					IsHit.text = "Dodge Success";
				}
			} else 
			{
				IsHit.text = "Miss";
			}

            something.CompletePendulum();
        }
    }
}