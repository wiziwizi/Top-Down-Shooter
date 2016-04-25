using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public float health = 100f;

	private PlayerMovement playerMovement;
	private bool playerDead;

	void Awake()
	{
		playerMovement = GetComponent<PlayerMovement> ();
	}

	void Update()
	{
		if (health <= 0) 
		{
			PlayerDead ();
			LevelReset ();
		}
	}



	void PlayerDead()
	{
		playerMovement.enabled = false;
	}

	void LevelReset()
	{
		Debug.Log ("test");
		SceneManager.LoadScene("Main");
	}
}
