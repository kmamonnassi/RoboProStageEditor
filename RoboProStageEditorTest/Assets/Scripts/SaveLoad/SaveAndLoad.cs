using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UnityEngine;

using Button = UnityEngine.UI.Button;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private BlockInstantiater blockInstatiater;

    public event Action<StageData> OnLoad;

    private void Start()
    {
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
    }

    public void Save()
    {
        OpenFileDialog open_file_dialog = new OpenFileDialog();

        //csvファイルを開くことを指定する
        open_file_dialog.Filter = "jsonファイル|*.json";

        //ファイルが実在しない場合は警告を出す(true)、警告を出さない(false)
        open_file_dialog.CheckFileExists = false;

        //ダイアログを開く
        open_file_dialog.ShowDialog();

        if (string.IsNullOrEmpty(open_file_dialog.FileName)) return;

        string json = JsonUtility.ToJson(blockInstatiater.StageData);
        using (StreamWriter writer = new StreamWriter(open_file_dialog.FileName, false, Encoding.UTF8))
        {
            writer.Write(json);
        }
        Debug.Log(json);
    }

    public void Load()
    {
        OpenFileDialog open_file_dialog = new OpenFileDialog();

        //csvファイルを開くことを指定する
        open_file_dialog.Filter = "jsonファイル|*.json";

        //ファイルが実在しない場合は警告を出す(true)、警告を出さない(false)
        open_file_dialog.CheckFileExists = false;

        //ダイアログを開く
        open_file_dialog.ShowDialog();

        if (string.IsNullOrEmpty(open_file_dialog.FileName)) return;

        string json = null;
        using (StreamReader reader = new StreamReader(open_file_dialog.FileName))
        {
            json = reader.ReadToEnd();
        }

        var data = JsonUtility.FromJson<StageData>(json);
        OnLoad?.Invoke(data);
    }
}
