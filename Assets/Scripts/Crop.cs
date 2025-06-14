using UnityEngine;

public class Crop : MonoBehaviour
{
    public GameObject[] growthStages;
    public float timeBetweenStages = 5f;

    private int currentStage = 0;
    private float timer = 0f;
    private bool isGrown = false;

    void Start()
    {
        UpdateStageVisual();
    }

    void Update()
    {
        if (isGrown) return;

        timer += Time.deltaTime;

        if (currentStage < growthStages.Length - 1 && timer >= timeBetweenStages)
        {
            timer = 0f;
            currentStage++;
            UpdateStageVisual();

            if (currentStage == growthStages.Length - 1)
                isGrown = true;
        }
    }

    void UpdateStageVisual()
    {
        for (int i = 0; i < growthStages.Length; i++)
            growthStages[i].SetActive(i == currentStage);
    }

    public bool IsFullyGrown()
    {
        return isGrown;
    }

    public GameObject Harvest()
    {
        if (!IsFullyGrown()) return null;

        Debug.Log("Harvested!");

        // You could also play a harvest animation or particle effect here.
        GameObject value = gameObject;
        Destroy(gameObject); // remove the crop
        return value;
    }
}