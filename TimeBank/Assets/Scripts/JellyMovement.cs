using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
    private Vector2 randomDirection;
    private float randomSpeed;
    private float randomInterval;

    private float minXPosition;
    private float maxXPosition;
    private float minYPosition;
    private float maxYPosition;

    private void Start() {
        Vector2 minScreenPoint = Camera.main.ViewportToScreenPoint(new Vector2(0f, 0f));
        Vector2 minWorldPoint = Camera.main.ScreenToWorldPoint(minScreenPoint);
        Vector2 maxScreenPoint = Camera.main.ViewportToScreenPoint(new Vector2(1f, 1f));
        Vector2 maxWorldPoint = Camera.main.ScreenToWorldPoint(maxScreenPoint);

        minXPosition = minWorldPoint.x;
        minYPosition = minWorldPoint.y;
        maxXPosition = maxWorldPoint.x;
        maxYPosition = maxWorldPoint.y;

        UpdateRandomVariants();
    }

    void Update() {
        float deltaTime = Time.deltaTime;
        this.gameObject.transform.Translate(randomDirection * randomSpeed * deltaTime);
        
        Vector2 modifiedPosition = new Vector2(
            Mathf.Clamp(this.gameObject.transform.position.x, minXPosition, maxXPosition),
            Mathf.Clamp(this.gameObject.transform.position.y, minYPosition, maxYPosition)
        );
        this.gameObject.transform.position = modifiedPosition;

        randomInterval -= deltaTime;
        if (randomInterval < 0) {
            UpdateRandomVariants();
        }
    }

    private void UpdateRandomVariants() {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        randomSpeed = Random.Range(0.1f, 0.5f);
        randomInterval = Random.Range(2f, 7f);
    }
}
