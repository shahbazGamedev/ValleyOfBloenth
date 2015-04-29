using UnityEngine;
using System.Collections;

public class Player : Creatures {

    public static bool grounded;//for jumping
    int lastLevel = 2;

    protected override void Awake()
    {
        startingHealth = 10;
        startingMove = 3;
        moveSpeed = 3;
        startingJump = 5;
        base.Awake();
    }

	void FixedUpdate () 
    {
	    //Movement (Left Right Jump)
        //Collied/Collect coins and power ups
        //Attack Enemies
        jump = false;
        if (GameManager.playing)
        {
            hMove = Input.GetAxis("Horizontal");
            if (hMove > 0 || hMove < 0 )
            {
                //Debug.Log("move");
                Move();
            }
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                jump = true;
                Move();
            }
            
        }
	}

    //collide with enemies
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "ground")
        {
            grounded = true;   
        }
        if (other.collider.tag == "exit")
        {
            if (Application.loadedLevel + 1 <= lastLevel)
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            else
            {
                Application.LoadLevel(0);
            }
        }
    }

    //collide with coins and power ups
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "jumpBoost":
                Destroy(other.gameObject);
                jumpHight += 3;
                moveSpeed = startingMove;
                GameManager.powerUp = "Jump Boost";
                break;
            case "speedBoost":
                GameManager.powerUp = "Speed Boost";
                moveSpeed += 3;
                jumpHight = startingJump;
                break;
            case "coin":
                Destroy(other.gameObject);
                GameManager.coins += 1;
                break;
            case "death":
                GameManager.playing = false;
                break;
            default:
                break;
        }
        
    }
}
