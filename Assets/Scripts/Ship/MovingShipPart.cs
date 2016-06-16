using UnityEngine;
using System.Collections;

public class MovingShipPart : MonoBehaviour {

    new Transform transform;

    void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapAreaAll(new Vector2(mousePos.x - 0.5f, mousePos.y + 0.5f), new Vector2(mousePos.x + 0.5f, mousePos.y - 0.5f), LayerMask.GetMask("ShipGround"));

        Debug.Log(colliders.Length);

        Transform newParent = null;
        foreach (Collider2D c in colliders)
        {
            if (c.gameObject != gameObject && c.gameObject.tag == "ShipPart")
            {
                newParent = c.gameObject.transform.parent;
            }
        }

        if (newParent != null)
        {

            mousePos = newParent.InverseTransformPoint(mousePos);

            float x = mousePos.x - (int)mousePos.x;
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

            float y = mousePos.y - (int)mousePos.y;
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

            Vector3 newPos = new Vector3(x, y, transform.position.z);

            if (transform.position != newPos)
            {
                Collider2D[] colliders2 = Physics2D.OverlapAreaAll(new Vector2(x - 0.5f, y + 0.5f), new Vector2(x + 0.5f, y - 0.5f), LayerMask.GetMask("ShipGround"));
                foreach (Collider2D c in colliders2)
                {
                    if (c.gameObject != gameObject && c.gameObject.tag == "ShipPart")
                    {
                        newParent = c.gameObject.transform.parent;
                    }

                }

                if (transform.parent != newParent)
                    transform.parent = newParent;
                Quaternion newRot = new Quaternion(0f, 0f, newParent.rotation.z, newParent.rotation.w);
                transform.rotation = newRot;
                transform.localPosition = newPos;
            }
        }
        else
        {
            if (transform.parent != null)
                transform.SetParent(null);
            transform.position = new Vector2(mousePos.x, mousePos.y);
            transform.rotation = Quaternion.identity;
        }


        if (Input.GetMouseButtonDown(0))
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
