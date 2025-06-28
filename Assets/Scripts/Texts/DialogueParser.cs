using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    public string character;
    public string script;
}

[System.Serializable]
public class DialogueEntryArray
{
    public DialogueEntry[] entries;
}

public class DialogueParser
{
    private static string[] characters, scripts;

    public static void LoadFromResources(string resourcePath)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(resourcePath);
        if (jsonFile == null)
        {
            Debug.LogError($"Arquivo JSON não encontrado em Resources/{resourcePath}.json");
            return;
        }

        DialogueEntryArray data = JsonUtility.FromJson<DialogueEntryArray>(jsonFile.text);

        int length = data.entries.Length;
        characters = new string[length];
        scripts = new string[length];

        for (int i = 0; i < length; i++)
        {
            characters[i] = data.entries[i].character;
            scripts[i] = data.entries[i].script;

            if (characters[i] != "")
                characters[i] = characters[i].ToUpper() + ": ";
        }
    }

    public static string[] GetCharacters()
    {
        return characters;
    }

    public static string[] GetScripts()
    {
        return scripts;
    }
}
