using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetroyOnAnimationEnd : MonoBehaviour
{
    [SerializeField] public TMP_Text muscleNumber;

    public void DestroyParent()
    {
        if (muscleNumber != null)
        {
            Debug.Log("muscleNumber is assigned correctly");
        }
        else
        {
            Debug.Log("muscleNumber is not assigned");
        }

        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
