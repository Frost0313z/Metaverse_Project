using UnityEngine;
using UnityEngine.Video;

public class GuideVideoHandler : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    private void OnEnable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.isLooping = true;     // 반복 재생
            videoPlayer.Play();               // 자동 재생
        }
    }

    private void OnDisable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();               // 비활성화되면 정지
        }
    }
}