using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Switch : MonoBehaviour
{
    public bool isPresent;
    public float switchAmount = 20.0f;
    public int maxSwitches = 3; // Maximum number of switches allowed
    private int switchesRemaining; // Track remaining switches
    public TMP_Text switchCountText; // Reference to the UI text

    // Start is called before the first frame update
    void Start()
    {
        isPresent = true;
        switchesRemaining = maxSwitches;
        UpdateSwitchDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && switchesRemaining > 0)
        {
            transform.Translate(Vector3.right * (isPresent ? -switchAmount : switchAmount));
            isPresent = !isPresent;
            switchesRemaining--;
            UpdateSwitchDisplay();
            Debug.Log($"Switches remaining: {switchesRemaining}");
        }
    }

    void UpdateSwitchDisplay()
    {
        if (switchCountText != null)
        {
            switchCountText.text = $"Switches Left: {switchesRemaining}";
        }
    }
}
