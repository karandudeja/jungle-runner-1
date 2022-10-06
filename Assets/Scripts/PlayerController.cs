using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
	private int jumpForce = 1000;
    public bool isOnGround = true;
    public bool isGameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
	public AudioClip crashSound;
	private int countKey = 0;
	public bool isLongJump = false;
	public bool isPowerUp = false;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI powerText;
	private float currentTime = 7.0f;
	public TextMeshProUGUI gameOver;
	public Button restartBtn;
	private float scoreValue = 0;
	private float olderFrameCount;
	//private float gravityModifier = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
	    playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
	    playerAudio = GetComponent<AudioSource>();
	    Physics.gravity = new Vector3(0.0f, -49.1f, 0.0f);
	    scoreValue = 0;
	    olderFrameCount = Time.frameCount;
	    
    }

    // Update is called once per frame
    void Update()
	{
		
	    if (Input.GetKeyDown(KeyCode.Space) && isOnGround && isGameOver == false) {
        	
		    countKey+=1;
		    
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		    playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
	        playerAudio.PlayOneShot(jumpSound, 1.0f);
          
	        if(countKey == 2){
	        	countKey = 0;
	        	isOnGround = false;
	        }
	        
	    }
	    
	    if (Input.GetKeyDown(KeyCode.Z) && isOnGround == false && isGameOver == false) {
		    isLongJump = true;
	    }
	    
	    if (isOnGround && isGameOver == false) {
		    isLongJump = false;
	    }
	    
	    scoreValue = (Time.frameCount - olderFrameCount)/10;
	    
	    if(isGameOver == false){
		    scoreText.text = "Score: " + Mathf.Ceil(scoreValue);
	    }
	    
	    checkPowerTextVisibility();
	         
    }
    
    
    
	public void RestartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
    
    
	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("PowerUp")){
			Destroy(other.gameObject);
			isPowerUp = true;
			StartCoroutine(PowerUpCountdownRoutine());
		}
	}
	
	
	void checkPowerTextVisibility(){
		if(isPowerUp){
			powerText.gameObject.SetActive(true);
			currentTime -= 1 * Time.deltaTime;
			powerText.text = "Power: " + Mathf.Ceil(currentTime);
		}
		else{
			powerText.gameObject.SetActive(false);
			currentTime = 7.0f;
		}
	}
	
	
	void updateTimer(float currentTime){
		currentTime += 1;
		float seconds = Mathf.FloorToInt(currentTime % 60);
	}
	
	
	IEnumerator PowerUpCountdownRoutine(){
		yield return new WaitForSeconds(6);
		isPowerUp = false;
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("MyGround"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && isPowerUp == false) {
	        //Debug.Log("Game Over!");
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
	        playerAudio.PlayOneShot(crashSound, 1.0f);
	        gameOver.gameObject.SetActive(true);
	        restartBtn.gameObject.SetActive(true);
	        olderFrameCount = Time.frameCount;
	        
        }
    }
}
