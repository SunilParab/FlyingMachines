using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Glider : MonoBehaviour
{

    float forceConstant = 0.1f;
    public float publicForceConstant = 1f;

    public float publicTorqueConstant = 1f;

    [Header("Components")]
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(gameObject + " " + -transform.rotation.eulerAngles.z);
        rb.AddForce(transform.up * ((180 - transform.rotation.eulerAngles.z) / 180) * -rb.linearVelocityY * forceConstant * publicForceConstant, ForceMode2D.Force);
        //rb.AddTorque(transform.rotation.eulerAngles.z * publicTorqueConstant, ForceMode2D.Force);
    }
}
