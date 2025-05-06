using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideUIhandler : MonoBehaviour
{
    private GameObject guideUI;

    private void Awake()
    {
        guideUI = transform.Find("GuideUI")?.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
