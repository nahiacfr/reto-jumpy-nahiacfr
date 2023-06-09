using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody riggidBody;
    private bool canJump;
    private bool moveForward;
    [SerializeField]
    public int jumpForce = 200;
    [SerializeField]
    float moveSpeed = 10f;
    public Transform foxTransform;


    // Start is called before the first frame update
    void Start()
    {
        riggidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move1();
        Jump();
    }

    private void Jump()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            riggidBody.AddForce(Vector3.up * jumpForce);
            canJump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }

    }

    private void Move1()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        Vector3 newPosition = foxTransform.position + movement * moveSpeed * Time.deltaTime;
        riggidBody.MovePosition(newPosition);
    }

}
