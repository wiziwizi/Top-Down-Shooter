using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public GameObject enemy;
	public float health = 100f;

	private GameObject Player;
	private PickUpSpawn pickUpSpawn;

	void Awake()
	{
		pickUpSpawn = enemy.GetComponent <PickUpSpawn> ();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Bullet"))
		{
			if (health < 1)
			{
				pickUpSpawn.LootSpawn ();
				Destroy (enemy);
			}
			else
			{
				float Damage = Random.Range (25, 60);
				health -= Damage;
			}
		}
	}
}
