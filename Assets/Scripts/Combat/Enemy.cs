using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Enemy
{
    public string title;
    public int point;
    public Sprite sprite;

    public bool hasWon = false;

    public void SetWon()
    {
        hasWon = true;
    }
}
