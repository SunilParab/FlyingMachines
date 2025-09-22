using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PiecePlacer : MonoBehaviour
{
    [SerializeField]
    PlacablePiece curPiece;

    [SerializeField]
    List<PlacablePiece> placedPieces = new List<PlacablePiece>();

    void Update()
    {
        if (!KeySetter.Picking) {
            if (curPiece != null)
            {
                Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                curPiece.transform.position = newPos;

                if (Input.GetKey(KeyCode.R)) {
                    curPiece.transform.Rotate(new Vector3(0,0,-Time.deltaTime*100));
                }
            }

            if (Input.GetMouseButtonDown(0)) {
                if (curPiece != null)
                {
                    Place();
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

            if (Input.GetKeyDown(KeyCode.Return)) {
                print("act");
                if (curPiece!= null) {
                    Place();
                }

                Activate();
                Destroy(gameObject);
            }
        }
    }

    void Place() {      
        placedPieces.Add(curPiece);

        curPiece.Place();
        curPiece = null;
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
