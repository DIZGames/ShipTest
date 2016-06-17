using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour, IShipPart{

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public ShipPartPosition position
    {
        get { return ShipPartPosition.BEETWEEN; }
    }
}
