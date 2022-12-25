using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanelController : MonoBehaviour
{
    public void DisplayMenu() {
        this.gameObject.SetActive(true);
    }

    public void Back() {
        this.gameObject.SetActive(false);
    }
}
