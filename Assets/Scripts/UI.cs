using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    public GameObject shipPrefab;
    public GameObject floorPrefab;
    public GameObject wallBigPrefab;
    public GameObject wallSmallPrefab;
    public GameObject thingOnShipPrefab;


    void Start(){
        Global.shipPrefab = shipPrefab;
    }

    public void ClickNewShip()
    {

    }

    public void ClickNewFloor()
    {
        GameObject newFloor = Instantiate(floorPrefab, Input.mousePosition, Quaternion.identity) as GameObject;
        newFloor.AddComponent<MovingShipPart>();
        Global.objectToMove = newFloor.transform;
    }

    public void ClickNewSmallWall()
    {
        GameObject newWall = Instantiate(wallSmallPrefab, Input.mousePosition, Quaternion.identity) as GameObject;
        newWall.AddComponent<MovingShipPart>();
        Global.objectToMove = newWall.transform;
    }

    public void ClickNewBigWall()
    {
        GameObject newWallB = Instantiate(wallBigPrefab, Input.mousePosition, Quaternion.identity) as GameObject;
        newWallB.AddComponent<MovingShipPart>();
        Global.objectToMove = newWallB.transform;
    }

    public void ClickNewThingOnShip()
    {
        GameObject newThing = Instantiate(thingOnShipPrefab, Input.mousePosition, Quaternion.identity) as GameObject;
        newThing.AddComponent<MovingShipPart>();
        Global.objectToMove = newThing.transform;
    }
}
