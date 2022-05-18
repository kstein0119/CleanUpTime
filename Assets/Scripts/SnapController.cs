using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnapController : MonoBehaviour
{

    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;

    private bool isSnapped = false;
    public int itemIndex = 0;

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

            if(itemIndex == 6)
            {                

                Timer myClock = FindObjectOfType<Timer>();
                float stopTime = myClock.getTime();

                print(stopTime);


                if (stopTime < 10.0f)
                {
                    WinGameTimeBonus();

                    //menuManager.WinGameTimeBonus();
                }
                else if(stopTime > 10.0f && stopTime < 30.0f)
                {
                    WinGameNoBonus();

                    //menuManager.WinGameNoBonus();
                }
                else if(stopTime > 30.0f)
                {
                    FailGame();

                    //  menuManager.FailGame();
                }

            }
        }
    }
    public void FailGame()
    {
        SceneManager.LoadScene("FailScene");
    }

    public void WinGameTimeBonus()
    {
        SceneManager.LoadScene("BonusWinScene");
    }

    public void WinGameNoBonus()
    {
        SceneManager.LoadScene("NormalWinScene");
    }
}
