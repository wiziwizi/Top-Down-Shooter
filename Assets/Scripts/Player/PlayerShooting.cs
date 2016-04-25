using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

	public Projectile projectile;
	public Transform muzzle;
	public float bulletSpeed;
	public float shootDelay;
	public Text counterText;
	public float fireRate = 0.1F / TimeControl.TIME_FACTOR;
	public bool gotUziBro;
	public float pistolAmmoLeft = 3;
	public float uziAmmoLeft = 1;
	public float ammoLeft = 3;
	public AudioClip shoot1;
	public AudioClip shoot2;
	public GameObject uzi;

	private float nextFire = 0.0F;
	private float bulletsP = 7;
	private float bulletsU = 30;
	private float bullets = 7;
	private float reloadDelay = 0.9F / TimeControl.TIME_FACTOR;
	private bool uziInHand;

	void Update()
	{
		if(gotUziBro == true && Input.GetKeyDown ("2"))
		{
			bullets = bulletsU;
			fireRate = 0.05f;
			ammoLeft = uziAmmoLeft;
			reloadDelay = 1.8f;
			uzi.SetActive(true);
			uziInHand = true;
		}
		else if (Input.GetKeyDown ("1"))
		{
			bullets = bulletsP;
			fireRate = 0.1f;
			ammoLeft = pistolAmmoLeft;
			reloadDelay = 0.9f;
			uzi.SetActive(false);
			uziInHand = false;
		}
		if (Input.GetMouseButton (0) && Time.time > nextFire && bullets > 0 && TimeControl.TIME == false) 
		{
			Shoot ();
		} 
		else if (Input.GetKeyDown ("r") && ammoLeft > 0 && bullets < 7 && TimeControl.TIME == false) 
		{
			bullets = 7;
			ammoLeft -= 1;
			nextFire = Time.time + reloadDelay;
		}
		else if (Input.GetKeyDown ("r") && ammoLeft > 0 && bullets < 30 && TimeControl.TIME == false && uziInHand == true) 
		{
			bullets = 30;
			ammoLeft -= 1;
			nextFire = Time.time + reloadDelay;
		}

		UpdateUI();
	}

	private void Shoot()
	{
		Projectile bullet = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;
		bullet.SetSpeed (bulletSpeed);
		nextFire = Time.time + fireRate;
		bullets -= 1; 
		SoundManager.instance.RandomizeSfx (shoot1, shoot2);
	}

	private void UpdateUI()
	{
		counterText.text = "Ammo Left:" + bullets.ToString() + " / " + ammoLeft.ToString();
	}


}
