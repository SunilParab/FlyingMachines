using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Propeller : InteractablePiece
{
    [Header("Propeller")]
    public float totalFuel;
    float fuelRemaining;
    public float force;
    bool propellerOn = false;

    [Header("Components")]
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuelRemaining = totalFuel;
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fuelRemaining > 0 && active && propellerOn)
        {
            rb.AddForce(transform.right * force, ForceMode2D.Force);
            fuelRemaining -= 1;
        }
    }

        void Update()
    {
        if (Input.GetKeyDown(myKey) && active)
        {
            propellerOn = !propellerOn;
            anim.enabled = propellerOn;
        }
    }

}
