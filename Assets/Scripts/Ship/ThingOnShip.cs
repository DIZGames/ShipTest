using UnityEngine;
using System.Collections;

public class ThingOnShip: MonoBehaviour, IShipPart {

    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public ShipPartPosition position
    {
        get { return ShipPartPosition.ONTOP; }
    }

    public bool floorLevel
    {
        get { return false; }
    }

    public bool createsNewShip
    {
        get { return false; }
    }
}
