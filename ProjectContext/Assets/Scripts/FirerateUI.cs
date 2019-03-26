using UnityEngine;
using UnityEngine.UI;

public class FirerateUI : MonoBehaviour
{
	public static FirerateUI Instance { get { return GetInstance(); } }

	#region Singleton
	private static FirerateUI instance;
	private static FirerateUI GetInstance()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<FirerateUI>();
		}
		return instance;
	}
	#endregion

	public bool CoolDown { get { return isCoolingdown; } set { isCoolingdown = value; } }

	private Image image;
    [SerializeField] private Throw fire;
	private float waitTime = 1f;

	private bool isCoolingdown = false;

	private void Start()
    {
		image = GetComponent<Image>();
        fire.GetComponent<Throw>();
        waitTime = fire.fireRate;
    }

    private void Update()
    {
		if(isCoolingdown == true)
		{
			image.fillAmount -= 1.0f / waitTime * Time.deltaTime;
		}
		if (image.fillAmount == 0)
		{
			image.fillAmount = 1;
			isCoolingdown = false;
		}
	}
}