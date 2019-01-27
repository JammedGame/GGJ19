using UnityEngine;

public class Debree : MonoBehaviour
{
	public void Update()
	{
		if (Vector3.Distance(Game.PlayerPosition, transform.position) > 15)
		{
			Destroy(gameObject);
		}
	}
}