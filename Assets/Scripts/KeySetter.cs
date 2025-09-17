using UnityEngine;
using UnityEngine.InputSystem;

public class KeySetter : MonoBehaviour
{
    KeyCode chosenKey;

    [SerializeField] bool active;

    KeyCode[] possibleKeys = {KeyCode.Q,KeyCode.W,
        KeyCode.E,KeyCode.R,KeyCode.T,KeyCode.Y,
        KeyCode.U,KeyCode.I,KeyCode.O,KeyCode.P,
        KeyCode.A,KeyCode.S,KeyCode.D,KeyCode.F,
        KeyCode.G,KeyCode.H,KeyCode.J,KeyCode.K,
        KeyCode.L,KeyCode.Z,KeyCode.X,KeyCode.C,
        KeyCode.V,KeyCode.B,KeyCode.N,KeyCode.M,};

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeys();
    }

    void CheckKeys()
    {
        if (active) {
            foreach (KeyCode curKey in possibleKeys) {
                if (Input.GetKeyDown(curKey))
                {
                    SetKey(curKey);
                    return;
                }
            }
        }
    }

    void SetKey(KeyCode targetKey)
    {
        chosenKey = targetKey;
        active = false;
    }

}
