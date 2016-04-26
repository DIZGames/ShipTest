using UnityEngine;
using System.Collections;

public class MovePart : MonoBehaviour {

    public Transform part;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (part != null && !Global.controlShip)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                part.position = new Vector3(part.position.x, part.position.y + 1, part.position.z);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                part.position = new Vector3(part.position.x, part.position.y - 1, part.position.z);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                part.position = new Vector3(part.position.x + 1, part.position.y, part.position.z);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                part.position = new Vector3(part.position.x - 1, part.position.y, part.position.z);
            }
        }
	}
}
