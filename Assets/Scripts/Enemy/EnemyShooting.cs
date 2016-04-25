using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public Projectile projectile;
	public Transform muzzle;
	public float bulletSpeed;
	public float shootDelay;
	public float bullets = 7;
	public float fireRate = 0.1F;
	public float maximumDamage = 60f;
	public float minimumDamage = 20f;

	private float reloadDelay = 1.5F;
	private EnemyAI enemyAI;
	private bool shooting;
	private float nextFire = 0.0F;

	void Awake()
	{
		enemyAI = GetComponent <EnemyAI> ();

	}


	void Update()
	{
		if (Time.time > nextFire && bullets > 0 && !shooting && enemyAI.functie == 1 && TimeControl.TIME == false) 
		{
			Shoot ();
		} 
		else if (Time.time < nextFire)
		{
			shooting = false;
		}
		else if (bullets < 1 ) 
		{
			nextFire = Time.time + reloadDelay / TimeControl.TIME_FACTOR;
			bullets = 7;
			shooting = false;
		}
}

	void Shoot()
	{
		shooting = true;
		bullets -= 1; 
		Projectile bullet = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;
		bullet.SetSpeed (bulletSpeed);
		nextFire = Time.time + fireRate / TimeControl.TIME_FACTOR;

	}
}