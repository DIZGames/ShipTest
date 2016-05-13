using UnityEngine;
using System.Collections;

// Add to Ship object
[RequireComponent(typeof(ShipControl))]
public class ShipManagement : MonoBehaviour {

    ShipData shipData = new ShipData();

    void Awake()
    {
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.name.Contains("Thruster"))
            {
                float rotationZ = child.rotation.eulerAngles.z;
                
                if (rotationZ == 0)
                    shipData.thrustersBack.Add(child);
                else if (rotationZ > 175 && rotationZ < 185)
                    shipData.thrustersFront.Add(child);
                else if (rotationZ > 85 && rotationZ < 95)
                    shipData.thrustersRight.Add(child);
                else if (rotationZ > 265 && rotationZ < 275)
                    shipData.thrustersLeft.Add(child);
            }
        }
        GetComponent<ShipControl>().setShipData(shipData);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
