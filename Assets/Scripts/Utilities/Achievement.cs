using UnityEngine;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public GameObject achievementPopupPrefab;
    public Transform canvasTransform;

    private bool firstPurchaseMade = false;
    private int clickCount = 0;

    public static AchievementManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void TrackClick()
    {
        clickCount++;

        // Check for click achievements
        if (clickCount == 10)
        {
            ShowAchievementPopup("Newbie Gymer", "Clicked 10 times!");
        }
        else if (clickCount == 1000)
        {
            ShowAchievementPopup("True Gymer", "Clicked 1000 times!");
        }
        else if (clickCount == 10000)
        {
            ShowAchievementPopup("Harcord Gymer", "Clicked 10,000 times!");
        }
    }

    public void TrackFirstPurchase()
    {
        if (!firstPurchaseMade)
        {
            firstPurchaseMade = true;
            ShowAchievementPopup("Pay to win", "First Purchase Made!");
        }
    }

    private void ShowAchievementPopup(string title, string message)
    {
        var popup = Instantiate(achievementPopupPrefab, canvasTransform);
        // Set the popup position at the top of the canvas
        RectTransform popupRectTransform = popup.GetComponent<RectTransform>();

        // Positioning at the top center
        popupRectTransform.anchoredPosition = new Vector2(0, -300);
        popup.transform.Find("Title").GetComponent<TMP_Text>().text = title;
        popup.transform.Find("Description").GetComponent<TMP_Text>().text = message;
    }
}

