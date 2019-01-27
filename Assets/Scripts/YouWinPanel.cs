using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YouWinPanel : MonoBehaviour
{
	public Image image;
	public float youWinTimer;

	public void Start()
	{
		image.color = new Color(1, 1, 1, 0);
	}

	public void Update()
	{
		if(Game.YouWon)
		{
			youWinTimer += Time.deltaTime;
			image.color = new Color(1,1,1, youWinTimer);

			if(Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Space))
			{
				SceneManager.LoadScene("cover");
			}
		}
	}
}