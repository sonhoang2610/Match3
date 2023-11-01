using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer skin;

    public int BoardX { get; private set; }

    public int BoardY { get; private set; }

    public Item Item { get; private set; }

    public Cell NeighbourUp { get; set; }

    public Cell NeighbourRight { get; set; }

    public Cell NeighbourBottom { get; set; }

    public Cell NeighbourLeft { get; set; }

    public Cell[] SurroundCells { get; set; }


    public bool IsEmpty => Item == null;


    
    public void InitSurroundCell()
    {
        SurroundCells = new Cell[] { NeighbourUp, NeighbourRight, NeighbourBottom, NeighbourLeft };
    }
    public void Setup(int cellX, int cellY)
    {
        this.BoardX = cellX;
        this.BoardY = cellY;
    }

    public bool IsNeighbour(Cell other)
    {
        return BoardX == other.BoardX && Mathf.Abs(BoardY - other.BoardY) == 1 ||
            BoardY == other.BoardY && Mathf.Abs(BoardX - other.BoardX) == 1;
    }


    public void Free()
    {
        Item = null;
    }

    public void Assign(Item item)
    {
        Item = item;
        Item.SetCell(this);
    }

    public void ApplyItemPosition(bool withAppearAnimation)
    {
        Item.SetViewPosition(this.transform.position);

        if (withAppearAnimation)
        {
            Item.ShowAppearAnimation();
        }
    }

    internal void Clear()
    {
        if (Item != null)
        {
            Item.Clear();
            Item = null;
        }
    }

    internal bool IsSameType(Cell other)
    {
        return Item != null && other.Item != null && Item.IsSameType(other.Item);
    }

    internal void ExplodeItem()
    {
        if (Item == null) return;

        Item.ExplodeView();
        Item = null;
    }

    internal void AnimateItemForHint()
    {
        Item.AnimateForHint();
    }

    internal void StopHintAnimation()
    {
        Item.StopAnimateForHint();
    }

    internal void ApplyItemMoveToPosition()
    {
        Item.AnimationMoveToPosition();
    }


    // Start is called before the first frame update
    void Start()
    {
        var currentTheme = ThemeController.Instance.CurrentTheme;
        if (currentTheme != null)
            UpdateTheme(currentTheme);

       
    }

    private void OnEnable()
    {
        ThemeController.OnChangeTheme += UpdateTheme;
    }


    void UpdateTheme(Theme currentTheme)
    {
        if (currentTheme == null) return;
        skin.sprite = currentTheme.backGroundCell;
    }

    private void OnDisable()
    {
        ThemeController.OnChangeTheme -= UpdateTheme;
    }
}
