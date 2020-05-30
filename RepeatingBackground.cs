using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

	private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
	private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.

	//Awake is called before Start.
	private void Awake()
	{
		//Get and store a reference to the collider2D attached to Ground.
		groundCollider = GetComponent<BoxCollider2D>();
		//Store the size of the collider along the x axis (its length in units).
		groundHorizontalLength = groundCollider.size.x;
	}

	//Update runs once per frame
	private void Update()
	{
		//Check if the difference along the x axis between the camera and the position of the object this is attached to is greater than groundHorizontalLength.
		if (transform.position.x < -groundHorizontalLength)
		{
			//If true, this means this object is no longer visible and can be safely moved forward to be re-used.
			RepositionBackground();
		}
	}

	//Create looping background effect.
	private void RepositionBackground()
	{
		//This is how far to the right the background object will be moved, in this case, twice its length.
		Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

		//Move the object from it's position offscreen behind the player to the new position off-camera in front of the player.
		transform.position = (Vector2)transform.position + groundOffSet;
	}
}