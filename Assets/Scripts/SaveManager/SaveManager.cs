using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Itens;

public class SaveManager : Singleton<SaveManager>
{
    private SaveSetup _saveSetup;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 2;
        _saveSetup.playerName = "Test";
    }


    #region SAVE
    private void Save()
    {
        SaveSetup setup = new SaveSetup();
        setup.lastLevel = 2;
        setup.playerName = "Test";

        string setupToJson = JsonUtility.ToJson(setup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }

    public void SaveItems()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soint.value;
        _saveSetup.health = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soint.value;
        Save();

    }

    public void SaveName(string text)
    {
        _saveSetup.playerName = text;
        Save();
    }

    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel = level;
        SaveItems();
        Save();
    }
    #endregion


    private void SaveFile(string json)
    {
        string path = Application.streamingAssetsPath + "/save.txt";

        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }

    private void SaveLevelFive()
    {
        SaveLastLevel(5);
    }
}

[System.Serializable]
public class SaveSetup 
{
    public int lastLevel;
    public float coins;
    public float health;

    public string playerName;
}