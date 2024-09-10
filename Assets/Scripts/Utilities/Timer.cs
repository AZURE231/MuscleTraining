using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;

    private bool stopTimer;
    private float startTime;

    [SerializeField] Combat combat;

    void OnEnable()
    {
        // Reset timer and slider when the object is enabled
        stopTimer = false;
        startTime = Time.time; // Record the time when the timer starts
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    void Update()
    {
        if (stopTimer)
        {
            return;
        }

        float elapsedTime = Time.time - startTime;
        float timeRemaining = gameTime - elapsedTime;

        if (timeRemaining <= 0)
        {
            stopTimer = true;
            timeRemaining = 0; // Ensure the slider stops at 0
            combat.TimerUp();
        }

        timerSlider.value = timeRemaining;
    }
}
