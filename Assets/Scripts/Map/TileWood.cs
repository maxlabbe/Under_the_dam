using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWood : Tile
{
    [SerializeField] Sprite m_bigWood, m_littleWood;
    public void initializeTile(bool isBigWood)
    {
        if(!m_isUsed)
        {
            if (isBigWood)
            {
                m_sprite = m_bigWood;
                gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;

                m_type = "big_wood";
                m_food = 0;
                m_wood = 10;
                m_isBeaverCamp = false;
                m_isHumanVillage = false;
                m_isWater = false;
            }

            else
            {
                m_sprite = m_littleWood;
                gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;

                m_type = "wood";
                m_food = 0;
                m_wood = 4;
                m_isBeaverCamp = false;
                m_isHumanVillage = false;
                m_isWater = false;
            }
        }
    }
}
