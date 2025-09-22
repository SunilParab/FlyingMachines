using UnityEngine;
using TMPro;

public class Person : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI distanceText;


    int distance;

    public bool active;

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            distance = (int)transform.position.x;

            distanceText.text = "Distance " + distance;
        }
    }
}
