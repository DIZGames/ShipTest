using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f)){
                if (hit.transform.gameObject.name.Contains("part"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
	}
}
