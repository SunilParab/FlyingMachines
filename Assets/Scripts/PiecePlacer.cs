using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PiecePlacer : MonoBehaviour
{
    [SerializeField]
    PlacablePiece curPiece;

    List<PlacablePiece> placedPieces = new List<PlacablePiece>();

    void Update()
    {

        if (curPiece != null)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curPiece.transform.position = newPos;
        }

        if (Input.GetMouseButtonDown(0)) {
            if (curPiece != null)
            {
                curPiece.Place();
                curPiece = null;
            }
            else
            {
                curPiece = Pickup();
                if (curPiece != null)
                {
                    curPiece.Pickup();
                }
            }
        }

    }

    PlacablePiece Pickup()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider == null) {
            return null;
        }
        return hit.collider.GetComponent<PlacablePiece>();
    }


    public void Activate()
    {
        foreach (PlacablePiece curPiece in placedPieces)
        {
            curPiece.Activate();
        }
    }

}
