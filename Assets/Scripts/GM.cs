﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 25;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;

	private GameObject clonePaddle;


	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		Setup();

	}
	
	public void Setup()
	{
		clonePaddle = Instantiate(paddle,transform.position,Quaternion.Euler(0,0,90f)) as GameObject;
		Instantiate(bricksPrefab,transform.position,Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1)
		{
			youWon.SetActive (true);
			Time.timeScale = .25f;
			Invoke("Reset",resetDelay);
		}

		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke("Reset",resetDelay);
		}
	}

	void Reset()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (0);
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " +lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle,transform.position,Quaternion.Euler(0,0,90f)) as GameObject;
	}

	public void DestroyBricks()
	{
		bricks--;
		CheckGameOver();
	}
		

}