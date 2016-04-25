using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeControl : MonoBehaviour
{
	public static float TIME_FACTOR = 1;
	public static bool TIME = false;
	public GameObject[] Bullets;
	public List<NavMeshAgent> agent;
	public GameObject[] enemies;
	public bool pauze;
	public Projectile projectile;
	public EnemyAI enemyAI;
	public Canvas PauzeMenu;

	private float Time;
	private bool anyKeyPressed = false;
	private PlayerMovement playerMovement;
	private PlayerShooting playerShooting;

	void Awake ()
	{
		TimeControl.TIME = false;
		PauzeMenu.enabled = false;
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		for (int i = 0; i < enemies.Length; i++)
		{
			agent.Add(enemies [i].GetComponent<NavMeshAgent> ());
		}
	}


	void Update ()
	{
		if (Input.GetButton ("Up") || Input.GetButton ("Down") || Input.GetButton ("Left") || Input.GetButton ("Right"))
		{
			anyKeyPressed = true;
		} 

		if (!Input.GetButton ("Up") && !Input.GetButton ("Down") && !Input.GetButton ("Left") && !Input.GetButton ("Right"))
		{
			anyKeyPressed = false;
		}

		if (Input.GetKeyDown ("p"))
		{
			Pauze ();
		}

		if (anyKeyPressed)
		{
			if (TimeControl.TIME == false)
			{
				changeSpeedEnemy (4);
				TimeControl.TIME_FACTOR = 1f;
			}
			else
			{
				changeSpeedEnemy (0);
				TimeControl.TIME_FACTOR = 0f;
			}
		}

		else
		{
			if (TimeControl.TIME == false)
			{
				changeSpeedEnemy (1);
				TimeControl.TIME_FACTOR = 0.1f;
			}
			else
			{
				changeSpeedEnemy (0);
			}
		}
	}

	void Pauze ()
	{
		if (TimeControl.TIME == true)
		{
			TimeControl.TIME = false;
			PauzeMenu.enabled = false;
		}
		else if (TimeControl.TIME == false)
		{
			TimeControl.TIME = true;
			PauzeMenu.enabled = true;
		}
	}

	void changeSpeedEnemy (float speed)
	{
		for (int a = 0; a < enemies.Length; a++)
		{
			if (enemies [a] != null)
			{
				agent [a].speed = speed;
			}
		}
	}
}

