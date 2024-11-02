using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // For standard Text
using TMPro; // For TextMeshPro
using System.IO;

public class SceneButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab; // Drag your Button prefab here in the Inspector
    public Transform buttonParent;  // The parent object (Panel) to hold the buttons
    public float buttonSpacing = 30f; // Space between buttons

    private void Start()
    {
        // Check if the prefab or parent is missing
        if (buttonPrefab == null)
        {
            Debug.LogError("Button Prefab is not assigned!");
            return;
        }

        if (buttonParent == null)
        {
            Debug.LogError("Button Parent (Panel) is not assigned!");
            return;
        }

        GenerateSceneButtons();
    }

    void GenerateSceneButtons()
    {
        // Folder where your scenes are located
        string folderPath = "Assets/Scenes/Missions";

        // Get all files in the folder
        string[] scenes = Directory.GetFiles(folderPath, "*.unity");

        int missionNumber = 1;

        foreach (string scenePath in scenes)
        {
            // Extract scene name from the file path
            string sceneName = Path.GetFileNameWithoutExtension(scenePath); // e.g., "Mission 1"

            // Create a new button
            GameObject newButton = Instantiate(buttonPrefab, buttonParent);

            // Check if the button uses standard UI Text or TextMeshPro
            Text buttonText = newButton.GetComponentInChildren<Text>();
            TMP_Text tmpText = newButton.GetComponentInChildren<TMP_Text>();

            if (buttonText != null)
            {
                // Set the button text for standard UI Text
                buttonText.text = sceneName; // Use sceneName to set the button text
            }
            else if (tmpText != null)
            {
                // Set the button text for TextMeshPro
                tmpText.text = sceneName; // Use sceneName to set the button text
            }

            // Add listener to load the scene when the button is clicked
            Button btn = newButton.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => LoadScene(sceneName)); // Load the corresponding scene
            }

            // Position the button
            RectTransform rectTransform = newButton.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -missionNumber * buttonSpacing);

            missionNumber++;
        }
    }

    // Method to load the selected scene
    void LoadScene(string sceneName)
    {
        // Load the scene based on the scene name
        SceneManager.LoadScene(sceneName);
    }
}
