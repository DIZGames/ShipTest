using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour {

    void Update()
    {
        if (Global.controlShip)
        {
            Rigidbody2D r = GetComponent<Rigidbody2D>();
            if (Input.GetKey(KeyCode.UpArrow))
            {
                r.AddForce(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                r.AddForce(Vector2.down);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                r.AddForce(Vector2.right);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                r.AddForce(Vector2.left);
            }
        }
    }
}
