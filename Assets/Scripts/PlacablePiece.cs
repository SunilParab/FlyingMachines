using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlacablePiece : MonoBehaviour
{

    [Header("Components")]
    Rigidbody2D rb;
    Collider2D col;
    [SerializeField]
    KeySetter keySetter;

    List<FixedJoint2D> otherJoints = new List<FixedJoint2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        col = GetComponent<Collider2D>();
        keySetter = GetComponent<KeySetter>();
    }

    public void Place()
    {
        List<Collider2D> touching = new List<Collider2D>();
        Physics2D.OverlapCollider(col, touching);

        foreach (Collider2D otherCol in touching)
        {
            FixedJoint2D curJoint = gameObject.AddComponent<FixedJoint2D>();
            curJoint.connectedBody = otherCol.GetComponent<Rigidbody2D>();
        }

        if (keySetter != null) {
            ActivateKeySetter();
        }
    }

    public void Pickup()
    {
        FixedJoint2D[] myJoints = GetComponents<FixedJoint2D>();

        for (int i = myJoints.Length-1; i >= 0; i--)
        {
            Destroy(myJoints[i]);
        }

        for (int i = otherJoints.Count-1; i >= 0; i--)
        {
            Destroy(otherJoints[i]);
            otherJoints.RemoveAt(i);
        }

    }

    void ActivateKeySetter()
    {
        keySetter.Activate();
    }

    public void Activate()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;

        InteractablePiece inter = GetComponent<InteractablePiece>();
        if (inter != null)
        {
            inter.Activate();
        }

    }

}
