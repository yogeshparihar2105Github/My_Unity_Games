using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animatooer;
    float maxSpeed = 4f;

    float shipBoundaryRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        //Move the plane
            
        Vector3 pos = transform.position;

            //vertical movement
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        transform.position = pos;

        animatooer.SetFloat("Ymovement", pos.y);

            //horizontal movement
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        transform.position = pos;
        

        // RESTRICT the player to the camera's boundaries!

		// First to vertical, because it's simpler
		if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		// Now calculate the orthographic width based on the screen ratio
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		// Now do horizontal bounds
		if(pos.x+shipBoundaryRadius > widthOrtho) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		if(pos.x-shipBoundaryRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipBoundaryRadius;
		}

		// Finally, update our position!!
		transform.position = pos;


    }
}
