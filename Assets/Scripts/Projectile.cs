using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float _speed = 1;
	private GameObject player;
	private PlayerHealth playerHealth;
	private GameObject enemy;
	private EnemyHealth enemyHealth;
	private GameObject cam;
	private targetFollow TargetFollow;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.gameObject.GetComponent <PlayerHealth> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		if(enemy)
		{
			enemyHealth = enemy.gameObject.GetComponent <EnemyHealth> ();
		}

		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		TargetFollow = cam.gameObject.GetComponent <targetFollow>();
	}


	void Update ()
	{
		if (TimeControl.TIME == false) {
			transform.Translate (Vector3.forward * _speed * Time.deltaTime * TimeControl.TIME_FACTOR);

			if (playerHealth.health < 1)
			{
				TargetFollow.enabled = false;
				Destroy (player);
			}
		}
	}

	public void SetSpeed(float value)
	{
		_speed = value;
	}

	void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag ("SphereCol")) 
		{
			Destroy (gameObject);

			if (other.CompareTag ("Player")) 
			{
				float Damage = Random.Range (20, 60);
				playerHealth.health -= Damage;
			}
		}
	}
}