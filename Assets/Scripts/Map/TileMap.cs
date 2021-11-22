using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private int m_sideSize;
    [SerializeField] private Tile m_tile;
    [SerializeField] private float m_tileScale;
    [SerializeField] private TileVillage m_tileVillage;
    [SerializeField] private TileBeaverCamp m_tileBeaverCamp;
    [SerializeField] private TileRiver m_tileVerticalRiver, m_tileHorizonalRiver, m_tileUpLeftRiver, m_tileUpRightRiver, m_tileDownLeftRiver, m_tileDownRightRiver;
    private List<List<Tile>> m_tiles;

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
                break;
            case 2:
                DrawRiver3();
                break;
            default:
                DrawRiver1();
                break;
        }
    }
    private void DrawRestOfTheMap()
    {

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
