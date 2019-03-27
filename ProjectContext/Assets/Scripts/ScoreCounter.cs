using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCounter : MonoBehaviour
{
	public static Action WinEvent;

	[SerializeField] private int MaxScore = 8;

	private Text scoreText;
	private int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
		scoreText = GetComponent<Text>();
		totalScore = 0;
		scoreText.text = totalScore + "/" + MaxScore;
	}

	// Update is called once per frame
	void Update()
    {
        if(totalScore == MaxScore)
		{
			//Debug.Log("Game Won");
			if(WinEvent != null)
			{
				WinEvent();
			}
		}
    }

	private void ScoreUpdater()
	{
		totalScore += 1;
		scoreText.text = totalScore + "/" + MaxScore;
	}

	private void OnEnable()
	{
		EnemyBehaviour.EnemyDeadEvent += ScoreUpdater;
	}

	private void OnDisable()
	{
		EnemyBehaviour.EnemyDeadEvent -= ScoreUpdater;
	}
}
