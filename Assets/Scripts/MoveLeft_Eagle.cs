using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft_Eagle : MonoBehaviour
{
	public int speed = 10;
	private PlayerController playerControllerScript;
	private int leftBound = -15;

	// Start is called before the first frame update
	void Start()
	{
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (playerControllerScript.isGameOver == false)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}

		if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
			Destroy(gameObject);
		}
	}
}
