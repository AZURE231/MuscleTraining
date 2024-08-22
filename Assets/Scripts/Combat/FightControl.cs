using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightControl : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemyContainer;

    [SerializeField] EnemiesDatabase enemiesDatabase;

    public static FightControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateEnemies();
    }

    void GenerateEnemies()
    {
        float itemHeight = enemyContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
        Destroy(enemyContainer.GetChild(0).gameObject);
        enemyContainer.DetachChildren();

        for (int i = 0; i < enemiesDatabase.GetEnemiesLength(); i++)
        {
            Enemy enemy = enemiesDatabase.GetEnemy(i);

            EnemyUI uiItem = Instantiate(enemyPrefab, enemyContainer).
                GetComponent<EnemyUI>();

            // Add information to enemy UI
            uiItem.SetImage(enemy.sprite);
            uiItem.SetTitle(enemy.title);
            uiItem.SetScore(enemy.point);
            uiItem.SetIndex(i);
            uiItem.SetHasWon(enemy.hasWon);

            //enemyContainer.GetComponent<RectTransform>().sizeDelta =
            //    Vector2.up * ((itemHeight + 50) * enemiesDatabase.GetEnemiesLength() + 50);
        }
    }

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

}
