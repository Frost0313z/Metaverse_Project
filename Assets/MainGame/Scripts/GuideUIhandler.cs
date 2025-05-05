using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideUIhandler : MonoBehaviour
{
    private GameObject guideUI;

    private void Awake()
    {
        guideUI = transform.Find("GuideUI")?.gameObject;
        Debug.Log("GuideUI 찾음? " + (guideUI != null));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 진입: " + collision.gameObject.name);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 진입함, UI 활성화 시도");
            guideUI.SetActive(true);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guideUI.SetActive(false);
        } 
    }
}
