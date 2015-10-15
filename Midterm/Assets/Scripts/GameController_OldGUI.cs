using UnityEngine;
using System.Collections;

public class GameController_OldGUI : MonoBehaviour {
	public GameObject respawnPoint;
	public ParticleSystem winningParticles;
	public GameObject player;

	//The amount of ellapsed time
	private float time = 0;
	
	//Flags that control the state of the game
	private bool isRunning = false;
	private bool isFinished = false;

	// Use this for initialization
	void Start () {
		InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		if(isRunning) {
			time += Time.deltaTime;
		}

		if(Input.GetAxis("Restart")>0) {
			RespawnPlayer();
		}
	}

	void OnGUI() {
		if(!isRunning) {
			string message;
			if(isFinished)
				message = "Click to Play Again";
			else
				message = "Click to Play";
			
			if(GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height/2, 140, 30), message)) {
				InitGame ();
			}
		}
		
		//If the player finished the game, show the final time
		if(isFinished) {
			GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "Your Time Was");
			GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)time).ToString());
		} else if(isRunning) {
			GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
			GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)time).ToString());
		}
	}

	private void InitGame() {
		time = 0;
		isRunning = true;
		isFinished = false;

		winningParticles.Stop();
		RespawnPlayer();
	}

	public void RespawnPlayer() {
		player.gameObject.transform.position = respawnPoint.transform.position;
	}

	public void Win() {
		isRunning = false;
		isFinished = true;

		winningParticles.Play();
	}
}
