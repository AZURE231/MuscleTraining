using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetroyOnAnimationEnd : MonoBehaviour
{
    [SerializeField] TMP_Text muscleNumber;
    private void Start()
    {
        muscleNumber.text = (GameManager.instance.clickPower * GameManager.instance.multiplier)
            .ToString() + " Muscle!";
    }

    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
