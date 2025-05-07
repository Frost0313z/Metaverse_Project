using UnityEngine;

/// 가로 게임 내에서 세로 미니게임 구간 진입 시, 레터박스(검은 여백)로 세로화면을 연출합니다.
/// 
[RequireComponent(typeof(Camera))]
public class LetterboxCameraSetter : MonoBehaviour
{
    [Header("세로 비율 타겟 (예: 9:16)")]
    public float targetAspectRatio = 9f / 16f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        ApplyLetterbox();
    }

    public void ApplyLetterbox()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        float scaleHeight = screenAspect / targetAspectRatio;

        if (scaleHeight < 1f)
        {
            // 화면이 더 세로인 경우: 좌우에 검은 여백 추가 (pillarbox)
            Rect rect = cam.rect;

            rect.width = scaleHeight;
            rect.height = 1f;
            rect.x = (1f - scaleHeight) / 2f;
            rect.y = 0f;

            cam.rect = rect;
        }
        else
        {
            // 화면이 더 가로인 경우: 위아래에 검은 여백 추가 (letterbox)
            float scaleWidth = 1f / scaleHeight;

            Rect rect = cam.rect;

            rect.width = 1f;
            rect.height = scaleWidth;
            rect.x = 0f;
            rect.y = (1f - scaleWidth) / 2f;

            cam.rect = rect;
        }
    }

    public void ResetCamera()
    {
        cam.rect = new Rect(0f, 0f, 1f, 1f); // 원래대로 복원
    }
}
