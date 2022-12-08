using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyHandler : MonoBehaviour
{
    [SerializeField] private List<GameObject> jellies;

    void Start() {
        int length = PlayerPrefs.GetInt(TimeDisplayController.KEY_TIME, 0) / 10;
        for (int i = 0; i < length; i++) {
            GameObject randomPrefab = jellies[Random.Range(0, jellies.Count)];

            Vector2 randomVector = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
            Vector2 randomScreenPosition = Camera.main.ViewportToScreenPoint(randomVector);
            Vector2 randomWorldPosition = Camera.main.ScreenToWorldPoint(randomScreenPosition);
            Instantiate(randomPrefab, randomWorldPosition, Quaternion.identity);
        }
    }
}
