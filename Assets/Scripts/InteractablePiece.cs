using UnityEngine;

[RequireComponent(typeof(KeySetter))]
public class InteractablePiece : MonoBehaviour
{
    public KeyCode myKey;

    public bool active = false;

    public void Activate()
    {
        active = true;
    }
}
