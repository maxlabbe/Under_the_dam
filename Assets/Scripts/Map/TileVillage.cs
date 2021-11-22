using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileVillage : Tile
{
    public override void initializeTile()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;

        m_food = 0;
        m_wood = 0;
        m_isWater = false;
    }
}
