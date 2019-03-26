using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StreamVideo : MonoBehaviour {
     
     [SerializeField] private RawImage rawImage;
     private VideoPlayer videoPlayer;
    private bool playing = false;
    private int currentFrame = 0;

    // Use this for initialization
    void Start () {
        videoPlayer = GetComponent<VideoPlayer>();
        playing = true;
        StartCoroutine(PlayVideo());
    }

    private void Update()
    {
        if (playing)
        {
            currentFrame = (int)videoPlayer.frame;
            Debug.Log(currentFrame);

            if (currentFrame == (int)videoPlayer.frameCount - 3)
            {
                Debug.Log("Video ended!");
                SceneManager.LoadScene("Main");
                playing = false;
            }
        }
    }



    IEnumerator PlayVideo()
    {
          videoPlayer.Prepare();
          WaitForSeconds waitForSeconds = new WaitForSeconds(1);
          while (!videoPlayer.isPrepared)
        {
            Debug.Log("Whoops, not prepared yet");
            yield return waitForSeconds;
               break;
          }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }
}