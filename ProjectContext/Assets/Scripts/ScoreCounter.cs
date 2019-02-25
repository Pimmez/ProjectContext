using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField] private int MaxScore = 4;

	private Text scoreText;
	private int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
		scoreText = GetComponent<Text>();
		totalScore = 0;
		scoreText.text = "Score: " + totalScore + " / " + MaxScore;
	}

	// Update is called once per frame
	void Update()
    {
        if(totalScore == MaxScore)
		{
			Debug.Log("Game Won");
		}
    }

	private void ScoreUpdater()
	{
		totalScore += 1;
		scoreText.text = "Score: " + totalScore + " / " + MaxScore;
	}

	private void OnEnable()
	{
		DestroyOnContact.EnemyDeadEvent += ScoreUpdater;
	}

	private void OnDisable()
	{
		DestroyOnContact.EnemyDeadEvent -= ScoreUpdater;
	}
}
