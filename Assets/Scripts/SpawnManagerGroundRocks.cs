using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerGroundRocks : MonoBehaviour
{
	
	public GameObject[] groundPrefabsArr;
	private Vector3 spawnPos = new Vector3(25, 0, 0);
	private float startDelay = 1.0f;
	private float repeatingRate = 1f;
	private PlayerController playerControllerScript;

	// Start is called before the first frame update
	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating("SpawnRandomGroundRocks", startDelay, repeatingRate);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

    
	void SpawnRandomGroundRocks()
	{
		int groundRockIndex = Random.Range(0, groundPrefabsArr.Length);
		Vector3 spawnPosRocks = new Vector3(Random.Range(45,80), 6, Random.Range(1,4.5f));
		//Vector3 spawnPos = new Vector3(20, 0, 0);
		if (playerControllerScript.isGameOver == false)
		{
			//Instantiate(obstaclePrefabArr[obstacleIndex], spawnPos, obstaclePrefabArr[obstacleIndex].transform.rotation);
			Instantiate(groundPrefabsArr[groundRockIndex], spawnPosRocks, groundPrefabsArr[groundRockIndex].transform.rotation);
		}
	}
}
