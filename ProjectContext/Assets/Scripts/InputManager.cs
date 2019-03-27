using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

	[SerializeField] private string startScene;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Fire2"))
		{
			SceneManager.LoadScene(startScene);
		}
    }
}
