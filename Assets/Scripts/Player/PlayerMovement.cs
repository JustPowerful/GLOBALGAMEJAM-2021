using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float x;
    private float y;
    public float moveSpeed;
    public float jumpForce;

    public Rigidbody player;

    // Ground logic variables
    public LayerMask layer;
    public Transform foot;
    public float detectRad;
    public bool isGrounded;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if the player is grounded
        isGrounded = Physics.CheckSphere(foot.position, detectRad, layer);

        x = Input.GetAxis("Horizontal") * moveSpeed;
        y = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 movePos = transform.right * x + transform.forward * y;
        Vector3 newPos = new Vector3(movePos.x, player.velocity.y, movePos.z);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(0, jumpForce, 0);
        }

        // Changing the rigidbody's velocity to the new position
        player.velocity = newPos;

    }
}
