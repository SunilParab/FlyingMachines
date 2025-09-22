using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Border"))
        {
            Destroy(collision.collider.gameObject);
        }
    }

}
