using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CoverFolderManager : MonoBehaviour
{
    public List<Sprite> loadedCovers = new List<Sprite>();
    public Transform contentParent;
    public GameObject coverButtonPrefab;

    public void OpenCoverFolder()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, "Custom_Covers");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        Process.Start(folderPath);
    }
    public void LoadCovers()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, "Custom_Covers");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            return;
        }

        string[] files = Directory.GetFiles(folderPath);

        foreach (string file in files)
        {
            if (file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg"))
            {
                LoadImage(file);
            }
        }
        CreateUI();
    }

    private void LoadImage(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);

        Texture2D texture = new Texture2D(2, 2);

        texture.LoadImage(bytes);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        loadedCovers.Add(sprite);
    }

    private void CreateUI()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Sprite sprite in loadedCovers)
        {
            GameObject button = Instantiate(coverButtonPrefab, contentParent);
            CoverButton coverButton = button.GetComponent<CoverButton>();
            coverButton.Setup(sprite);
        }
    }
}