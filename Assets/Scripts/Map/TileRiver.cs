using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRiver : Tile
{
    public override void initializeTile()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;

        m_type = "water";
        m_food = 0;
        m_wood = 0;
        m_isBeaverCamp = false;
        m_isHumanVillage = false;
        m_isWater = true;

    }
}
