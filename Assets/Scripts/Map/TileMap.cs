using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    
    [SerializeField] private int m_sideSize;
    [SerializeField] private Tile m_tile;
    [SerializeField] private float m_tileScale;
    private List<List<Tile>> m_tiles;

    [SerializeField] private TileVillage m_tileVillage;
    [SerializeField] private TileBeaverCamp m_tileBeaverCamp;
    [SerializeField] private TileRiver m_tileVerticalRiver, m_tileHorizonalRiver, m_tileUpLeftRiver, m_tileUpRightRiver, m_tileDownLeftRiver, m_tileDownRightRiver;
    [SerializeField] private TileField m_tileField;
    [SerializeField] private TileWood m_tileWood;

    private int m_river;
    private const int LARGE_WOOD_TILES = 5;
    private const int MEDIUM_WOOD_TILES = 3;

    // Start is called before the first frame update
    [SerializeField]
    private void Start()
    {
        m_tileVillage.initializeTile();
        m_tileBeaverCamp.initializeTile();
        m_tileVerticalRiver.initializeTile();
        m_tileHorizonalRiver.initializeTile();
        m_tileUpLeftRiver.initializeTile();
        m_tileUpRightRiver.initializeTile();
        m_tileDownLeftRiver.initializeTile();
        m_tileDownRightRiver.initializeTile();

        //Scale the tile
        m_tile.transform.localScale = new Vector3(m_tileScale, m_tileScale, 1);

        // Get the size of the tile's side
        float spriteSideSize = m_tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x * m_tileScale;
        float offset = spriteSideSize / 2;

        List<List<Tile>> tiles = new List<List<Tile>>();

        for (int row = -1 * m_sideSize / 2; row < m_sideSize / 2; row ++)
        {
            List <Tile> tilesByLine = new List<Tile>();
            for (int column = -1 * m_sideSize / 2; column < m_sideSize / 2; column++)
            {
                Vector3 position = new Vector3(column * spriteSideSize + offset, row * spriteSideSize + offset);
                var tile = Instantiate(m_tile, position, Quaternion.identity);
                tile.transform.parent = parent.transform;
                int indexOfsett = m_sideSize / 2;
                tilesByLine.Add(tile);
            }

            tiles.Add(tilesByLine);
        }
        m_tiles = tiles;
        InitializeMap();
    }

    // Update is called once per frame
    private void InitializeMap()
    {
        DrawVillage();
        DrawRiver();
        DrawRestOfTheMap();
    }

    private void DrawVillage()
    {
        m_tiles[0][7].SwapTile(m_tileVillage);
        m_tiles[0][7].initializeTile();
        m_tiles[7][0].SwapTile(m_tileBeaverCamp); 
        m_tiles[7][0].initializeTile();
    }
    private void DrawRiver()
    {
        int randomRiver = (int)(Random.Range(0, 3.0f));

        switch(randomRiver){
            case 1:
                DrawRiver2();
                m_river = 2;
                break;
            case 2:
                DrawRiver3();
                m_river = 3;
                break;
            default:
                DrawRiver1();
                m_river = 1;
                break;
        }
    }
    private void DrawRestOfTheMap()
    {
        int numberOfField = 6;
        int numberOfWoods = 17;
        while(numberOfField > 0 || numberOfWoods > 0)
        {
            for (int row = 0; row < m_tiles.Count; row++)
            {
                for (int column = 0; column < m_tiles[row].Count; column++)
                {
                    int purcentageOfApparition = (int)(Random.Range(0, 101.0f));

                    if (purcentageOfApparition <= 13)
                    {
                        if (numberOfField > 0)
                        {
                            numberOfField -= DrawField(row, column);
                        }
                    }
                    else if (purcentageOfApparition > 13 && purcentageOfApparition <= 36)
                    {
                        if (numberOfWoods > 0)
                        {
                            numberOfWoods -= DrawWood(row, column);
                        }
                    }

                }
            }
        }
    }

    private int DrawWood(int i, int j)
    {
        int woodsSpawned = 0;
        int purcentageOfApparition = (int)(Random.Range(0, 101.0f));
        if(purcentageOfApparition <= 33)
        {
            m_tileWood.initializeTile(false);
            if(i >= 0 && i < m_sideSize && j >= 0 && j < m_sideSize)
            {
                if (!m_tiles[i][j].IsUsed())
                {
                    m_tiles[i][j].SwapTile(m_tileWood);
                    m_tiles[i][j].initializeTile();
                    woodsSpawned++;
                }
            }
            
            if(i >= 0 && i < m_sideSize && j + 1 >= 0 && j + 1 < m_sideSize)
            {
                if (!m_tiles[i][j + 1].IsUsed())
                {
                    m_tiles[i][j + 1].SwapTile(m_tileWood);
                    m_tiles[i][j + 1].initializeTile();
                    woodsSpawned++;
                }
            }
            
            if(i >= 0 && i < m_sideSize && j + 2 >= 0 && j + 2 < m_sideSize)
            {
                if (!m_tiles[i][j + 2].IsUsed())
                {
                    m_tiles[i][j + 2].SwapTile(m_tileWood);
                    m_tiles[i][j + 2].initializeTile();
                    woodsSpawned++;
                }
            }
            
            if(i - 1 >= 0 && i - 1 < m_sideSize && j + 1 >= 0 && j + 1 < m_sideSize)
            {
                if (!m_tiles[i - 1][j + 1].IsUsed())
                {
                    m_tiles[i - 1][j + 1].SwapTile(m_tileWood);
                    m_tiles[i - 1][j + 1].initializeTile();
                    woodsSpawned++;
                }
            }
            
            if(i - 1 >= 0 && i - 1 < m_sideSize && j + 2 >= 0 && j + 2 < m_sideSize)
            {
                if (!m_tiles[i - 1][j + 2].IsUsed())
                {
                    m_tiles[i - 1][j + 2].SwapTile(m_tileWood);
                    woodsSpawned++;
                }
            }
        }

        else if(purcentageOfApparition >= 33 && purcentageOfApparition <= 66)
        {
            m_tileWood.initializeTile(false);
            if (i >= 0 && i < m_sideSize && j >= 0 && j < m_sideSize)
            {
                if (!m_tiles[i][j].IsUsed())
                {
                    m_tiles[i][j].SwapTile(m_tileWood);
                    m_tiles[i][j].initializeTile();
                    woodsSpawned++;
                }
            }
            
            if(i + 1 >= 0 && i + 1 < m_sideSize && j >= 0 && j < m_sideSize)
            {
                if (!m_tiles[i + 1][j].IsUsed())
                {
                    m_tiles[i + 1][j].SwapTile(m_tileWood);
                    m_tiles[i + 1][j].initializeTile();
                    woodsSpawned++;
                }
            }

            if (i + 1 >= 0 && i + 1 < m_sideSize && j + 1 >= 0 && j + 1 < m_sideSize)
            {
                if (!m_tiles[i + 1][j + 1].IsUsed())
                {
                    m_tiles[i + 1][j + 1].SwapTile(m_tileWood);
                    m_tiles[i + 1][j + 1].initializeTile();
                    woodsSpawned++;
                }
            }
        }

        else
        {
            m_tileWood.initializeTile(true);
            if (!m_tiles[i][j].IsUsed())
            {
                m_tiles[i][j].SwapTile(m_tileWood);
                m_tiles[i][j].initializeTile();
                woodsSpawned++;
            }
        }

        return woodsSpawned;
    }

    private int DrawField(int i, int j)
    {
        int fieldsSpawned = 0;
        int purcentageOfApparition = (int)(Random.Range(0, 101.0f));
        if (purcentageOfApparition <= 33)
        {
            m_tileField.initializeTile(false);
            if (i >= 0 && i < m_sideSize && j >= 0 && j < m_sideSize)
            {
                if (!m_tiles[i][j].IsUsed())
                {
                    m_tiles[i][j].SwapTile(m_tileField);
                    m_tiles[i][j].initializeTile();
                    fieldsSpawned++;
                }
            }

            if (i >= 0 && i < m_sideSize && j + 1 >= 0 && j + 1 < m_sideSize)
            {
                if (!m_tiles[i][j + 1].IsUsed())
                {
                    m_tiles[i][j + 1].SwapTile(m_tileField);
                    m_tiles[i][j + 1].initializeTile();
                    fieldsSpawned++;
                }
            }

            if (i - 1 >= 0 && i - 1 < m_sideSize && j + 1 >= 0 && j + 1 < m_sideSize)
            {
                if (!m_tiles[i - 1][j + 1].IsUsed())
                {
                    m_tiles[i - 1][j + 1].SwapTile(m_tileField);
                    m_tiles[i - 1][j + 1].initializeTile();
                    fieldsSpawned++;
                }
            }
        }

        else if (purcentageOfApparition >= 33 && purcentageOfApparition <= 66)
        {
            m_tileField.initializeTile(false);
            if (i >= 0 && i < m_sideSize && j >= 0 && j < m_sideSize)
            {
                if (!m_tiles[i][j].IsUsed())
                {
                    m_tiles[i][j].SwapTile(m_tileField);
                    m_tiles[i][j].initializeTile();
                    fieldsSpawned++;
                }
            }

            if (i + 1 >= 0 && i + 1 < m_sideSize && j >= 0 && j < m_sideSize)
            {
                if (!m_tiles[i + 1][j].IsUsed())
                {
                    m_tiles[i + 1][j].SwapTile(m_tileField);
                    m_tiles[i + 1][j].initializeTile();
                    fieldsSpawned++;
                }
            }
        }

        else
        {
            m_tileField.initializeTile(true);
            if (!m_tiles[i][j].IsUsed())
            {
                m_tiles[i][j].SwapTile(m_tileField);
                m_tiles[i][j].initializeTile();
                fieldsSpawned++;
            }
        }

        return fieldsSpawned;
    }

    private void DrawRiver1()
    {
        m_tiles[7][1].SwapTile(m_tileVerticalRiver);
        m_tiles[6][1].SwapTile(m_tileVerticalRiver);
        m_tiles[5][1].SwapTile(m_tileUpRightRiver);
        m_tiles[5][2].SwapTile(m_tileHorizonalRiver);
        m_tiles[5][3].SwapTile(m_tileHorizonalRiver);
        m_tiles[5][4].SwapTile(m_tileDownLeftRiver);
        m_tiles[4][4].SwapTile(m_tileVerticalRiver);
        m_tiles[3][4].SwapTile(m_tileVerticalRiver);
        m_tiles[2][4].SwapTile(m_tileVerticalRiver);
        m_tiles[1][4].SwapTile(m_tileUpRightRiver);
        m_tiles[1][5].SwapTile(m_tileHorizonalRiver);
        m_tiles[1][6].SwapTile(m_tileHorizonalRiver);
        m_tiles[1][7].SwapTile(m_tileHorizonalRiver);

        m_tiles[7][1].initializeTile();
        m_tiles[6][1].initializeTile();
        m_tiles[5][1].initializeTile();
        m_tiles[5][2].initializeTile();
        m_tiles[5][3].initializeTile();
        m_tiles[5][4].initializeTile();
        m_tiles[4][4].initializeTile();
        m_tiles[3][4].initializeTile();
        m_tiles[2][4].initializeTile();
        m_tiles[1][4].initializeTile();
        m_tiles[1][5].initializeTile();
        m_tiles[1][6].initializeTile();
        m_tiles[1][7].initializeTile();
    }

    private void DrawRiver2()
    {
        m_tiles[6][0].SwapTile(m_tileHorizonalRiver);
        m_tiles[6][1].SwapTile(m_tileHorizonalRiver);
        m_tiles[6][2].SwapTile(m_tileDownLeftRiver);
        m_tiles[5][2].SwapTile(m_tileVerticalRiver);
        m_tiles[4][2].SwapTile(m_tileVerticalRiver);
        m_tiles[3][2].SwapTile(m_tileUpLeftRiver);
        m_tiles[3][1].SwapTile(m_tileDownRightRiver);
        m_tiles[2][1].SwapTile(m_tileVerticalRiver);
        m_tiles[1][1].SwapTile(m_tileUpRightRiver);
        m_tiles[1][2].SwapTile(m_tileHorizonalRiver);
        m_tiles[1][3].SwapTile(m_tileHorizonalRiver);
        m_tiles[1][4].SwapTile(m_tileUpLeftRiver);
        m_tiles[2][4].SwapTile(m_tileDownRightRiver);
        m_tiles[2][5].SwapTile(m_tileHorizonalRiver);
        m_tiles[2][6].SwapTile(m_tileDownLeftRiver);
        m_tiles[1][6].SwapTile(m_tileUpRightRiver);
        m_tiles[1][7].SwapTile(m_tileHorizonalRiver);

        m_tiles[6][0].initializeTile();
        m_tiles[6][1].initializeTile();
        m_tiles[6][2].initializeTile();
        m_tiles[5][2].initializeTile();
        m_tiles[4][2].initializeTile();
        m_tiles[3][2].initializeTile();
        m_tiles[3][1].initializeTile();
        m_tiles[2][1].initializeTile();
        m_tiles[1][1].initializeTile();
        m_tiles[1][2].initializeTile();
        m_tiles[1][3].initializeTile();
        m_tiles[1][4].initializeTile();
        m_tiles[2][4].initializeTile();
        m_tiles[2][5].initializeTile();
        m_tiles[2][6].initializeTile();
        m_tiles[1][6].initializeTile();
        m_tiles[1][7].initializeTile();
    }

    private void DrawRiver3()
    {
        m_tiles[7][1].SwapTile(m_tileVerticalRiver);
        m_tiles[6][1].SwapTile(m_tileVerticalRiver);
        m_tiles[5][1].SwapTile(m_tileUpRightRiver);
        m_tiles[5][2].SwapTile(m_tileHorizonalRiver);
        m_tiles[5][3].SwapTile(m_tileUpLeftRiver);
        m_tiles[6][3].SwapTile(m_tileDownRightRiver);
        m_tiles[6][4].SwapTile(m_tileHorizonalRiver);
        m_tiles[6][5].SwapTile(m_tileDownLeftRiver);
        m_tiles[5][5].SwapTile(m_tileVerticalRiver);
        m_tiles[4][5].SwapTile(m_tileUpLeftRiver);
        m_tiles[4][4].SwapTile(m_tileHorizonalRiver);
        m_tiles[4][3].SwapTile(m_tileDownRightRiver);
        m_tiles[3][3].SwapTile(m_tileVerticalRiver);
        m_tiles[2][3].SwapTile(m_tileUpRightRiver);
        m_tiles[2][4].SwapTile(m_tileHorizonalRiver);
        m_tiles[2][5].SwapTile(m_tileHorizonalRiver);
        m_tiles[2][6].SwapTile(m_tileDownLeftRiver);
        m_tiles[1][6].SwapTile(m_tileUpRightRiver);
        m_tiles[1][7].SwapTile(m_tileHorizonalRiver);

        m_tiles[7][1].initializeTile();
        m_tiles[6][1].initializeTile();
        m_tiles[5][1].initializeTile();
        m_tiles[5][2].initializeTile();
        m_tiles[5][3].initializeTile();
        m_tiles[6][3].initializeTile();
        m_tiles[6][4].initializeTile();
        m_tiles[6][5].initializeTile();
        m_tiles[5][5].initializeTile();
        m_tiles[4][5].initializeTile();
        m_tiles[4][4].initializeTile();
        m_tiles[4][3].initializeTile();
        m_tiles[3][3].initializeTile();
        m_tiles[2][3].initializeTile();
        m_tiles[2][4].initializeTile();
        m_tiles[2][5].initializeTile();
        m_tiles[2][6].initializeTile();
        m_tiles[1][6].initializeTile();
        m_tiles[1][7].initializeTile();
    }
}
