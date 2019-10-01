using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class MusicVideoPlayer : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoRenderer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayVideo()
    {
        videoRenderer.SetActive(true);
        videoPlayer.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayVideo();
    }
}
