using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle1Manager : MonoBehaviour
{
    [SerializeField] private Color[] colourOptions = new Color[4];
    [SerializeField] private SpriteRenderer[] lockNumbers = new SpriteRenderer[4];
    
    [SerializeField] private int[] combinationState = new int[4];
    private int[] correctState = { 1, 3, 0, 2 };

    private RiddleController riddleController;

    [SerializeField] private UnityEvent OnCorrect;
    [SerializeField] private UnityEvent OnIncorrect;

    private void Awake()
    {
        riddleController = GameObject.Find("SceneManager").GetComponent<RiddleController>();
    }

    private void OnEnable()
    {
        //ResetPuzzle();
    }

    private void ResetPuzzle()
    {
        for (int i = 0; i < combinationState.Length; i++)
        {
            combinationState[i] = 0;
            lockNumbers[i].color = colourOptions[0];
        }
    }

    public void ChangeColour(int index)
    {
        if (combinationState[index] < 3)
        {
            combinationState[index] += 1;
        }
        else
        {
            combinationState[index] = 0;
        }
        lockNumbers[index].color = colourOptions[combinationState[index]];
    }

    private bool CompareArrays(int[] array1, int[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
            {
                Debug.Log(i.ToString() + " incorrect");
                return false;
            }
        }
        return true;
    }

    public void CheckIfCorrect()
    {
        if (CompareArrays(combinationState, correctState))
        {
            Debug.Log("Correct");
            OnCorrect.Invoke();
        }
        else
        {
            Debug.Log("Incorrect");
            OnIncorrect.Invoke();
        }
    }
}
