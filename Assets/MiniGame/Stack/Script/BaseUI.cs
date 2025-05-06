using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

namespace MiniGame.Stack
{
    public abstract class BaseUI : MonoBehaviour
    {
        protected UIManager_Stack uIManager;

        public virtual void Init(UIManager_Stack uIManager)
        {
            this.uIManager = uIManager;
        }

        protected abstract UIState GetUIState();
        public void SetActive(UIState state)
        {
            gameObject.SetActive(GetUIState() == state);
        }
    }
}
