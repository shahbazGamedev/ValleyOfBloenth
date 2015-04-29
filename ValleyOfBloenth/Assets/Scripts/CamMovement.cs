using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {
    //not mine
    GameObject target;

    public float offsetX = 7.5f;
    public float offsetZ = -15f;
    public float offsetY = 0;

    public float maximumDistance = 2f;
    public float playerVelocity = 10f;

    public float movementX;
    public float movementY;
    public float movementZ;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Vector3 vec = new Vector3();
        vec.x = 0;
        this.transform.Rotate(vec);
    }


    void Update()
    {
        if (target != null)
        {
            movementX = (target.transform.position.x + offsetX - this.transform.position.x) / maximumDistance;
            movementY = (target.transform.position.y + offsetY - this.transform.position.y) / maximumDistance;
            movementZ = (target.transform.position.z + offsetZ - this.transform.position.z) / maximumDistance;

            this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), (movementY * playerVelocity * Time.deltaTime), (movementZ * playerVelocity * Time.deltaTime));
        }
        else
        {
            this.enabled = false;
        }

    }
}
