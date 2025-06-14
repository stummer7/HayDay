using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject groundCellPrefab;

    private GroundCell[,] grid;

    void Start()
    {
        grid = new GroundCell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x, 0, z);
                GameObject obj = Instantiate(groundCellPrefab, pos, Quaternion.identity, transform);
                obj.name = $"Cell_{x}_{z}";
                obj.layer = 3; //Ground Layer important for player movement

                GroundCell cell = obj.GetComponent<GroundCell>();
                cell.Init(x, z);
                grid[x, z] = cell;

                //Debug.Log($"Spawned cell at {x},{z} — has collider: {obj.GetComponent<Collider>() != null}");
            }
        }
    }

    public void ChangeCellAt(Vector3 worldPos, GroundType newType)
    {
        int x = Mathf.RoundToInt(worldPos.x);
        int z = Mathf.RoundToInt(worldPos.z);

        if (x < 0 || x >= width || z < 0 || z >= height) return;


        grid[x, z].SetGroundType(newType);
    }

    public GroundType getGroundTypeOfCell(Vector3 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int z = Mathf.RoundToInt(pos.z);


        if (x < 0 || x >= width || z < 0 || z >= height) return GroundType.Grass;
        return grid[x, z].GetGroundType();
    }
}