using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AirBalloon : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rb;

    public float upForce;
    float forceConstant = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.bodyType != RigidbodyType2D.Kinematic) {

            rb.AddForce(Vector2.up * forceConstant * upForce, ForceMode2D.Force);

        }
    }
}
