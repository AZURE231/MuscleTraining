using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int muscleNumber = 0;
    public int clickPower = 1;
    public int autoClicker = 0;
    public float power = 0f;
    public float powerDecreaseRate = 0.005f;
    public float powerIncreaseRate = 0.02f;
    public int multiplier = 1;
    public int mulTemp = 2;


    // Canva control
    public TMP_Text muscleNumerText;
    public TMP_Text clickPowerText;
    public TMP_Text multiplierText;

    [SerializeField] Slider slider;
    [SerializeField] GameObject textPrefab;

    [Header("Particle Effect")]
    [SerializeField] GameObject rain;

    [Header("CharacterAnimation")]
    [SerializeField] GameObject characterPushup;
    [SerializeField] GameObject characterDumbbell;
    [SerializeField] GameObject characterWeight;


    public static GameManager instance;

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
        UpdateText();
        StartCoroutine(AddClickPerSec());
        StartCoroutine(DecreasePowerPerSec());
    }

    // Update is called once per frame
    void Update()
    {
        if (power >= 0.8)
        {
            rain.SetActive(true);
        }
        else
        {
            rain.SetActive(false);
        }



        if (IsPointerOverUIObject()) return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Increase power for each click
                IncreasePower();
                switch (mulTemp)
                {
                    case 3:
                        characterDumbbell.GetComponent<Animator>().SetTrigger("Push");
                        break;
                    case 4:
                        characterWeight.GetComponent<Animator>().SetTrigger("Push");
                        break;
                    default:
                        characterPushup.GetComponent<Animator>().SetTrigger("Push");
                        break;
                }
                // power fever, xmultiplier clickpower
                if (power >= 0.8)
                {
                    multiplier = mulTemp;
                }
                else
                {
                    multiplier = 1;
                }

                IncreaseMuscle(clickPower * multiplier);
                CreateTextUp(touch.position);
                FindObjectOfType<AudioManager>().Play("TapSound");
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
        muscleNumerText.text = muscleNumber.ToString("#,#");
        clickPowerText.text = clickPower.ToString() + " Muscle per click";
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 1;
    }

    void CreateTextUp(Vector2 position)
    {
        var a = Instantiate(textPrefab, new Vector3(position.x, position.y), Quaternion.identity,
            GameObject.FindGameObjectWithTag("Canvas").transform);
        a.GetComponentInChildren<DetroyOnAnimationEnd>().muscleNumber.text =
            (clickPower * multiplier).ToString() + " Muscle!";
    }

    public void UpdateMultiplierText()
    {
        multiplierText.text = "x" + mulTemp.ToString();
    }

    public void UpdateCharacterAnimation()
    {
        characterPushup.SetActive(false);
        characterDumbbell.SetActive(false);
        characterWeight.SetActive(false);

        switch (mulTemp)
        {
            case 3:
                characterDumbbell.SetActive(true);
                characterDumbbell.GetComponent<Animator>().SetTrigger("Push");
                break;
            case 4:
                characterWeight.SetActive(true);
                characterWeight.GetComponent<Animator>().SetTrigger("Push");
                break;
            default:
                characterPushup.SetActive(true);
                characterPushup.GetComponent<Animator>().SetTrigger("Push");
                break;
        }
    }
}
