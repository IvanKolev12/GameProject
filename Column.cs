using UnityEngine;

public class Column : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Bird>() != null)
		{
			/*If the bird hits the trigger collider in between the columns then
			the bird had scored.*/
			GameControl.instance.BirdScored();
		}
	}
}