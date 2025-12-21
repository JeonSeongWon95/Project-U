using System.Collections.Generic;
using UnityEngine;

public class LocalizingManager
{
    private static LocalizingManager instance;
    public static LocalizingManager Instance 
    {
        get 
        {
            if (instance == null) 
            {
                instance = new LocalizingManager();
                instance.LoadingCSVData();
            }

            return instance;
        }
    }

    private Dictionary<string, string>[] locs;
    private ELANGUAGETYPE currnetLanguage;

    [Header("로컬라이징용 CSV 파일 Path 입력. 한글 -> 영어 -> 일본어 -> 중국어 순")]
    [SerializeField] private string[] filepath;

    private void LoadingCSVData() 
    {
        locs = new Dictionary<string, string>[filepath.Length];

        for (int i = 0; i < locs.Length; ++i)
        {
            Dictionary<string, string> loc = new Dictionary<string, string>();

            TextAsset textasset = Resources.Load<TextAsset>(filepath[i]);

            if(textasset == null) 
            {
                Debug.LogError("Can't Find file : " + filepath[i]);
            }

            string[] lines = textasset.text.Split('\n');

            for (int j = 1; j < lines.Length; ++j)
            {
                if (string.IsNullOrEmpty(lines[j]))
                    continue;

                string[] parts = lines[j].Split(",");

                loc.Add(parts[0], parts[1]);
            }

            locs[i] = loc;
        }

    }

    public string FindStringFromDicionary(string key) 
    {
        if (currnetLanguage < ELANGUAGETYPE.KR || currnetLanguage >= ELANGUAGETYPE.MAX)
            return null;

        if (locs == null || locs[(int)currnetLanguage] == null)
            return null;

        if(locs[(int)currnetLanguage].TryGetValue(key, out  string value)) 
        {
            return value;
        }

        return null;
    }
}
