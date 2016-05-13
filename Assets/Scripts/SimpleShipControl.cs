using UnityEngine;
using System.Collections;

// Add to Ship object
public class SimpleShipControl : MonoBehaviour {

    int forceStrength = 1;

    void Update()
    {
        if (Global.controlType == 1)
        {
            Rigidbody2D r = GetComponent<Rigidbody2D>();
            if (Input.GetKey(KeyCode.UpArrow))
            {
                r.AddForce(Vector2.up * forceStrength);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                r.AddForce(Vector2.down * forceStrength);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                r.AddForce(Vector2.right * forceStrength);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                r.AddForce(Vector2.left * forceStrength);
            }
        }
    }
}
