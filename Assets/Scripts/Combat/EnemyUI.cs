using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{

    public TMP_Text titleText;
    public Image enemyImage;
    public TMP_Text scoreText;
    public bool isCombat = false;
    private int index;
    public GameObject defeatedText;

    public void SetIndex(int _index)
    {
        index = _index;
    }

    public void SetTitle(string title)
    {
        titleText.text = title;
    }

    public void SetImage(Sprite sprite)
    {
        enemyImage.sprite = sprite;
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetHasWon(bool hasWon)
    {
        if (hasWon)
        {
            defeatedText.SetActive(true);
        }
    }

    public void StartBattle()
    {
        // Open combat panel
        Combat.instance.SetUpCombat(index, this);
        Debug.Log("clicked!!!");
    }

}
