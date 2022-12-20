using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockPanelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> clockList;

    private void Awake() {
        
    }

    public void DisplayClockPanel() {
        this.gameObject.SetActive(true);

        int currentTime = PlayerPrefs.GetInt(TimeDisplayController.KEY_TIME, 0);
        int hours = currentTime / 60;
        int minutes = currentTime % 60;
        DisplayClocks(hours, minutes);
    }

    private void DisplayClocks(int hours, int minutes) {
        if (hours > clockList.Count) {
            foreach (GameObject clock in clockList) {
                clock.SetActive(true);
                clock.GetComponent<Image>().fillAmount = 1f;
            }
            return;
        } else {
            foreach (GameObject clock in clockList) {
                clock.SetActive(false);
            }
        }

        for (int i = 0; i < hours; i++) {
            GameObject clock = clockList[i];
            clock.SetActive(true);
            clock.GetComponent<Image>().fillAmount = 1f;
        }
        GameObject minuteClock = clockList[hours];
        minuteClock.SetActive(true);
        minuteClock.GetComponent<Image>().fillAmount = (float) minutes / 60f;
    }

    public void Back() {
        this.gameObject.SetActive(false);
    }
}
