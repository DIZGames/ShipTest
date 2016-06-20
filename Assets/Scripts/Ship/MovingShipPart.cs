using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class MovingShipPart : MonoBehaviour {

    new Transform transform;
    new Collider2D collider;
    SpriteRenderer spriteRenderer;
    ShipPartPosition shipPartPosition;
    bool floorLevel;
    bool createsNewShip;
    float boxWidth = 0.2f; // Defines the width of the box in which the mouse position is checked for parts that can be set between Blocks (like Walls)

    void Start()
    {
        transform = gameObject.transform;
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        IShipPart iShipPart = GetComponent<IShipPart>();
        shipPartPosition = iShipPart.position;
        createsNewShip = iShipPart.createsNewShip;
        floorLevel = iShipPart.floorLevel;

        collider.enabled = false;
        Color color = spriteRenderer.color;
        color.a = 0.5f;
        spriteRenderer.color = color;
    }

    void OnDestroy()
    {
        collider.enabled = true;
        Color color = spriteRenderer.color;
        color.a = 1f;
        spriteRenderer.color = color;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(mousePos.x - 0.5f, mousePos.y + 0.5f), new Vector2(mousePos.x + 0.5f, mousePos.y - 0.5f), LayerMask.GetMask("ShipPart") | LayerMask.GetMask("ShipFloor"));

        Transform newParent = null;
        foreach (Collider2D c in colliders)
        {
            if (c.gameObject != gameObject)
            {
                newParent = c.gameObject.transform.parent;
            }
        }

        if (newParent != null)
        {
            if (transform.parent != newParent)
                transform.parent = newParent;
            Quaternion newRotation = new Quaternion(0f, 0f, newParent.rotation.z, newParent.rotation.w);
            transform.rotation = newRotation;

            mousePos = newParent.InverseTransformPoint(mousePos);
            float x = mousePos.x - (int)mousePos.x;
            float y = mousePos.y - (int)mousePos.y;
            if (shipPartPosition == ShipPartPosition.CENTER)
            {
                // Calculate x Position
                if (x >= 0)
                {
                    if (x >= 0.5)
                        x = (int)mousePos.x + 1;
                    else
                        x = (int)mousePos.x;
                }
                else
                {
                    if (x <= -0.5)
                        x = (int)mousePos.x - 1;
                    else
                        x = (int)mousePos.x;
                }

                // Calculate y Position
                if (y >= 0)
                {
                    if (y >= 0.5)
                        y = (int)mousePos.y + 1;
                    else
                        y = (int)mousePos.y;
                }
                else
                {
                    if (y <= -0.5)
                        y = (int)mousePos.y - 1;
                    else
                        y = (int)mousePos.y;
                }
            }
            else if(shipPartPosition == ShipPartPosition.BETWEEN)
            {
                if (Mathf.Abs(x) >= (0.5 - boxWidth) && Mathf.Abs(x) <= (0.5 + boxWidth))
                {
                    if(x >= 0)
                        x = (int)mousePos.x + 0.5f;
                    else
                        x = (int)mousePos.x - 0.5f;
                    if (y >= 0)
                    {
                        if(y <= 0.5f)
                            y = (int)mousePos.y;
                        else
                            y = (int)mousePos.y + 1;
                    }
                    else
                    {
                        y = Mathf.Abs(y);
                        if (y <= 0.5f)
                            y = (int)mousePos.y;
                        else
                            y = (int)mousePos.y - 1;
                    }
                    transform.Rotate(0, 0, 90);
                }
                else if (Mathf.Abs(y) >= 0.3 && Mathf.Abs(y) <= 0.7)
                {
                    if (x >= 0)
                    {
                        if (x <= 0.5f)
                            x = (int)mousePos.x;
                        else
                            x = (int)mousePos.x + 1;
                    }
                    else
                    {
                        x = Mathf.Abs(x);
                        if (x <= 0.5f)
                            x = (int)mousePos.x;
                        else
                            x = (int)mousePos.x - 1;
                    }
                    if (y >= 0)
                        y = (int)mousePos.y + 0.5f;
                    else
                        y = (int)mousePos.y - 0.5f;
                }
            }

            Vector3 newPos = new Vector3(x, y, transform.position.z);
            transform.localPosition = newPos;
        }
        else
        {
            if (transform.parent != null)
                transform.SetParent(null);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            transform.rotation = Quaternion.identity;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(newParent != null || createsNewShip)
            {
                RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if((hit.Length == 0 && shipPartPosition == ShipPartPosition.CENTER) 
                    || (hit.Length > 0 && (shipPartPosition == ShipPartPosition.BETWEEN || shipPartPosition == ShipPartPosition.ONTOP)))
                {
                    Global.objectToMove = null;
                    if (newParent == null)
                    {
                        GameObject newShip = Instantiate(Global.shipPrefab, transform.position, transform.rotation) as GameObject;
                        transform.SetParent(newShip.transform);
                    }
                    Destroy(this);
                }
            }
        }
    }
}
