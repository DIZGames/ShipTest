using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

    public GameObject shipPrefab;
    public GameObject floorPrefab;
    public GameObject bigWallPrefab;
    public GameObject smallWallPrefab;
    public Transform player;


    void Start(){
        Global.shipPrefab = shipPrefab;
    }

    public void ClickNewShip()
    {
        GameObject newShip = Instantiate(shipPrefab, player.transform.position + player.transform.up, player.transform.rotation) as GameObject;
        GameObject firstFloor = Instantiate(floorPrefab, newShip.transform.position, newShip.transform.rotation) as GameObject;
        firstFloor.transform.parent = newShip.transform;
    }

    public void ClickNewFloor()
    {
        GameObject newFloor = Instantiate(floorPrefab, Input.mousePosition, player.transform.rotation) as GameObject;
        newFloor.AddComponent<MovingShipPart>();
        Global.objectToMove = newFloor.transform;
    }

    public void ClickNewSmallWall()
    {

    }

    public void ClickNewBigWall()
    {

    }
}
