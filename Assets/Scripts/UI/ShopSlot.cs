using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSlot : MonoBehaviour
{
    public int muscleCost;
    public string title;
    public string description;
    public Sprite sprite;
    public int multiplier;

    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text costText;
    [SerializeField] Image imageObject;
    [SerializeField] GameObject overlay;

    [SerializeField] GameObject purchaseButton;


    bool isPurchased = false;
    // Start is called before the first frame update
    void Start()
    {
        titleText.text = title;
        descriptionText.text = description;
        imageObject.sprite = sprite;
    }

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
    }

    public void ShopPurchase()
    {
        if (GameManager.instance.muscleNumber >= muscleCost)
        {
            isPurchased = true;
            purchaseButton.SetActive(false);
            GameManager.instance.mulTemp = multiplier;
            GameManager.instance.UpdateMultiplierText();
        }


    }
}
