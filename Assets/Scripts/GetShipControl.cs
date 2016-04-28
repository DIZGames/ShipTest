using UnityEngine;
using System.Collections;

public class GetShipControl : MonoBehaviour {
    
    public GroundController groundController;

    public void click()
    {
        Global.controlType = 1;
        groundController.CheckShipWalls();
    }
}
