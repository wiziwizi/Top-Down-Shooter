using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float shootSpeed = 0f;
	public float patrolSpeed = 2f;
	public float chaseSpeed = 4f;
	public float chaseWaitTime = 5f / TimeControl.TIME_FACTOR;
	public float patrolWaitTime = 1f / TimeControl.TIME_FACTOR;
	public Transform[] patrolWayPoints;
	public float functie;

	private EnemySight enemySight;
	private NavMeshAgent nav;
	private Transform Player;
	private PlayerHealth playerHealth;
	private LastPlayerSighting lastPlayerSighting;
	private float chaseTimer;
	private float patrolTimer;
	private int wayPointIndex;
	private bool seen;

	void Awake()
	{
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<NavMeshAgent> ();
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = Player.GetComponent<PlayerHealth> ();

		GameObject controller = GameObject.FindGameObjectWithTag ("GameController");
		LastPlayerSighting sighting = controller.GetComponent<LastPlayerSighting> ();
		lastPlayerSighting = sighting;
	}

	void Update()
	{
		
		if (enemySight.playerInSight && playerHealth.health > 0f) 
		{
			functie = 1;
			Shooting ();
		} 
		else if (enemySight.personalLastSighting != lastPlayerSighting.resetPosition && playerHealth.health > 0f) 
		{
			functie = 2;
			Chasing ();
		} 
		else
		{
			functie = 3;
			Patrolling ();
		}
	}

	void Shooting()
	{
		nav.speed = shootSpeed * TimeControl.TIME_FACTOR;
		transform.LookAt (Player.transform.position);
		nav.SetDestination(Player.transform.position);

	}

	void Chasing()
	{
		transform.LookAt (Player.transform.position);
		Vector3 sightingDeltaPos = enemySight.personalLastSighting - transform.position;
		if (sightingDeltaPos.sqrMagnitude > 4f)
			nav.destination = enemySight.personalLastSighting;
		
		nav.speed = chaseSpeed * TimeControl.TIME_FACTOR;

		if (nav.remainingDistance < nav.stoppingDistance) {
			chaseTimer += Time.deltaTime;

			if (chaseTimer > chaseWaitTime) {
				lastPlayerSighting.position = lastPlayerSighting.resetPosition;
				enemySight.personalLastSighting = lastPlayerSighting.resetPosition;
				chaseTimer = 0f;
			}
		}

		else
		{
			chaseTimer = 0f;
		}
	}

	void Patrolling()
	{
		nav.speed = patrolSpeed * TimeControl.TIME_FACTOR;

		if (nav.remainingDistance < 0.5)
		{
			patrolTimer += Time.deltaTime;

			if (patrolTimer >= patrolWaitTime) 
			{
				if (wayPointIndex == patrolWayPoints.Length - 1)
				{
					wayPointIndex = 0;
				}
				else 
				{
					wayPointIndex++;
				}

				patrolTimer = 0f;
			}
		} else
			patrolTimer = 0f;

		nav.SetDestination (patrolWayPoints[wayPointIndex].position);
	}
}
