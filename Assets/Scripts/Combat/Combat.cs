using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    [SerializeField] EnemiesDatabase enemies;
    private float playerPoint;
    private float enemyPoint;
    public float enemyAttack;
    public float playerAttack;
    private int indexEnemy;

    [SerializeField] GameObject timer;

    [Header("Fight Panel")]
    [SerializeField] GameObject fightPanel;
    [SerializeField] Image enemyImage;
    [SerializeField] Image playerImage;
    [SerializeField] TMP_Text enemyPointText;
    [SerializeField] TMP_Text playerPointText;
    [SerializeField] TMP_Text notification;
    [SerializeField] Animator resultAnimator;
    [SerializeField] ObjectShake enemyShake;
    [SerializeField] ObjectShake playerShake;
    [SerializeField] GameObject textPrefab;



    EnemyUI enemy;
    bool isCombat = false;

    public static Combat instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetUpCombat(int index, EnemyUI enemyUI)
    {
        enemy = enemyUI;
        fightPanel.SetActive(true);
        timer.SetActive(true);
        notification.text = "";
        enemyImage.sprite = enemies.GetEnemy(index).sprite;
        enemyPointText.text = enemies.GetEnemy(index).point.ToString();
        playerPointText.text = GameManager.instance.muscleNumber.ToString();

        enemyPoint = enemies.GetEnemy(index).point;
        playerPoint = GameManager.instance.muscleNumber;
        enemyAttack = (int)enemyPoint / 20;
        playerAttack = (int)playerPoint / 20;
        isCombat = true;
        StartCoroutine(EnemyAttack());

    }

    public void PlayerAttack()
    {
        if (!isCombat) return;
        enemyPoint -= playerAttack;
        enemyPointText.text = enemyPoint.ToString();
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        enemyShake.StartShaking();
        var a = Instantiate(textPrefab, enemyPointText.transform.position, Quaternion.identity,
            GameObject.FindGameObjectWithTag("Canvas").transform);
        a.GetComponentInChildren<DetroyOnAnimationEnd>().muscleNumber.text =
            "-" + playerAttack.ToString();
        StartCoroutine(FlashRed(enemyImage));

    }

    IEnumerator EnemyAttack()
    {
        while (playerPoint > 0 && isCombat)
        {
            yield return new WaitForSeconds(1);
            playerPoint -= enemyAttack;
            playerPointText.text = playerPoint.ToString();
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            playerShake.StartShaking();
            var a = Instantiate(textPrefab, playerPointText.transform.position, Quaternion.identity,
            GameObject.FindGameObjectWithTag("Canvas").transform);
            a.GetComponentInChildren<DetroyOnAnimationEnd>().muscleNumber.text =
                "-" + enemyAttack.ToString();
            StartCoroutine(FlashRed(playerImage));
        }
    }

    private void Update()
    {
        if (!isCombat) return;
        if (enemyPoint <= 0)
        {
            PlayerWon();
        }
        if (playerPoint <= 0)
        {
            PlayerLost();
        }
    }

    public void TimerUp()
    {
        if (!isCombat) return;
        if (playerPoint > enemyPoint)
        {
            PlayerWon();
        }
        else
        {
            PlayerLost();
        }
    }

    void PlayerWon()
    {
        timer.SetActive(false);
        notification.text = "YOU WON!";
        enemies.GetEnemy(indexEnemy).SetWon();
        isCombat = false;
        enemy.SetHasWon(true);
        resultAnimator.SetTrigger("Win");
        FindObjectOfType<AudioManager>().Play("Win");
        StartCoroutine(WaitToCloseCombat());


        //fightPanel.SetActive(false);
        // Update UI?

    }

    void PlayerLost()
    {
        notification.text = "YOU LOST!";
        timer.SetActive(false);
        isCombat = false;
        resultAnimator.SetTrigger("Lose");
        FindObjectOfType<AudioManager>().Play("Lose");
        StartCoroutine(WaitToCloseCombat());

        //fightPanel.SetActive(false);
    }

    IEnumerator WaitToCloseCombat()
    {
        yield return new WaitForSeconds(3);
        fightPanel.SetActive(false);
    }

    IEnumerator FlashRed(Image img)
    {
        img.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        img.color = Color.white;
    }
}
