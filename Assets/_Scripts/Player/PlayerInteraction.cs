using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;

    private Land selectedLand = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            OnInteractableHit(hit);
        }
    }

    private void OnInteractableHit(RaycastHit hit)
    {
        Collider collider = hit.collider;

        if (collider.tag == "Land")
        {
            Land land = collider.GetComponent<Land>();
            SelectLand(land);
            return;
        }

        if (selectedLand != null)
        {
            selectedLand.SelectLand(false);
            selectedLand = null;
        }
    }

    private void SelectLand(Land land)
    {
        if (selectedLand != null)
        {
            selectedLand.SelectLand(false);
        }

        selectedLand = land;
        land.SelectLand(true);
    }

    public void Interact()
    {
        if (selectedLand != null)
        {
            selectedLand.Interact();
        }
        else
        {
            Debug.Log("Not on any land");
        }
    }
}
