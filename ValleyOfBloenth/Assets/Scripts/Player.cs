using UnityEngine;
using System.Collections;

public class Player : Creatures {

    public static bool grounded;//for jumping

    protected override void Awake()
    {
        startingHealth = 10;
        moveSpeed = 2;
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
                Debug.Log("move");
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
    }

    //collide with coins and power ups
    void OnTriggerEnter(Collider other)
    {
    }
}
