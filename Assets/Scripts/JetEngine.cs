using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JetEngine : InteractablePiece
{
    [Header("JetEngine")]
    public float totalFuel;
    float fuelRemaining;
    public float force;
    float amountToApply;

    [Header("Components")]
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fuelRemaining = totalFuel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fuelRemaining > 0 && amountToApply > 0)
        {
            rb.AddForce(transform.right * force * amountToApply, ForceMode2D.Force);
            fuelRemaining -= amountToApply;
            amountToApply = 0;
        }
    }

    void Update()
    {
        if (Input.GetKey(myKey) && active)
        {
            amountToApply += Time.deltaTime;
        }
    }
}
