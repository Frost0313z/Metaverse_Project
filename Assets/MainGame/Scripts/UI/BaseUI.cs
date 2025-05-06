using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager) // 초기설정
    {
        this.uiManager = uiManager;
    }
    
    protected abstract UIState GetUIState(); 
    public void SetActive(UIState state) // enum에 따라서 제어
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
