using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinLoseCondition : MonoBehaviour
{
	private Animator anim;
	[SerializeField] private string gameWonScene;
	[SerializeField] private string gameOverScene;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void GameWon()
	{

		Debug.Log("WON");
		anim.SetTrigger("Activate");




		//SceneManager.LoadScene(gameWonScene);
	}

	private void GameOver()
	{
		SceneManager.LoadScene(gameOverScene);
	}

	private void OnEnable()
	{
		ScoreCounter.WinEvent += GameWon;
		CountdownTimer.GameLostEvent += GameOver;
	}

	private void OnDisable()
	{
		ScoreCounter.WinEvent -= GameWon;
		CountdownTimer.GameLostEvent -= GameOver;
	}
}
