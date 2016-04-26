using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {

    public GameObject partPrefab;
    public movePart movePartScript;
    public Transform ship;

    public void onClick()
    {
        Transform part = ((GameObject)Instantiate(partPrefab)).transform;
        movePartScript.part = part;
        part.parent = ship;
        part.position = ship.position;
        Global.controlShip = false;
    }

}
