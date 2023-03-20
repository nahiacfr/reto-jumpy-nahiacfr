using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody riggidBody;
    private bool canJump;
    private bool moveForward;
    [SerializeField]
    public int jumpForce = 200;
    [SerializeField]
    float moveSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        riggidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            riggidBody.AddForce(Vector3.back);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            canJump = true;
        }

    }
    void OnTriggerExit(Collider other)
    {

        //other.gameObject.
    }
    void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void Move()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

}
