using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public float fallSpeed = 2f;

    [Header("References")]
    public Switch switchScript;
    public HealthBar healthBar;
    public TMP_Text gameOverText;
    public TMP_Text gameWinText;
    private GameObject parachute;

    [Header("Health")]
    public float maxHealth = 5;
    private float damageAmount = 1f;

    [Header("Damage Effect")]
    public float flashDuration = 0.1f;  // How long each flash lasts
    public int numberOfFlashes = 3;      // How many times to flash
    public Color flashColor = Color.blue;  // Color to flash to

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isFlashing = false;

    private void Start()
    {
        SetRigidbody2D();
        healthBar.SetMaxHealth(maxHealth);
        gameOverText.gameObject.SetActive(false);
        
        // Get and store the SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        parachute = transform.Find("Parachute").gameObject;
    }

    private void Update()
    {
        Move();
        RenderParachute();
    }

    private void RenderParachute()
    {
        parachute.SetActive(switchScript.isPresent);
    }

    private void Move()
    {
        float move = Input.GetAxis("Horizontal");
        float speed = switchScript.isPresent ? -fallSpeed : -fallSpeed * 2;
        rb.velocity = new Vector2(move * moveSpeed, speed);
    }

    private void SetRigidbody2D()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TakeDamage(damageAmount);
            StartFlashing();
            Debug.Log("Triggered obstacle: " + other.gameObject.name);
        }
        if (other.CompareTag("Spikes"))
        {
            healthBar.SetHealth(0);
            Debug.Log("Game Over");
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Win();
        }
    }

    private void Win()
    {
        Debug.Log("Player wins!");
        gameWinText.gameObject.SetActive(true);
    }

    private void TakeDamage(float damage)
    {
        maxHealth -= damage;
        healthBar.SetHealth(maxHealth);
        if (maxHealth <= 0)
        {
            Debug.Log("Game Over");
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
    }

    private void StartFlashing()
    {
        if (!isFlashing)
        {
            StartCoroutine(FlashCoroutine());
        }
    }

    private IEnumerator FlashCoroutine()
    {
        isFlashing = true;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            // Flash to damage color
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            
            // Flash back to original
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }

        isFlashing = false;
    }
}