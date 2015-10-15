using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	public GameObject respawnPoint;
	public ParticleSystem winningParticles;
	public Text hud;
	public Canvas gameOverUI;

	//The amount of ellapsed time
	private float timeD = 0;
	
	//Flag that control the state of the game
	private bool isRunning = false;

	// Use this for initialization
	void Start () {
		InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (isRunning) {
			hud.text = "Your have died " + (float)timeD + " times.";
		}

		if(Input.GetAxis("Restart")>0) {
			RespawnPlayer();
		}
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
		isRunning = false;

		gameOverUI.enabled = true;
		winningParticles.Play();
	}
}
