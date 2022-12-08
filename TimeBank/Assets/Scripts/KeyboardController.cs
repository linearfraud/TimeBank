using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour
{
    [SerializeField] private TimeDisplayController timeDisplayController;

    [SerializeField] private Button deleteButton;
    [SerializeField] private Button checkButton;

    [SerializeField] private Sprite enabledDeleteButtonImage;
    [SerializeField] private Sprite enabledCheckButtonImage;
    [SerializeField] private Sprite disabledButtonImage;
    
    [SerializeField] private TMP_Text timeText;

    private int sign;

    public void DisplayKeyboard(int sign) {
        this.gameObject.SetActive(true);
        DeleteTimeText();
        this.sign = sign;
    }

    public void UpdateTimeText(string numberText) {
        if (timeText.text.Length == 3) return;

        timeText.text += numberText;
        deleteButton.image.sprite = enabledDeleteButtonImage;
        deleteButton.enabled = true;
        checkButton.image.sprite = enabledCheckButtonImage;
        checkButton.enabled = true;
    }

    public void CheckTime() {
        int timeValue = int.Parse(timeText.text);
        timeDisplayController.IncreaseTime(sign * timeValue);
        this.gameObject.SetActive(false);
    }

    public void Back() {
        this.gameObject.SetActive(false);
    }

    public void DeleteTimeText() {
        timeText.text = "";
        deleteButton.image.sprite = disabledButtonImage;
        deleteButton.enabled = false;
        checkButton.image.sprite = disabledButtonImage;
        checkButton.enabled = false;
    }
}
