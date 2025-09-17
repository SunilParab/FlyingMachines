using UnityEngine;

public class PlacablePiece : MonoBehaviour
{

    [SerializeField]
    KeySetter keySetter;

    public void Place()
    {

    }


    void ActivateKeySetter()
    {
        keySetter.Activate();
    }

}
