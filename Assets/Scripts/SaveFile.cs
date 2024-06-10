using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class SaveFile
{
    public SerializedDictionary<string, Vector3> teethPositions = new SerializedDictionary<string, Vector3>();
    public Vector3 cameraPosition;
    public Quaternion cameraRotation;
    public Vector3 modelPosition;
    public Quaternion modelRotation;

    public static SaveFile CreateSaveFile()
    {
        SaveFile saveFile = new SaveFile();
        GameObject model = GameObject.Find("mouth_model");
        for (int i = 0; i < model.transform.childCount - 1; i++)
        {
            if (model.transform.GetChild(i).name != "mouth")
            { 
                var tooth = model.transform.GetChild(i).gameObject;
                saveFile.teethPositions[tooth.name] = tooth.transform.localPosition;
            }
        }

        saveFile.modelPosition = model.transform.position;
        saveFile.modelRotation = model.transform.rotation;
        saveFile.cameraPosition = Camera.main.transform.position;
        saveFile.cameraRotation = Camera.main.transform.rotation;
        return saveFile;
    }

    public static void LoadFromSaveFile(SaveFile saveFile)
    {
        GameObject model = GameObject.Find("mouth_model");
        for (int i = 0; i < model.transform.childCount - 1; i++)
        {
            if (model.transform.GetChild(i).name != "mouth")
            {
                var tooth = model.transform.GetChild(i).gameObject;
                tooth.transform.localPosition = saveFile.teethPositions[tooth.name];
            }
        }

        Camera.main.transform.position = saveFile.cameraPosition;
        Camera.main.transform.rotation = saveFile.cameraRotation;
        model.transform.position = saveFile.modelPosition;
        model.transform.rotation = saveFile.modelRotation;
    }

    public static void Save(SaveFile saveFile, string path)
    {
        string json = JsonUtility.ToJson(saveFile);
        System.IO.File.WriteAllText(path, json);
    }

    public static SaveFile Load(string path)
    {
        string json = System.IO.File.ReadAllText(path);
        return JsonUtility.FromJson<SaveFile>(json);
    }
}
