using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBeaverCamp : Tile
{
    public override void initializeTile()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;

        m_type = "beaver camp";
        m_food = 0;
        m_wood = 0;
        m_isWater = false;
    }
}
