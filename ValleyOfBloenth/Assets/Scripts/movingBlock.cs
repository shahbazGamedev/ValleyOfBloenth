using UnityEngine;
using System.Collections;

public class movingBlock : MonoBehaviour {
    Vector3 startingPos;
    Vector3 nextPos;
    Vector3 stopped = new Vector3(0, 0, 0);
    Rigidbody _rigidbody;
    int moveSpeed = 100;
    bool down;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        startingPos = transform.position;
        //Debug.Log("start: " + startingPos);
        nextPos = new Vector3(startingPos.x, 4.9f, startingPos.z);
        //Debug.Log("next: " + nextPos);
    }

    void FixedUpdate()
    {
        if (transform.position.y >= startingPos.y)
        {
            //Debug.Log("Down");
            down = true;
        }
        else if (transform.position.y <= nextPos.y)
        {
            //Debug.Log("Up");
            down = false;
        }
        if (down)
        {
            _rigidbody.velocity = stopped;
            _rigidbody.AddForce(-transform.up * moveSpeed, ForceMode.Force);
        }
        else
        {
            _rigidbody.velocity = stopped;
            _rigidbody.AddForce(transform.up * moveSpeed, ForceMode.Force);
        }
    }
}
