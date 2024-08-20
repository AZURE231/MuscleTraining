using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    Animator upgradePanelAnimator;
    // Start is called before the first frame update
    void Start()
    {
        upgradePanelAnimator = upgradePanel.GetComponent<Animator>();

    }

    public void ShowUpgradePanel()
    {
        upgradePanelAnimator.SetBool("Open", true);
        upgradePanelAnimator.SetBool("Close", false);
    }

    public void CloseUpgradePanel()
    {
        upgradePanelAnimator.SetBool("Close", true);
    }
}
