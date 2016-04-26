using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject partPrefab;
    public MovePart movePartScript;
    public Transform ship;

    int i = 1;

    public void onClick()
    {
        Transform part = ((GameObject)Instantiate(partPrefab)).transform;
        movePartScript.part = part;
        part.parent = ship;
        part.position = ship.position;
        part.gameObject.name = partPrefab.name + i++;
        Global.controlShip = false;
    }

}
