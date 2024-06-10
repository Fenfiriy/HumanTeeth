using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveButton()
    {
        SaveFile saveFile = SaveFile.CreateSaveFile();
        SaveFile.Save(saveFile, Application.persistentDataPath + "/save.json");
    }
    public void LoadButton()
    {
        SaveFile saveFile = SaveFile.Load(Application.persistentDataPath + "/save.json");
        SaveFile.LoadFromSaveFile(saveFile);
    }
}
