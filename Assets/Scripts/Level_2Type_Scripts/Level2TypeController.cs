using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2TypeController
{
    public float bgMinX, bgMaxX, bgMinY, bgMaxY;
    public Level2TypeView Level2TypeView;
    public Level2TypeModel Level2TypeModel;
    bool isFirstTouch = false;
    Vector3 touchStart = new Vector3(0f, 0f, -10f);
    public Level2TypeController (Level2TypeModel level2TypeModel , Level2TypeView level2TypeView)
    {
        Level2TypeModel = level2TypeModel;
        Level2TypeView = level2TypeView;

    }

    public void SetUI()
    {
        Level2TypeView.Background.GetComponent<SpriteRenderer>().sprite = Level2TypeModel.backgroundSprite;
        Level2TypeView.ObjectToBeFind.GetComponent<SpriteRenderer>().sprite = Level2TypeModel.objectToBeFindSprite;

    }

    public void SetCameraReference()
    {
        SpriteRenderer bgSprite = Level2TypeView.Background.GetComponent<SpriteRenderer>();
        bgMinX = bgSprite.transform.position.x - bgSprite.bounds.size.x / 2f;
        bgMaxX = bgSprite.transform.position.x + bgSprite.bounds.size.x / 2f;

        bgMinY = bgSprite.transform.position.y - bgSprite.bounds.size.y / 2f;
        bgMaxY = bgSprite.transform.position.y + bgSprite.bounds.size.y / 2f;
    }

    public void ScrollBackground()
    {
         if (Input.GetMouseButtonDown(0))
         {
            touchStart = Level2TypeView.setCamera.ScreenToWorldPoint(Input.mousePosition);

            FindGameObject();
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Level2TypeView.setCamera.ScreenToWorldPoint(Input.mousePosition);
            
            Level2TypeView.setCamera.transform.position = ClampCamera(Level2TypeView.setCamera.transform.position + direction);
        }

     }


    private Vector3 ClampCamera(Vector3 tragetPosition)
    {
        float camHeight = Level2TypeView.setCamera.orthographicSize;
        float camWidth = Level2TypeView.setCamera.orthographicSize * Level2TypeView.setCamera.aspect;

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
    }
}
