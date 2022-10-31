using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    [SerializeField] private Sprite[] outfitSprites;
    [SerializeField] private Color[] outfitColours;
    [SerializeField] private SpriteRenderer avatar;

    private int currentOutfitIndex;
    private int CurrentOutfitIndex
    {
        get { return currentOutfitIndex; }
        set
        {
            currentOutfitIndex = value;
            Camera.main.backgroundColor = outfitColours[currentOutfitIndex];
            avatar.sprite = outfitSprites[currentOutfitIndex];
        }
    }

    public void ChangeOutfit(int index)
    {

    }

    public void UnlockOutfit()
    {

    }
}
