using UnityEngine;

public enum GroundType { Grass, Soil, Water }

public class GroundCell : MonoBehaviour
{
    public Material grassMat;
    public Material soilMat;
    public Material waterMat;

    private new MeshRenderer renderer;
    private int x, z;

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void Init(int x, int z)
    {
        this.x = x;
        this.z = z;
        SetGroundType(GroundType.Grass);
    }

    public void SetGroundType(GroundType type)
    {
        switch (type)
        {
            case GroundType.Grass:
                renderer.material = grassMat;
                break;
            case GroundType.Soil:
                renderer.material = soilMat;
                break;
            case GroundType.Water:
                renderer.material = waterMat;
                break;
        }
    }

    public GroundType GetGroundType()
    {
        Material mat = renderer.sharedMaterial;

        if (mat == soilMat)
        {
            return GroundType.Soil;
        }
        if (mat == waterMat)
        {
            return GroundType.Water;
        }
        return GroundType.Grass;
    }
}