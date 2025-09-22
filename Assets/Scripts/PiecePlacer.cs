using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PiecePlacer : MonoBehaviour
{
    PlacablePiece curPiece;

    List<PlacablePiece> placedPieces = new List<PlacablePiece>();

    [SerializeField]
    CameraController cameraController;
    [SerializeField]
    Person theGuy;
    [SerializeField]
    TextMeshProUGUI instructionText;
    [SerializeField]
    TextMeshProUGUI instructionText1;
    [SerializeField]
    TextMeshProUGUI restartText;
    [SerializeField]
    TextMeshProUGUI myKeyText;
    static TextMeshProUGUI keyText;

    [SerializeField]
    PlacablePiece[] piecePrefabs;

    void Start()
    {
        keyText = myKeyText;
    }

    void Update()
    {
        if (!KeySetter.Picking)
        {
            if (curPiece != null)
            {
                Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                curPiece.transform.position = newPos;

                if (Input.GetKey(KeyCode.R))
                {
                    curPiece.transform.Rotate(new Vector3(0, 0, -Time.deltaTime * 100));
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
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

            if (curPiece == null)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    curPiece = Instantiate(piecePrefabs[0], new Vector3(), new Quaternion());
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    curPiece = Instantiate(piecePrefabs[1], new Vector3(), new Quaternion());
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    curPiece = Instantiate(piecePrefabs[2], new Vector3(), new Quaternion());
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    curPiece = Instantiate(piecePrefabs[3], new Vector3(), new Quaternion());
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    curPiece = Instantiate(piecePrefabs[4], new Vector3(), new Quaternion());
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (curPiece != null)
                {
                    Place();
                }

                Activate();

                gameObject.AddComponent<FlyManager>();

                Destroy(this);
            }
        }
    }

    void Place()
    {
        placedPieces.Add(curPiece);

        curPiece.Place();
        curPiece = null;
    }

    PlacablePiece Pickup()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider == null)
        {
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
        cameraController.target = theGuy.gameObject;

        theGuy.GetComponent<PlacablePiece>().Activate();
        theGuy.active = true;

        instructionText1.gameObject.SetActive(false);
        instructionText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(true);
    }

    public static void ActivateKeyText()
    {
        keyText.gameObject.SetActive(true);
    }
    
    public static void DeactivateKeyText()
    {
        keyText.gameObject.SetActive(false);
    }

}
