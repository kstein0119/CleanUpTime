using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapController : MonoBehaviour
{

    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;

    private bool isSnapped = false;
    int itemIndex = 0;

    [SerializeField]
    private Text _title;

    // Start is called before the first frame update
    void Start()
    {

        foreach (Draggable draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(Draggable draggable)
    {
        isSnapped = false;
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
            print("Snapped!");

            isSnapped = true;

            if (isSnapped)
            {
                itemIndex = itemIndex + 1;
            }

            _title.text = itemIndex.ToString() + "/6 Toys Cleaned Up";

            // Will update the existing text, but should probably be a bar or something else as I"d need to either
            // add 4 strings to address 0 through 4 items added, or add with an integer and convert to a string
            // also still need to get rid of the game object after it's in the basket 


        }

        
    }
}
