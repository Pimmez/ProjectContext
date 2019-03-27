using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleMessageListener : MonoBehaviour
{
	private string readIncomingMessage;

    void OnMessageArrived(string msg)
    {
        Debug.Log("Message arrived: " + msg);
		readIncomingMessage = msg;
    }

	private void Update()
	{
		if(readIncomingMessage == "1")
		{
			SceneManager.LoadScene("Intro");
		}
	}

	void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
