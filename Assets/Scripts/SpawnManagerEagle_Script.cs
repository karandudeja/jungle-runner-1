using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerEagle_Script : MonoBehaviour
{
	public GameObject obstaclePrefab;
	private Vector3 spawnPos = new Vector3(25, 2.8f, 0);
	private float startDelay = 10.0f;
	//private float repeatingRate = 1.5f;
	private float[] repeatingRateArray = {2.0f, 3.0f, 4.0f, 6.0f, 8.0f};
	private PlayerController playerControllerScript;

	// Start is called before the first frame update
	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
		//InvokeRepeating("SpawnEagle", startDelay, repeatingRate);
		InvokeRepeating("SpawnEagle", startDelay, repeatingRateArray[Random.Range(0, repeatingRateArray.Length)]);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void SpawnEagle()
	{
		Vector3 spawnPosNew = new Vector3(25, Random.Range(1, 4), 0);
		
		if (playerControllerScript.isGameOver == false)
		{
			Instantiate(obstaclePrefab, spawnPosNew, obstaclePrefab.transform.rotation);
		}
	}
}
