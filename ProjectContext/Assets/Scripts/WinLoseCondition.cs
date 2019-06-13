using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class WinLoseCondition : MonoBehaviour
{
	public static Action<bool> AnimationPlayerEvent;

	[SerializeField] private string gameWonScene;
	[SerializeField] private string gameOverScene;


	private void GameWon()
	{
		if(AnimationPlayerEvent != null)
		{
			AnimationPlayerEvent(true);
		}

		StartCoroutine("EndGameWithAnim");
	}

	private IEnumerator EndGameWithAnim()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(gameWonScene);
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
