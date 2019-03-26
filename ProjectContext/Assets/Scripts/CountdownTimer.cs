using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

	[Tooltip("Timer in Seconds")]
	[SerializeField] private float timer = 60f;
	[SerializeField] private float penaltyTime = 0;

	private Text timerText;

	private void Start()
    {
		timerText = GetComponent<Text>();
    }

    private void Update()
    {
		timer -= Time.deltaTime;

		if(timer > 0)
		{
			UpdateLevelTimer(timer);
		}
		else
		{
			Debug.Log("GAME OVER");
		}
	}

	private void UpdateLevelTimer(float timerCounter)
	{
		int minutes = Mathf.FloorToInt(timerCounter / 60f);
		int seconds = Mathf.RoundToInt(timerCounter % 60f);

		string formatedSeconds = seconds.ToString();

		if (seconds == 60)
		{
			seconds = 0;
			minutes += 1;
		}

		timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}

	private void FaultTimer()
	{
		timer -= penaltyTime;
	}

	private void OnEnable()
	{
		NPCBehaviour.NPCHitEvent += FaultTimer;
	}

	private void OnDisable()
	{
		NPCBehaviour.NPCHitEvent -= FaultTimer;
	}
}