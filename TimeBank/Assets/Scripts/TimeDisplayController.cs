using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeDisplayController : MonoBehaviour
{
    public const string KEY_TIME = "Time";

    private const int MIN_TIME_VALUE = 0;
    private const int MAX_TIME_VALUE = 5999;

    [SerializeField] private TMP_Text currentTimeText;

    [SerializeField] private Button plusButton;
    [SerializeField] private Sprite enabledPlusButtonSprite;
    [SerializeField] private Sprite disabledPlusButtonSprite;
    [SerializeField] private Button minusButton;
    [SerializeField] private Sprite enabledMinusButtonSprite;
    [SerializeField] private Sprite disabledMinusButtonSprite;

    private void Start() {
        UpdateCurrentTimeText();
    }

    public void UpdateCurrentTimeText() {
        int currentTimeIntValue = PlayerPrefs.GetInt(KEY_TIME, 0);

        int hoursValue = currentTimeIntValue / 60;
        int minutesValue = currentTimeIntValue % 60;

        currentTimeText.text = $"{hoursValue.ToString("00")}:{minutesValue.ToString("00")}";
        HandleButtonState(currentTimeIntValue);
    }

    public void IncreaseTime(int value) {
        int currentTimeIntValue = PlayerPrefs.GetInt(KEY_TIME, 0);
        int newTimeIntValue = Mathf.Clamp(currentTimeIntValue + value, MIN_TIME_VALUE, MAX_TIME_VALUE);
        PlayerPrefs.SetInt(KEY_TIME, newTimeIntValue);
        UpdateCurrentTimeText();
    }

    public void DecreaseTime(int value) {
        int currentTimeIntValue = PlayerPrefs.GetInt(KEY_TIME, 0);
        int newTimeIntValue = Mathf.Clamp(currentTimeIntValue - value, MIN_TIME_VALUE, MAX_TIME_VALUE);
        PlayerPrefs.SetInt(KEY_TIME, newTimeIntValue);
        UpdateCurrentTimeText();
    }

    private void HandleButtonState(int timeValue) {
        if (timeValue == MIN_TIME_VALUE) {
            minusButton.enabled = false;
            minusButton.image.sprite = disabledMinusButtonSprite;
        } else {
            minusButton.enabled = true;
            minusButton.image.sprite = enabledMinusButtonSprite;
        }

        if (timeValue == MAX_TIME_VALUE) {
            plusButton.enabled = false;
            plusButton.image.sprite = disabledPlusButtonSprite;
        } else {
            plusButton.enabled = true;
            plusButton.image.sprite = enabledPlusButtonSprite;
        }
    }
}
