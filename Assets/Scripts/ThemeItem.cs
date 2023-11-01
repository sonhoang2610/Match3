using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    NORMAL1 = 0,
    NORMAL2,
    NORMAL3,
    NORMAL4,
    NORMAL5,
    NORMAL6,
    NORMAL7,
    BOMB,
    HORIZONTAL,
    VERTICAL
}
public class ThemeItem : MonoBehaviour
{
    public ItemType itemType;
    public SpriteRenderer skin;

    // Start is called before the first frame update
    void Start()
    {
        var currentTheme = ThemeController.Instance.CurrentTheme;
        if(currentTheme != null)
             UpdateTheme(currentTheme);
    }

    private void OnEnable()
    {
        ThemeController.OnChangeTheme += UpdateTheme;
    }

    private void OnDisable()
    {
        ThemeController.OnChangeTheme -= UpdateTheme;
    }

    void UpdateTheme(Theme currentTheme)
    {
        if (currentTheme == null) return;
        if((int)itemType < 7)
        {
            skin.sprite = currentTheme.normalItems[(int)itemType];
        }else if(itemType == ItemType.BOMB)
        {
            skin.sprite = currentTheme.Bomb;
        }
        else if (itemType == ItemType.HORIZONTAL)
        {
            skin.sprite = currentTheme.Horizontal;
        }
        else if (itemType == ItemType.VERTICAL)
        {
            skin.sprite = currentTheme.Vertical;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
