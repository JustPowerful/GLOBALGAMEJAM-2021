using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoDmovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 movePos = transform.right * x + transform.up * y;
        Vector2 newPos = new Vector2(movePos.x, movePos.y) * moveSpeed;

        rb.velocity = newPos;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "redcube")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
