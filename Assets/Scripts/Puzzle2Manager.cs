using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle2Manager : MonoBehaviour
{
    [SerializeField] private Transform[] hands = new Transform[2];

    private int[] combinationState = new int[2];
    private int[] correctState = {3, 11};

    private RiddleController riddleController;

    [SerializeField] private UnityEvent OnCorrect;
    [SerializeField] private UnityEvent OnIncorrect;

    private void Awake()
    {
        riddleController = GameObject.Find("SceneManager").GetComponent<RiddleController>();
    }

    public void ResetPuzzle()
    {
        for (int i = 0; i < combinationState.Length; i++)
        {
            combinationState[i] = Random.Range(0, 12);
            hands[i].rotation = Quaternion.Euler(0f, 0f, -combinationState[i] * 30);
        }
    }

    public void MoveHand(int index)
    {
        if (combinationState[index] < 11)
        {
            combinationState[index] += 1;
        }
        else
        {
            combinationState[index] = 0;
        }
        hands[index].rotation = Quaternion.Euler(0f, 0f, -combinationState[index] * 30);
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
            OnCorrect.Invoke();
        }
        else
        {
            OnIncorrect.Invoke();
        }
    }
}
