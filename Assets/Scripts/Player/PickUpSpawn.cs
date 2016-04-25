using UnityEngine;
using System.Collections;

public class PickUpSpawn : MonoBehaviour {
	
	public GameObject Moneyz;
	public GameObject Uzi;
	public GameObject UziAmmo;
	public GameObject PistolAmmo;
	public Transform Loot;
	private GameObject player;

	private PlayerShooting playerShooting;
	private float chance;
	private float chanceForMoney;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerShooting = player.GetComponent <PlayerShooting>();
	}

	public void LootSpawn()
	{
		chance = Random.Range (0, 100);
		chanceForMoney = Random.Range (0, 100);

		Debug.Log ("done");
		if (chance < 30) 
		{
			Instantiate (PistolAmmo, Loot.position, Loot.rotation);
		}

		else if (chance >= 30 && chance < 50 && playerShooting.gotUziBro == true) 
		{
			Instantiate (UziAmmo, Loot.position, Loot.rotation);
		}

		else if (chance >= 50) 
		{
			Instantiate (Uzi, Loot.position, Loot.rotation);
		}

		if (chanceForMoney <= 50) 
		{
			Instantiate (Moneyz, Loot.position, Loot.rotation);
		}
	}
}
