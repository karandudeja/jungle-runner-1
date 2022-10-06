using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
	public GameObject obstaclePrefab;
	public GameObject[] obstaclePrefabArr;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatingRate = 1.5f;
	private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	    InvokeRepeating("SpawnRandomObstacle", startDelay, repeatingRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
    
	void SpawnRandomObstacle()
	{
		int obstacleIndex = Random.Range(0, obstaclePrefabArr.Length);
		Vector3 spawnPos = new Vector3(Random.Range(20, 50), 0, 0);
		//Vector3 spawnPos = new Vector3(20, 0, 0);
		if (playerControllerScript.isGameOver == false)
		{
			//Instantiate(obstaclePrefabArr[obstacleIndex], spawnPos, obstaclePrefabArr[obstacleIndex].transform.rotation);
			Instantiate(obstaclePrefabArr[obstacleIndex], spawnPos, obstaclePrefabArr[obstacleIndex].transform.rotation);
		}
	}
}
