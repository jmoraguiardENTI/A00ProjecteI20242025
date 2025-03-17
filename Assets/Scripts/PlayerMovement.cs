using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;

    public float horizontalSpeed;
    public float jumpForce;

    public bool isGrounded;
    public Vector2 raycastOrigin;
    public float raycastOriginOffset;
    public float raycastDistance;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;

        raycastOrigin = transform.position - new Vector3(0f, raycastOriginOffset);

        raycastOriginOffset = 1.01f;
        raycastDistance = 0.5f;

        if (rb2D == null)
        {
            Debug.Log("Rigibody2D is not initlialized");
            rb2D = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATE");

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2D.velocity = new Vector2((0 - horizontalSpeed), 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2D.velocity = new Vector2(horizontalSpeed, 0);
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            rb2D.AddForce(new Vector2(0, jumpForce));
        }

        raycastOrigin = transform.position - new Vector3(0f, raycastOriginOffset);

        isGrounded = false;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance);
        if (raycastHit2D.collider != null && raycastHit2D.collider.gameObject.name == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(raycastOrigin, raycastOrigin + Vector2.down * raycastDistance);
    }
}
