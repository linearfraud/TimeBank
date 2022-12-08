using UnityEngine;
using TMPro;

public class TestPanelController : MonoBehaviour
{
    [SerializeField] private KeyboardController keyboardController;

    [SerializeField] private TMP_Text answerText;

    private int sign;

    public void DisplayTestPanel(int sign) {
        this.gameObject.SetActive(true);
        this.sign = sign;
        answerText.text = "";
    }

    public void PutAnswer(string numberText) {
        answerText.text += numberText;

        string currentText = answerText.text;
        if (currentText.Length == 2) {
            Validate(currentText);
        }
    }

    public void Back() {
        this.gameObject.SetActive(false);
    }

    private void Validate(string text) {
        int hourIntValue = System.DateTime.Now.Hour;
        int minuteIntValue = System.DateTime.Now.Minute;
        string answerText = (hourIntValue + minuteIntValue).ToString("00");

        if (text == answerText) {
            DisplayKeyboard();
        } else {
            Back();
        }
    }

    private void DisplayKeyboard() {
        keyboardController.DisplayKeyboard(this.sign);
        this.gameObject.SetActive(false);
    }
}
