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
        if (rb.bodyType != RigidbodyType2D.Kinematic) {
            //print(gameObject + " " + -transform.rotation.eulerAngles.z);
            rb.AddForce(transform.up * ((180 - transform.rotation.eulerAngles.z) / 180) * -rb.linearVelocityY * forceConstant * publicForceConstant, ForceMode2D.Force);
            
            //Rotation Stuff
            float rotZ = transform.rotation.eulerAngles.z;
            if (rotZ > 180) {
                rotZ -= 360;
            }

            float rotVal = -rotZ * publicTorqueConstant;
            rb.angularVelocity += rotVal;
            //print(rotVal);
            if (rotVal > 0) {

            } else if (rotVal < 0) {

            }
        }
    }
}
