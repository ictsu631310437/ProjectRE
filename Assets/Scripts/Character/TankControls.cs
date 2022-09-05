using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    public GameObject thePlayer;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;

    public bool isRunning;
    public bool backwardsCheck = false;

    void Update()
    {
            if (WeaponMechanic.isAiming == false)
            {

               
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                }

                if (Input.GetButton("Horizontal")  || Input.GetButton("Vertical"))
                {
                    isMoving = true;
                    if (Input.GetButton("Skey"))
                    {
                        backwardsCheck = true;
                        thePlayer.GetComponent<Animator>().Play("WalkBack");
                    }
                    else
                    {
                        backwardsCheck = false;
                        if (isRunning == false)
                        {
                            thePlayer.GetComponent<Animator>().Play("Walk");
                        }
                        else
                        {
                            thePlayer.GetComponent<Animator>().Play("Run");
                        }
                    }

                    //thePlayer.GetComponent<Animator>().Play("Walk");

                    if (isRunning == false || backwardsCheck == true)
                    {
                        verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 4;
                    }
                    if (isRunning == true && backwardsCheck == false)
                    {
                        verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 12;
                    }

                    horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                    thePlayer.transform.Rotate(0,horizontalMove,0);
                    thePlayer.transform.Translate(0,0,verticalMove);
                }
                else
                {
                    isMoving = false;
                    thePlayer.GetComponent<Animator>().Play("Idle");
                }

            }
    }
}
