using UnityEngine;
using System.Collections;

public class DestroyPickUp : MonoBehaviour {

	private PlayerShooting playerShooting;
	private Score score;

	void Awake()
	{
		playerShooting = GetComponent <PlayerShooting> ();
		score = GetComponent <Score> ();
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag ("Ammo"))
		{
			Debug.Log ("ammo");
			playerShooting.ammoLeft += 1;
			Destroy (other.gameObject);
		}
		if(other.CompareTag ("UziAmmo"))
		{
			Debug.Log ("ummo"); 
			playerShooting.uziAmmoLeft += 1;
			Destroy (other.gameObject);
		}
		if(other.CompareTag ("UziGun"))
		{
			Debug.Log ("Uzi");
			playerShooting.gotUziBro = true;
			Destroy (other.gameObject);
		}
		if(other.CompareTag ("Money"))
		{
			Debug.Log ("cash");
			score.money += 1;
			Destroy (other.gameObject);
		}
	}
}
