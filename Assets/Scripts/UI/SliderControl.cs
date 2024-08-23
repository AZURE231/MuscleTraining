using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderControl : MonoBehaviour
{
    [SerializeField] GameObject x2Text;

    private void Start()
    {
        x2Text.SetActive(false);
    }

    void Update()
    {
        if (GameManager.instance.power >= 0.8)
        {
            x2Text.SetActive(true);
        }
        else
        {
            x2Text.SetActive(false);
        }
    }
}
