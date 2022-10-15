using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnswerBox : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        InitialisePuzzle();
    }

    protected abstract void InitialisePuzzle();
}
