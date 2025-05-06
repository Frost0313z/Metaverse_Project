using UnityEngine;
using UnityEngine.UI;

public class GuideUIToggleHandler : MonoBehaviour
{
    [SerializeField] private Toggle skipToggle;
    [SerializeField] private string keyName;

    void Start()
    {
        int savedValue = PlayerPrefs.GetInt(keyName, 0);

        // savedValue가 1이면 토글을 체크 상태로 만들고, 아니면 체크 해제
        if (savedValue == 1)
        {
            skipToggle.isOn = true;
        }
        else
        {
            skipToggle.isOn = false;
        }

        // 사용자가 토글을 변경했을 때 실행되는 함수 등록
        skipToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn) // 토글을 바꿨을 때 실행되는 함수
    {
        if (isOn)         // isOn이 true면 1, false면 0 저장
        {
            PlayerPrefs.SetInt(keyName, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyName, 0);
        }
        PlayerPrefs.Save();
    }
}
