using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetroyOnAnimationEnd : MonoBehaviour
{
    [SerializeField] public TMP_Text muscleNumber;

    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
