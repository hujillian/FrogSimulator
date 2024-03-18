using UnityEngine;
using UnityEngine.UI;

public class AimSelector : MonoBehaviour
{
    public Image radialTimer;
    public float selectionTime;
    public float maxDistance;

    private float currentSelectionTime;
    private GameObject gazedAtObject;

    private bool isSelecting;

    public int score = 0;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance) && hit.transform.CompareTag("Bug"))
        {
            
            if (gazedAtObject != hit.transform.gameObject)
            {
                gazedAtObject?.SendMessage("OnPointerExit");
                gazedAtObject = hit.transform.gameObject;
                gazedAtObject.SendMessage("OnPointerEnter");
                StartSelecting();
                Debug.Log("HIT BUG");
            }
        }
        else
        {
            gazedAtObject?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
            gazedAtObject = null;
            StopSelecting();
        }

        if (isSelecting)
        {
            currentSelectionTime += Time.deltaTime;
            if (currentSelectionTime >= selectionTime)
            {
                gazedAtObject?.SendMessage("OnPointerClick");
                gazedAtObject.SetActive(false);
                score += 1;
                currentSelectionTime = 0;
            }

            UpdateUI();
        }
        else
        {
            IdleMode();
        }
    }

    public void StartSelecting()
    {
        currentSelectionTime = 0;
        UpdateUI();
        radialTimer.enabled = true;
        isSelecting = true;
    }

    public void IdleMode()
    {
        currentSelectionTime = selectionTime;
        UpdateUI();
    }

    private void UpdateUI()
    {
        radialTimer.fillAmount = Mathf.InverseLerp(0, selectionTime, currentSelectionTime);
    }

    public void StopSelecting()
    {
        radialTimer.enabled = false;
        isSelecting = false;
    }
}
