using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    [SerializeField] GameObject controlPanel;
    [SerializeField] GameObject upgradePanel;
    [SerializeField] GameObject storePanel;
    [SerializeField] GameObject battlePanel;

    Animator upgradePanelAnimator;
    Animator battltPanelAnimator;
    // Start is called before the first frame update
    void Start()
    {
        upgradePanelAnimator = controlPanel.GetComponent<Animator>();

        storePanel.SetActive(false);
        upgradePanel.SetActive(false);
        battlePanel.SetActive(false);
    }

    public void ShowStorePanel()
    {
        FindObjectOfType<AudioManager>().Play("ScrollStone");
        storePanel.SetActive(true);
        upgradePanelAnimator.SetBool("Open", true);
        upgradePanelAnimator.SetBool("Close", false);
    }

    public void ShowUpgradePanel()
    {
        FindObjectOfType<AudioManager>().Play("ScrollStone");
        upgradePanel.SetActive(true);
        upgradePanelAnimator.SetBool("Open", true);
        upgradePanelAnimator.SetBool("Close", false);
    }

    public void CloseUpgradePanel()
    {
        FindObjectOfType<AudioManager>().Play("ScrollStone");
        upgradePanelAnimator.SetBool("Close", true);
        storePanel.SetActive(false);
        upgradePanel.SetActive(false);
    }

    public void OpenBattlePanel()
    {
        battlePanel.SetActive(true);
        battlePanel.GetComponent<Animator>().SetTrigger("Show");
    }

    public void CloseBattlePanel()
    {
        //battlePanel.GetComponent<Animator>().SetTrigger("Hide");
        battlePanel.SetActive(false);
    }
}
