using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RiddleController : MonoBehaviour
{
    [SerializeField] private GameObject darkScreen;
    [SerializeField] private GameObject[] riddleBoxes;
    [SerializeField] private GameObject[] answerBoxes;
    private int openRiddleIndex;


    private void Awake()
    {
        for (int i = 0; i < riddleBoxes.Length; i++)
        {
            openRiddleIndex = i;
            CloseRiddle();
        }
    }

    public void OpenRiddle(int riddleIndex)
    {
        openRiddleIndex = riddleIndex;
        darkScreen.SetActive(true);
        riddleBoxes[riddleIndex].SetActive(true);
        answerBoxes[riddleIndex].SetActive(true);
    }

    public void CloseRiddle()
    {
        darkScreen.SetActive(false);
        riddleBoxes[openRiddleIndex].SetActive(false);
        answerBoxes[openRiddleIndex].SetActive(false);
    }
}
