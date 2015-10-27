using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private static GameController instance;
	public static GameController Instance
	{
		set
		{
			instance = value;
		}
		get
		{
			if (!instance)
			{
				GameObject singleton = new GameObject();
				instance = singleton.AddComponent<GameController>();
			}
			return instance;
		}
	}

	public GameObject player;
	public Light flashlight;
	public GameObject respawnPoint;
	public ParticleSystem winningParticles;
	public Text hud;
	public Text time;
	//public Text preTime;
	public Canvas gameOverUI;
	public RawImage flashUI;
	public bool dead = false;
	private float timer = 1;
	public Slider healthBarSlider;
	public Transform playerCenter, sightEnd;
	bool isLooking = false;
	public int timeD;
	

	//Flag that control the state of the game
	private bool isRunning = false;
	// Use this for initialization
	void Start () {
		instance = this;
		flashlight.enabled = false;
		flashUI.enabled = false;
		InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Raycasting ();

		if (isRunning) {
			hud.text = "Your have died " + (int)timeD + " times.";
			time.text = "Your Time = " + (int)timer;
		}

		if (Input.GetAxis ("Restart") > 0) {
			RespawnPlayer ();
		}

		if(isLooking == true && healthBarSlider.value>0)
			healthBarSlider.value -= .005f;

		if (healthBarSlider.value == 0)
			Lose ();

	}

	public void RespawnPlayer() {
		player.gameObject.transform.position = respawnPoint.transform.position;
	}

	public void InitGame() {
		isRunning = true;
	
		gameOverUI.enabled = false;

		winningParticles.Stop();
		winningParticles.Clear();
		RespawnPlayer();
	}

	public void Win() {
			Application.LoadLevel ("EndGame");

		gameOverUI.enabled = true;
		winningParticles.Play();
	}

	public void Lose() {
		Application.LoadLevel ("MainMenu");

	}

	public void flashlightGet() {
		flashlight.enabled = true;
	}

	void Raycasting () {
		isLooking = Physics.Linecast (playerCenter.position, sightEnd.position, 1 <<LayerMask.NameToLayer("Enemy"));
		Debug.DrawLine (playerCenter.position, sightEnd.position, Color.white);
	}
	
}
