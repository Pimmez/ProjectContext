using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VideoPlayer))]
public class StreamVideo : MonoBehaviour
{    
    [SerializeField] private RawImage rawImage;
	[SerializeField] private string nextScene;
	private VideoPlayer videoPlayer;
    private bool isPlaying = false;
    private int currentFrame = 0;

    private void Start ()
	{
        videoPlayer = GetComponent<VideoPlayer>();
		isPlaying = true;
        StartCoroutine(PlayVideo());
    }

    private void Update()
    {
        if (isPlaying)
        {
            currentFrame = (int)videoPlayer.frame;
            //Debug.Log(currentFrame);

            if (currentFrame == (int)videoPlayer.frameCount - 3)
            {
                //Debug.Log("Video ended!");
                SceneManager.LoadScene(nextScene);
				isPlaying = false;
            }
        }
    }

    private IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
		{
            //Debug.Log("Whoops, not prepared yet");
            yield return waitForSeconds;
			break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}