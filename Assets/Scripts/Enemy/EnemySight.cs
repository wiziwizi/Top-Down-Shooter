using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;
	private LastPlayerSighting lastPlayerSighting;
	private GameObject player;
	private Vector3 previousSighting;

	void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
		col = GetComponentInChildren <SphereCollider> ();
		GameObject controller = GameObject.FindGameObjectWithTag ("GameController");
		LastPlayerSighting sighting = controller.GetComponent<LastPlayerSighting> ();
		lastPlayerSighting = sighting;

		player = GameObject.FindGameObjectWithTag ("Player");

		personalLastSighting = lastPlayerSighting.resetPosition;
		previousSighting = lastPlayerSighting.resetPosition;
	}

	void Update()
	{
		if(lastPlayerSighting.position != previousSighting)
		{
			personalLastSighting = lastPlayerSighting.position;
		}

		previousSighting = lastPlayerSighting.position;
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject == player)
		{
			playerInSight = false;

			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;

				if(Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius))
				{
					if(hit.collider.gameObject == player)
					{
						playerInSight = true;
						lastPlayerSighting.position = player.transform.position;
					}
				}
			}

			if(CalculatePathLength (player.transform.position) <= col.radius)
			{
				personalLastSighting = player.transform.position;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			playerInSight = false;
		}
	}

	float CalculatePathLength(Vector3 targetPosition)
	{
		NavMeshPath path = new NavMeshPath ();

		float pathLength = 0f;

		if(nav.enabled)
		{
			nav.CalculatePath (targetPosition, path);

			Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

			allWayPoints [0] = transform.position;
			allWayPoints [allWayPoints.Length - 1] = targetPosition;

			for(int i=0; i<path.corners.Length; i++)
			{
				allWayPoints [i + 1] = path.corners [i];
			}



			for (int i = 0; i < allWayPoints.Length-1; i++) 
			{
				pathLength += Vector3.Distance (allWayPoints [i], allWayPoints [i + 1]);
			}
				
		}
		return pathLength;
	}
}
