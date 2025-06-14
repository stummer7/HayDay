using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact(RaycastHit hitInfo);
}

public class Interactor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int interactRange = 3;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject inventory;

    private Dictionary<Vector2Int, GameObject> placedItems = new Dictionary<Vector2Int, GameObject>();
    public float cellSize = 1f;



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 origin = playerCamera.transform.position;
            Vector3 direction = playerCamera.transform.forward;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

            HotbarUI hotbar = FindObjectOfType<HotbarUI>();
            if (hotbar == null ) return;

            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                Debug.Log("TEAF: "+hit.collider.name);
                ItemData selectedItem = hotbar.GetSelectedItem();

                if (selectedItem != null)
                {
                    if (selectedItem.ItemName == "Axe")
                    {
                        // Debug.Log("Test: " + gridManager.getGroundTypeOfCell(hit.point));
                        if (gridManager.getGroundTypeOfCell(hit.point) == GroundType.Grass)
                        {
                            //Debug.Log("✅ Hit: " + hit.collider.name);
                            //Debug.Log("Hit point: " + hit.point);
                            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            sphere.transform.position = hit.point;
                            sphere.transform.localScale = Vector3.one * 0.1f;
                            gridManager.ChangeCellAt(hit.point, GroundType.Soil);
                        }
                        else
                        {
                            Debug.Log("Ground already Soil");
                        }
                    }
                    else if (selectedItem.ItemName == "Seed")
                    {
                        if (gridManager.getGroundTypeOfCell(hit.point) == GroundType.Soil)
                        {
                            Vector3 colliderCord = hit.collider.transform.position;

                            int placeX = Mathf.FloorToInt(colliderCord.x + cellSize / 2);
                            int placeZ = Mathf.FloorToInt(colliderCord.z + cellSize / 2);

                            if (placedItems.ContainsKey(new Vector2Int(placeX, placeZ)))
                            {
                                Debug.Log("This cell is already occupied.");
                                return;
                            }

                            Vector3 placePosition = new Vector3(placeX, colliderCord.y, placeZ);

                            Instantiate(selectedItem.GameObject, placePosition, Quaternion.identity);
                            placedItems.Add(new Vector2Int(placeX, placeZ), selectedItem.GameObject);
                        }
                    }
                }

                Debug.Log("TEAF: "+hit.collider.name);

                Crop crop = hit.collider.GetComponent<Crop>();
                if (crop != null && crop.IsFullyGrown())
                {
                    GameObject o = crop.Harvest();
                    Debug.Log("Harvest: " + o);
                    //hotbar.Inventory.AddItem(new ItemData("Carrot",o,Sprite.))
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            inventory.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.SetActive(false);
        }
    }
}
