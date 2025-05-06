using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject enterUI;         
    [SerializeField] private GameObject guideUI;    
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    void Start()
    {
        yesButton.onClick.AddListener(() =>
        {
            enterUI.SetActive(false);    
            guideUI.SetActive(true);   
        });

        noButton.onClick.AddListener(() =>
        {
            enterUI.SetActive(false);         
        });
    }
}
