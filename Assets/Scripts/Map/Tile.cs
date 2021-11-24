using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    protected string m_type;
    protected int m_wood;
    protected int m_food;
    protected bool m_isWater;
    [SerializeField] protected Sprite m_sprite;
    [SerializeField] private GameObject m_highlight;
    
    public GameObject day_manager;
    public GameObject map_action_selector;

    protected bool m_isUsed = false;
    public virtual void initializeTile()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;
        m_highlight.SetActive(false);
        m_isUsed = true;
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

    public string GetTileType()
    {
        return m_type;
    }

    public bool IsUsed()
    {
        return m_isUsed;
    }

    public void SwapTile(Tile tile)
    {
        m_wood = tile.GetWood();
        m_food = tile.GetFood();
        m_isWater = tile.IsWater();
        m_sprite = tile.GetSprite();
        m_type = tile.GetTileType();
    }


    public void OnMouseEnter()
    {
        m_highlight.SetActive(true);
    }

    public void OnMouseExit()
    {
        m_highlight.SetActive(false);
    }

    public void OnMouseDown()
    {
        QueueAction queue = this.day_manager.GetComponent<DayManager>().getQueue();
        Action a = new Action();
        queue.addActionToQueue(a);
    }
}
