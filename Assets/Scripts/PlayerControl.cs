using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    float step = 0.05f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPos = transform.localPosition;
        if (Global.controlType == 2)
        {
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                newPos.y += step;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                newPos.y -= step;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                newPos.x += step;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                newPos.x -= step;
            }
        }
        transform.localPosition = newPos;
	}
}
