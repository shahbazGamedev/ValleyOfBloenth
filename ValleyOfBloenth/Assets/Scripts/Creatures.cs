using UnityEngine;
using System.Collections;

public class Creatures : MonoBehaviour {

    public int startingHealth;

    //basic fields for player and enemies
    protected float currentHealth;
    protected int damage;
    protected float moveSpeed;
    protected float jumpHight = 5;
    protected Rigidbody _rigidbody;
    protected int startingMove = 5;

    //movement
    protected float hMove;//move on the horizontal axis;
    protected bool jump;//jump
    Vector3 moveTo;//for moveing player and enemies
    protected int startingJump;
    
    protected virtual void Awake()
    {
        //setting up rigidbody
        _rigidbody = GetComponent<Rigidbody>();        
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        //setting up health etc.
        currentHealth = startingHealth;
    }

    //for moving player and enemies
    protected void Move()
    {
        //move for player and enemies
        moveTo = new Vector3(hMove, 0);
        _rigidbody.MovePosition(transform.position + moveTo * moveSpeed * Time.deltaTime);
        //jump can only be done by the player
        if (jump && gameObject.tag == "Player")
        {
            //Debug.Log("Jump");
            moveTo = new Vector3(0, jumpHight, 0);
            _rigidbody.velocity = new Vector3(0, 0,0);
            _rigidbody.AddForce(moveTo, ForceMode.Impulse);
            Player.grounded = false;
        }
    }

    //Taking Damage - Enemy will call this on the player and visa versa
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    //Death called when health is zero
    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    //Deals with Health, attacking and damage
}
