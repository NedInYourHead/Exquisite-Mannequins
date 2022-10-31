using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    [SerializeField] private Sprite[] outfitSprites;
    [SerializeField] private Color[] outfitColours;
    [SerializeField] private SpriteRenderer avatar;
    [SerializeField] private GameObject[] unsolvedButtons;
    [SerializeField] private GameObject[] solvedButtons;

    private int currentOutfitIndex;
    public int CurrentOutfitIndex
    {
        get { return currentOutfitIndex; }
        set
        {
            if (value != currentOutfitIndex)
            {
                currentOutfitIndex = value;
                Camera.main.backgroundColor = outfitColours[currentOutfitIndex];
                avatar.sprite = outfitSprites[currentOutfitIndex];
            }
            else
            {
                currentOutfitIndex = 0;
                Camera.main.backgroundColor = outfitColours[0];
                avatar.sprite = outfitSprites[0];
            }
        }
    }


    public void Awake()
    {
        for(int i = 0; i < unsolvedButtons.Length; i++)
        {
            unsolvedButtons[i].SetActive(true);
        }
        for (int i = 0; i < solvedButtons.Length; i++)
        {
            solvedButtons[i].SetActive(false);
        }
    }

    /*public void ChangeOutfit(int index)
    {
        avatar.sprite
    }*/

    public void UnlockOutfit(int index)
    {
        solvedButtons[index].SetActive(true);
        unsolvedButtons[index].SetActive(false);
    }
}
