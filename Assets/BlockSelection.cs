using UnityEngine;

public class BlockSelection : MonoBehaviour
{
    public RectTransform selectionBox;
    public Vector2 startPos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(startPos),out RaycastHit hit))
            {
                hit.transform.GetComponent<Block>().alive = 1;
            }
        }
        if (Input.GetMouseButton(0))
        {
            UpdateSelectionBox(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseSelection();
        }
    }
    void ReleaseSelection()
    {
        selectionBox.gameObject.SetActive(false);
        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);
        foreach(Transform t in transform)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(t.position);
            if (screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
            {
                t.GetComponent<Block>().alive = 1;
            }
        }
    }
    void UpdateSelectionBox(Vector2 pos)
    {
        if (!selectionBox.gameObject.activeInHierarchy)
        {
            selectionBox.gameObject.SetActive(true);
        }
        float width = pos.x - startPos.x;
        float height = pos.y - startPos.y;
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = startPos+new Vector2(width/2,height/2);
    }
}
