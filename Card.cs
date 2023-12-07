using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardClass
{
    Human,
    Orc,
    Undead,
    NightElf,
    Neutral
}

[System.Serializable]
public class Card
{
    public string cardName;
    [TextArea(1, 3)]
    public string cardDes;

    public Sprite cardSprite;
    public Sprite cardBgSprite;
    public CardClass cardClass;

    public int cardMana;
    public int cardAttack;
    public int cardHealth;
}
