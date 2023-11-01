using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeController : MonoBehaviour,ISerializationCallbackReceiver
{
    public Theme[] themeCollection;
    public int defaultTheme;

    public Theme CurrentTheme { get; set; }

    private static ThemeController _instance;
    public static ThemeController Instance => _instance;


    public static System.Action<Theme> OnChangeTheme;

    public InputField inputTheme;

    [ContextMenu("ChangeTheme")]
    public void TestChangeTheme()
    {
        var debugThemeIndex = int.Parse(inputTheme.text);
        if (debugThemeIndex >= themeCollection.Length) return;
        CurrentTheme = themeCollection[debugThemeIndex];
        OnChangeTheme?.Invoke(CurrentTheme);
    }

    public void OnAfterDeserialize()
    {
        _instance = this;
    }

    public void OnBeforeSerialize()
    {
   
    }


    // Start is called before the first frame update
    void Start()
    {
        var indexTheme = PlayerPrefs.GetInt("CurrentTheme", -1);
        if(indexTheme == -1)
        {
            indexTheme = defaultTheme;
        }
        CurrentTheme = themeCollection[indexTheme];
        OnChangeTheme?.Invoke(CurrentTheme);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
