using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int flashCount = 3;
    public float flashSpeed = 0.1f;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FlashEffect());
        }
    }

    IEnumerator FlashEffect()
    {
        for (int i = 0; i < flashCount; i++)
        {
            // transparent
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.2f); // Transparent
            yield return new WaitForSeconds(flashSpeed);

            // opaque
            spriteRenderer.color = originalColor; // Opaque
            yield return new WaitForSeconds(flashSpeed);
        }
    }
}
