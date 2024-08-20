using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int muscleNumber = 0;
    private int clickPower = 1;

    // Canva control
    public TMP_Text muscleNumerText;
    public TMP_Text clickPowerText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                IncreaseMuscle(clickPower);
                UpdateText();
            }

        }
    }

    void IncreaseMuscle(int a)
    {
        muscleNumber += a;
    }

    void UpdateText()
    {
        muscleNumerText.text = muscleNumber.ToString();
        clickPowerText.text = clickPower.ToString();
    }

}
