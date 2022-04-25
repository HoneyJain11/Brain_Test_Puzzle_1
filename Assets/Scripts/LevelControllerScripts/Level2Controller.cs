using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2Controller : MonoBehaviour
{

    [SerializeField]
    GameObject background;
    [SerializeField]
    GameObject objectToBeFind;
    [SerializeField] TextMeshProUGUI levelNoText;
    [SerializeField] TextMeshProUGUI levelTitleText;
    [SerializeField] Camera cameraReference;
    [SerializeField] GameObject level3Object;
    [SerializeField] GameObject level2Object;
    [SerializeField] string levelName;
    [SerializeField] string levelno;
    float bgMinX, bgMaxX, bgMinY, bgMaxY;
    Vector3 touchStart = new Vector3(0f, 0f, -10f);


    private void Start()
    {
        SetUI();
        SetCameraReference();
    }

    void SetUI()
    {
        levelTitleText.text = levelName;
        levelNoText.text = levelno;
    }

    private void Update()
    {
        ScrollBackground();
    }
    public void SetCameraReference()
    {
        SpriteRenderer bgSprite = background.GetComponent<SpriteRenderer>();
        bgMinX = bgSprite.transform.position.x - bgSprite.bounds.size.x / 2f;
        bgMaxX = bgSprite.transform.position.x + bgSprite.bounds.size.x / 2f;

        bgMinY = bgSprite.transform.position.y - bgSprite.bounds.size.y / 2f;
        bgMaxY = bgSprite.transform.position.y + bgSprite.bounds.size.y / 2f;
    }

    public void ScrollBackground()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = cameraReference.ScreenToWorldPoint(Input.mousePosition);

            FindGameObject();
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - cameraReference.ScreenToWorldPoint(Input.mousePosition);

            cameraReference.transform.position = ClampCamera(cameraReference.transform.position + direction);
        }

    }


    private Vector3 ClampCamera(Vector3 tragetPosition)
    {
        float camHeight = cameraReference.orthographicSize;
        float camWidth = cameraReference.orthographicSize * cameraReference.aspect;

        float minX = bgMinX + camWidth;
        float maxX = bgMaxX - camWidth;
        float minY = bgMinY + camHeight;
        float maxY = bgMaxY - camHeight;

        float newX = Mathf.Clamp(tragetPosition.x, minX, maxX);
        float newy = Mathf.Clamp(tragetPosition.y, minY, maxY);
        return new Vector3(newX, 0f, tragetPosition.z);
    }

    public void FindGameObject()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
        if (hit && hit.collider != null)
        {
            //Debug.Log("Hit with GameObject " + hit.collider.gameObject.name);
            ObjectFound();
        }
    }

    private void ObjectFound()
    {
        Debug.Log("Object Found LevelComplete");
        EventHandler.Instance.InvokeOnCompleteLevel(); 
        levelTitleText.text = "";
        levelNoText.text = "";
    }
}
