using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSCount : MonoBehaviour
{
    private int lastFrameIndex;
    private float[] frameDeltaTimeArray;
    [SerializeField] TMP_Text fpsCounterUI; 

    private void Awake()
    {
        frameDeltaTimeArray = new float[50];
    }

    private void Update()
    {
        frameDeltaTimeArray[lastFrameIndex] = Time.deltaTime;
        lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;

        fpsCounterUI.text = Mathf.RoundToInt(CalculateFPS()).ToString();

    }

    private float CalculateFPS()
    {
        float total = 0f;

        foreach(float deltatime in frameDeltaTimeArray)
        {
            total += deltatime;
        }

        return frameDeltaTimeArray.Length / total;
    }

}
