using UnityEngine;
using System.Collections;

// Add to Ship object
public class ShipControl : MonoBehaviour
{
    ShipData shipData;
    Rigidbody2D r;
    int forceStrength = 1;

    // Use this for initialization
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float vertAxis = Input.GetAxis("Vertical");
        float shipRotation = transform.rotation.eulerAngles.z;

        if (horAxis < 0) // Pressing Left, activating thrusters on the right side
        {
            foreach (Transform t in shipData.thrustersRight)
            {
                r.AddForceAtPosition(Quaternion.AngleAxis(shipRotation, Vector3.forward) * Vector2.left * forceStrength, t.position);
            }
        } 
        if (horAxis > 0) // Pressing Right, activating thrusters on the left side
        {
            foreach (Transform t in shipData.thrustersLeft)
            {
                r.AddForceAtPosition(Quaternion.AngleAxis(shipRotation, Vector3.forward) * Vector2.right * forceStrength, t.position);
            }
        }
        if (vertAxis > 0) // Pressing Up, activating thrusters on the back side
        {
            foreach (Transform t in shipData.thrustersBack)
            {
                r.AddForceAtPosition(Quaternion.AngleAxis(shipRotation, Vector3.forward) * Vector2.up * forceStrength, t.position);
            }
        }
        if (vertAxis < 0) // Pressing Down, activating thrusters on the front side
        {
            foreach (Transform t in shipData.thrustersFront)
            {
                r.AddForceAtPosition(Quaternion.AngleAxis(shipRotation, Vector3.forward) * Vector2.down * forceStrength, t.position);
            }
        }
    }

    public void setShipData(ShipData shipData)
    {
        this.shipData = shipData;
    }
}
