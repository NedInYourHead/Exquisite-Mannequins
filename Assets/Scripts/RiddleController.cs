using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RiddleController : MonoBehaviour
{
    [SerializeField] private GameObject darkScreen;
    [SerializeField] private GameObject[] textBoxes;
    [SerializeField] private GameObject[] riddleBoxes;
    [SerializeField] private GameObject[] answerBoxes;
    private int openUIIndex;
    private Button darkScreenButton;


    private void Awake()
    {
        darkScreenButton = darkScreen.GetComponent<Button>();

        for (int i = 0; i < riddleBoxes.Length + textBoxes.Length; i++)
        {
            openUIIndex = i;
            CloseRiddle();
        }
    }

    public void OpenRiddle(int riddleIndex)
    {
        openUIIndex = riddleIndex;
        darkScreen.SetActive(true);
        darkScreenButton.enabled = true;
        riddleBoxes[riddleIndex].SetActive(true);
        answerBoxes[riddleIndex].SetActive(true);
    }

    public void OpenText(int textIndex)
    {
        openUIIndex = riddleBoxes.Length + textIndex;
        darkScreen.SetActive(true);
        darkScreenButton.enabled = false;
        textBoxes[textIndex].SetActive(true);
    }

    public void CloseRiddle()
    {
        darkScreen.SetActive(false);
        if (openUIIndex < riddleBoxes.Length)
        {
            riddleBoxes[openUIIndex].SetActive(false);
            answerBoxes[openUIIndex].SetActive(false);
        }
        else
        {
            textBoxes[openUIIndex - riddleBoxes.Length].SetActive(false);
        }
    }
}
