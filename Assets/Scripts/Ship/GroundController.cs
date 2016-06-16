using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundController : MonoBehaviour {

    List<Ground> grounds = new List<Ground>();

	// Use this for initialization
	void Start () {
        CheckShipWalls();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckShipWalls()
    {
        foreach (Ground ground in grounds)
        {
            ground.ShowAllWalls();
        }
        foreach(Ground ground in grounds)
        {
            ground.CheckWalls();
        }
        foreach (Ground ground in grounds)
        {
            ground.HideWalls();
        }
    }

    public void AddGround(Ground ground)
    {
        grounds.Add(ground);
    }

    public void RemoveGround(Ground ground)
    {
        grounds.Remove(ground);
    }
}
