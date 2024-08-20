using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int muscleNumber { get; set; } = 0;
    public int clickPower { get; set; } = 1;
    public int autoClicker = 0;
    public float power = 0f;
    public float powerDecreaseRate = 0.005f;
    public float powerIncreaseRate = 0.02f;


    // Canva control
    public TMP_Text muscleNumerText;
    public TMP_Text clickPowerText;

    [SerializeField] Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        StartCoroutine(AddClickPerSec());
        StartCoroutine(DecreasePowerPerSec());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPointerOverUIObject()) return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                IncreasePower();
                IncreaseMuscle(clickPower);
            }

        }

    }

    IEnumerator AddClickPerSec()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            IncreaseMuscle(autoClicker);
        }
    }

    IEnumerator DecreasePowerPerSec()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            power -= powerDecreaseRate;
            power = Mathf.Clamp(power, 0f, slider.maxValue);
            slider.value = power;
            Debug.Log(power);
        }
    }

    void IncreasePower()
    {
        power += powerIncreaseRate;
        power = Mathf.Clamp(power, 0f, slider.maxValue);
        slider.value = power;
    }

    void IncreaseMuscle(int a)
    {
        muscleNumber += a;
        UpdateText();
    }



    public void UpdateText()
    {
        muscleNumerText.text = muscleNumber.ToString();
        clickPowerText.text = clickPower.ToString() + "";
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>(); EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 1;
    }

}
