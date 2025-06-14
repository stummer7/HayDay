using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        Soil, Farmland, Watered
    }
    [SerializeField] Material soilMat, farmMat, wateredMat;
    [SerializeField] private GameObject selector;
    public LandStatus landStatus;
    private new Renderer renderer;



    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Soil);

        selector.SetActive(false);
    }


    public void SwitchLandStatus(LandStatus status)
    {
        landStatus = status;
        Material materialToSwitch = soilMat;

        switch (landStatus)
        {
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                materialToSwitch = farmMat;
                break;
            case LandStatus.Watered:
                materialToSwitch = wateredMat;
                break;
        }

        renderer.material = materialToSwitch;
    }

    public void SelectLand(bool toggleSelect)
    {
        selector.SetActive(toggleSelect);
    }

    public void Interact()
    {
        SwitchLandStatus(LandStatus.Farmland);
    }
}
