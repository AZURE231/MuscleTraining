using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UpgradeSlotUi : MonoBehaviour
{
    [Header("Layout Setting")]
    [SerializeField] float itemSpacing = 50f;
    float itemHeight;

    [Header("UI elements")]
    [SerializeField] GameObject upgradeInvPanel;
    [SerializeField] GameObject upgradePrefab;
    [SerializeField] Transform upgradeContainer;
    [Space(20)]
    [SerializeField] UpgradeInvDatabase upgradeDatabase;

    [SerializeField] GameObject overlay;

    [Space(20f)]
    [SerializeField] Image slotImage;
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text desctiption;
    [SerializeField] TMP_Text count;

    [SerializeField] Button upgradeButton;

    private void Start()
    {
        GenerateUpgradeUI();
    }

    void GenerateUpgradeUI()
    {
        // Delete template
        itemHeight = upgradeContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
        Destroy(upgradeContainer.GetChild(0).gameObject);
        upgradeContainer.DetachChildren();

        // Generate Upgrade
        for (int i = 0; i < upgradeDatabase.GetUpgradeLength(); i++)
        {
            UpgradeSlot slot = upgradeDatabase.GetUpgradeSlot(i);
            UpgradeSlotUi uiItem = Instantiate(upgradePrefab, upgradeContainer).GetComponent<UpgradeSlotUi>();

            uiItem.SetItemPosition(Vector2.down * i * (itemHeight + itemSpacing));
            uiItem.gameObject.name = "Upgrade " + i + "-" + slot.title;

            //Add information to ui slot
            uiItem.SetTitle(slot.title);
            uiItem.SetSlotImage(slot.art);
            uiItem.SetDescription(slot.clickPower, slot.autoClick, slot.muscleCost);
            uiItem.SetCount(slot.count);

            if (GameManager.instance.muscleNumber < slot.muscleCost)
            {
                uiItem.SetSlotAsNotUnlocked();
            }
            else
            {
                uiItem.SetSlotAsUnlocked();
                uiItem.OnUpgradePurchase();
            }

            // Resize item container
            upgradeContainer.GetComponent<RectTransform>().sizeDelta =
                Vector2.up * (itemHeight + itemSpacing) * upgradeDatabase.GetUpgradeLength();
        }
    }

    void OnUpgradePurchase()
    {
        Debug.Log("Purchase");
    }

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetSlotImage(Sprite sprite)
    {
        slotImage.sprite = sprite;
    }

    public void SetTitle(string _title)
    {
        title.text = _title;
    }

    public void SetDescription(int clickPower, int autoClick, int muscleCost)
    {
        string des = "";
        if (clickPower != 0)
        {
            des += "+" + clickPower.ToString() + "/n";
        }
        if (autoClick != 0)
        {
            des += "+" + autoClick.ToString() + "/n";
        }
        if (muscleCost != 0)
        {
            des += "-" + autoClick.ToString() + "/n";
        }
        desctiption.text = des;
    }

    public void SetCount(int _count)
    {
        count.text = _count.ToString();
    }

    public void SetSlotAsUnlocked()
    {
        overlay.SetActive(false);
    }

    public void SetSlotAsNotUnlocked()
    {
        overlay.SetActive(true);
    }



    public void OnUpgradePurchase(int itemIndex, UnityAction<int> action)
    {
        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }
}
