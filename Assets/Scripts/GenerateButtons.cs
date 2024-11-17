using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using TMPro; 
using System.IO;

public class SceneButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab; 
    public Transform buttonParent; 
    public float buttonSpacing = 30f; 

    private void Start()
    {
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
        string folderPath = "Assets/Scenes/Missions";

        string[] scenes = Directory.GetFiles(folderPath, "*.unity");

        int missionNumber = 1;

        foreach (string scenePath in scenes)
        {
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);

            GameObject newButton = Instantiate(buttonPrefab, buttonParent);

            Text buttonText = newButton.GetComponentInChildren<Text>();
            TMP_Text tmpText = newButton.GetComponentInChildren<TMP_Text>();

            if (buttonText != null)
            {
                buttonText.text = sceneName; 
            }
            else if (tmpText != null)
            {
                tmpText.text = sceneName; 
            }

            Button btn = newButton.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => LoadScene(sceneName)); 
            }

            RectTransform rectTransform = newButton.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -missionNumber * buttonSpacing);

            missionNumber++;
        }
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}