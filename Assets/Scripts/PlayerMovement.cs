using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;

    public float horizontalSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        if (rb2D == null)
        {
            Debug.Log("Rigibody2D is not initlialized");
            rb2D = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2D.velocity = new Vector2((0 - horizontalSpeed), 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2D.velocity = new Vector2(horizontalSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("JUMP");
            rb2D.AddForce(new Vector2(0, jumpForce));
        }
    }
}
