using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public bool acceptAction = true;
    protected string m_type;
    protected int m_wood;
    protected int m_food;
    protected bool m_isWater;
    protected bool m_isHumanVillage;
    protected bool m_isBeaverCamp;
    [SerializeField] protected Sprite m_sprite;
    [SerializeField] private GameObject m_highlight;
    [SerializeField] private GameObject m_action_choice_maker;
    
    public GameObject day_manager;
    //public GameObject map_action_selector;

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

    public bool isBeaverCamp()
    {
        return m_isBeaverCamp;
    }

    public bool isHumanVillage()
    {
        return m_isHumanVillage;
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
        m_isBeaverCamp = tile.isBeaverCamp();
        m_isHumanVillage = tile.isHumanVillage();
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
        if(EventSystem.current.IsPointerOverGameObject()||!acceptAction || this.m_type == null || this.m_type == "water" || this.m_type == "beaver camp") return;
        
        this.m_action_choice_maker.SetActive(true);
        this.m_action_choice_maker.transform.Find("actions_status_texts").GetComponent<Choices_Panel>().setAllChoices(m_type);
        TileSpamController.instance.tmpReference = this;
        // QueueAction queue = this.day_manager.GetComponent<DayManager>().getQueue();
        // Action action = new Action(m_wood, m_food, m_type);
        // queue.addActionToQueue(action);
    }

    public void UpdateColorBalance()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color=acceptAction?Color.white:Color.red;
    }

    private void OnEnable()
    {
        // if (!TurnStartFlag.instance.flag) return;
        acceptAction = true;
        UpdateColorBalance();
    }
}
