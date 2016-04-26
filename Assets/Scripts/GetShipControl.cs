using UnityEngine;
using System.Collections;

public class GetShipControl : MonoBehaviour {
    
    public GroundController groundController;

    public void click()
    {
        Global.controlShip = true;
        groundController.CheckShipWalls();
    }
}
