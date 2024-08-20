using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeClick : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    int clickPowerCount = 0;
    int autoClickerCount = 0;

    // TMP Text
    [SerializeField] TMP_Text clickPowerCountText;
    [SerializeField] TMP_Text autoClickerCountText;

    // Start is called before the first frame update

    public void UpgradeClickPower()
    {
        if (gameManager.muscleNumber >= 50)
        {
            gameManager.muscleNumber -= 50;
            gameManager.clickPower += 1;
            gameManager.UpdateText();
            clickPowerCount += 1;
            clickPowerCountText.text = clickPowerCount.ToString();
        }

    }

    public void AutoClicker()
    {
        if (gameManager.muscleNumber >= 200)
        {
            gameManager.muscleNumber -= 200;
            gameManager.autoClicker += 1;
            gameManager.UpdateText();
            autoClickerCount += 1;
            autoClickerCountText.text = autoClickerCount.ToString();
        }
    }
}
