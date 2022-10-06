using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_PowerUp_Script : MonoBehaviour
{
	public GameObject powerUpPrefab;
	//public GameObject[] obstaclePrefabArr;
	private float startDelay = 5.0f;
	private float repeatingRate_Min = 6.0f;
	private float repeatingRate_Max = 14.0f;
	private PlayerController playerControllerScript;

	// Start is called before the first frame update
	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating("SpawnPowerUp", startDelay, Random.Range(repeatingRate_Min, repeatingRate_Max));
	}

	// Update is called once per frame
	void Update()
	{

	}

	void SpawnPowerUp()
	{
		Vector3 spawnPos = new Vector3(Random.Range(20, 50), 5, 0);
		if (playerControllerScript.isGameOver == false)
		{
			Instantiate(powerUpPrefab, spawnPos, powerUpPrefab.transform.rotation);
		}
	}
    
}
