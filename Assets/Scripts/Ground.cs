using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

    public Collider2D wallTop;
    public Collider2D wallBottom;
    public Collider2D wallLeft;
    public Collider2D wallRight;
    public GroundController groundController;

    bool showWallBottom = true;
    bool showWallTop = true;
    bool showWallLeft = true;
    bool showWallRight = true;

	// Use this for initialization
	void Start () {
        groundController = FindObjectOfType(typeof(GroundController)) as GroundController;
        groundController.AddGround(this);
	}

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
	
    public void CheckWalls()
    {
        showWallBottom = true;
        showWallTop = true;
        showWallLeft = true;
        showWallRight = true;



        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            
            if (collider != wallTop && collider != wallBottom && collider != wallLeft && collider != wallRight)
            {
                if (collider.gameObject.name == "WallTop")
                    showWallBottom = false;
                else if (collider.gameObject.name == "WallBottom")
                    showWallTop = false;
                else if (collider.gameObject.name == "WallLeft")
                    showWallRight = false;
                else if (collider.gameObject.name == "WallRight")
                    showWallLeft = false;
            }
        }
        
    }

    public void HideWalls()
    {
        wallBottom.gameObject.SetActive(showWallBottom);
        wallTop.gameObject.SetActive(showWallTop);
        wallRight.gameObject.SetActive(showWallRight);
        wallLeft.gameObject.SetActive(showWallLeft);
    }

    public void ShowAllWalls(){
        wallBottom.gameObject.SetActive(true);
        wallTop.gameObject.SetActive(true);
        wallRight.gameObject.SetActive(true);
        wallLeft.gameObject.SetActive(true);
    }
}
