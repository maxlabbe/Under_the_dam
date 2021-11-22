using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    protected int m_wood;
    protected int m_food;
    protected bool m_isWater;
    [SerializeField] protected Sprite m_sprite;
    public virtual void initializeTile()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;
    }

    public int GetWood()
    {
        return m_wood;
    }

    public int GetFood()
    {
        return m_food;
    }

    public bool IsWater()
    {
        return m_isWater;
    }

    public Sprite GetSprite()
    {
        return m_sprite;
    }

    public void SwapTile(Tile tile)
    {
        m_wood = tile.GetWood();
        m_food = tile.GetFood();
        m_isWater = tile.IsWater();
        m_sprite = tile.GetSprite();
    }
}
