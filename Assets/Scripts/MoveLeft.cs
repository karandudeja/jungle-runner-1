using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	private int speed = 15;
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
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

	    if (transform.position.x < leftBound)
	    {
		    if(gameObject.CompareTag("Obstacle") || gameObject.CompareTag("GroundRocks")){
		    	Destroy(gameObject);
		    }
        }
        
	    setSpeedOfMoveLeft();
    }
    
	private void setSpeedOfMoveLeft(){
		if(playerControllerScript.isLongJump == true){
			speed = 50;
		}
		else{
			speed = 15;
		}
	}
}
