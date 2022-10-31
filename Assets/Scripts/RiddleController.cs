using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiddleController : MonoBehaviour
{
    [SerializeField] private GameObject darkScreen;
    [SerializeField] private GameObject[] textBoxes;
    [SerializeField] private GameObject[] riddleBoxes;
    [SerializeField] private GameObject[] answerBoxes;
    private int openUIIndex;


    private void Awake()
    {

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
        darkScreen.layer = 6;
        riddleBoxes[riddleIndex].SetActive(true);
        answerBoxes[riddleIndex].SetActive(true);
    }

    public void OpenText(int textIndex)
    {
        openUIIndex = riddleBoxes.Length + textIndex;
        darkScreen.SetActive(true);
        darkScreen.layer = 8;
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
