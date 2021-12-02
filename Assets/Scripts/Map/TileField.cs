using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileField : Tile
{
    [SerializeField] Sprite m_bigField, m_littleField;
    public void initializeTile(bool isBigField)
    {
        if(!m_isUsed)
        {

            if (isBigField)
            {
                m_sprite = m_bigField;
                gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;

                m_type = "big_field";
                m_food = 10;
                m_wood = 0;
                m_isBeaverCamp = false;
                m_isHumanVillage = false;
                m_isWater = false;
            }

            else
            {
                m_sprite = m_littleField; ;
                gameObject.GetComponent<SpriteRenderer>().sprite = m_sprite;

                m_type = "field";
                m_food = 4;
                m_wood = 0;
                m_isBeaverCamp = false;
                m_isHumanVillage = false;
                m_isWater = false;
            }
        }
    }
}
