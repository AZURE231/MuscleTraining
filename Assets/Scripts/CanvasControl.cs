using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    [SerializeField] GameObject controlPanel;
    [SerializeField] GameObject upgradePanel;
    [SerializeField] GameObject storePanel;

    Animator upgradePanelAnimator;
    // Start is called before the first frame update
    void Start()
    {
        upgradePanelAnimator = controlPanel.GetComponent<Animator>();
        storePanel.SetActive(false);
        upgradePanel.SetActive(false);
    }

    public void ShowStorePanel()
    {
        storePanel.SetActive(true);
        upgradePanelAnimator.SetBool("Open", true);
        upgradePanelAnimator.SetBool("Close", false);
    }

    public void ShowUpgradePanel()
    {
        upgradePanel.SetActive(true);
        upgradePanelAnimator.SetBool("Open", true);
        upgradePanelAnimator.SetBool("Close", false);
    }

    public void CloseUpgradePanel()
    {
        upgradePanelAnimator.SetBool("Close", true);
        storePanel.SetActive(false);
        upgradePanel.SetActive(false);
    }
}
