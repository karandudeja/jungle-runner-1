using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{
	float timer;
	private Rigidbody powerUpRb;
	
	float angle = 0;
 
	void Start()
	{
		//timer = 0;
		//powerUpRb = GetComponent<Rigidbody>();
	}
 
	void Update()
	{
		//timer += Time.deltaTime;
		//powerUpRb.transform.Rotate(0, 0, oscillate(timer, 2, 1));
		//powerUpRb.transform.Translate(Vector2.right * oscillate(timer, 5, 1));
		transform.Translate(Vector3.up * oscillate(angle) * 0.1f);
		
		angle += 0.1f;
		
		if(angle > 360){
			angle = 0;
		}
	}
 
	float oscillate(float angleValue)
	{
		return Mathf.Sin(angleValue);
	}
}
