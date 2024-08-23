using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSlot : MonoBehaviour
{

    public string title;
    public Sprite image;

    public int count = 0;
    public int muscleCost = 0;
    public int clickPower = 0;
    public int autoClick = 0;

    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text countText;
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text costText;
    [SerializeField] Image imageObject;
    [SerializeField] GameObject overlay;

    bool isUnlocked = false;



    // Start is called before the first frame update
    void Start()
    {
        GenerateDesciption();
        titleText.text = title;
        imageObject.sprite = image;
        costText.text = muscleCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.muscleNumber >= muscleCost)
        {
            overlay.SetActive(false);
        }
        else
        {
            overlay.SetActive(true);
        }
        if (isUnlocked)
        {
            titleText.text = title;
            description.text = GenerateDesciption();
        }
        else
        {
            titleText.text = "????";
            description.text = "????";
        }
    }

    string GenerateDesciption()
    {
        string des = "";
        if (clickPower != 0)
        {
            des += "+" + clickPower.ToString() + " Click power/n";
        }
        if (autoClick != 0)
        {
            des += "+" + autoClick.ToString() + " Auto click/n";
        }
        return des;
    }

    public void SpendMuscle()
    {
        if (GameManager.instance.muscleNumber >= muscleCost && count <= 10)
        {
            isUnlocked = true;
            GameManager.instance.muscleNumber -= muscleCost;
            GameManager.instance.clickPower += clickPower;
            GameManager.instance.autoClicker += autoClick;
            GameManager.instance.UpdateText();
            count += 1;
            countText.text = count.ToString();
            FindObjectOfType<AudioManager>().Play("Buy");
        }
        else
        {
            transform.GetComponent<ObjectShake>().StartShaking();
        }
    }
}
