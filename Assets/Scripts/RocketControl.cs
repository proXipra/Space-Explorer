using UnityEngine;

public class RocketControl : MonoBehaviour
{
    Rigidbody2D rb;
    public static bool allowRocketToMove;
    public static float rotationX, rotationY;
    public static float speed = 5f;
    public static float actX, actY;
    public static float canvasX;
    public GameObject explosion;
    public static float distanceCovered;
    public GameObject rocket;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        allowRocketToMove = false;
        explosion.active = false;
        distanceCovered = 0;
    }

    // Update is called once per frame
    void Update()
    {
        canvasX = GameObject.Find("Canvas").transform.position.x;
        if (allowRocketToMove == true)
        {
            
            rotationX = Input.GetAxis("Horizontal");
            rotationY = Input.GetAxis("Vertical");
            transform.Rotate(0, 0, rotationX * (-2f));

            if(rocket.transform.position.x > distanceCovered)
            {
                distanceCovered = rocket.transform.position.x/15;
            }

            actX = transform.position.x;
            actY = transform.position.y;
        }
    }

    private void FixedUpdate()
    {
        if (allowRocketToMove == true)
        {
            rb.velocity = transform.up * speed;
        }
    }
}
