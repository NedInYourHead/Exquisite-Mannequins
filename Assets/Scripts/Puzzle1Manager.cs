using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1Manager : MonoBehaviour
{
    [SerializeField] private Color[] colourOptions = new Color[4];
    [SerializeField] private SpriteRenderer[] lockNumbers = new SpriteRenderer[4];
    private int[] combinationState = new int[4];
    private int[]

    private RiddleController riddleController;

    private void OnEnable()
    {
        for (int i = 0; i < combinationState.Length; i++)
        {
            combinationState[i] = 0;
        }
    }

    /*public void ChangeColour()
    {
        if (CurrentColour < 3)
        {
            CurrentColour += 1;
        }
        else
        {
            CurrentColour = 0;
        }
    }*/

    public bool CheckIfCorrect()
    {
        return true;
    }
}
