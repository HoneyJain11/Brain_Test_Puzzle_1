

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Level2TypeView : MonoBehaviour
{
    [SerializeField]
    Level2TypeView level2TypeView;
    [SerializeField]
    GameObject background;
    [SerializeField]
    GameObject objectToBeFind;
    public GameObject ObjectToBeFind { get => objectToBeFind; set => objectToBeFind = value; }
    public GameObject Background { get => background; set => background = value; }
    public Camera setCamera;

    public Level2TypeController level2TypeController;
    public Level2TypeScriptableObjectList level2TypeSOList;

    private Rect safeArea;
    delegate void safeAreaChanged(Rect safeArea);
    static event safeAreaChanged OnSafeAreaChanged;

    private void Awake()
    {
        safeArea = Screen.safeArea;
    }
    private void Start()
    {
        level2TypeController = CreateLevel2Type();
        level2TypeController.SetUI();
        level2TypeController.SetCameraReference();
    }

    public Level2TypeController CreateLevel2Type()
    {
        Level2TypeScriptableObjects level2TypeSO = level2TypeSOList.Level2TypeList[0];
        Level2TypeModel level2TypeModel = new Level2TypeModel(level2TypeSO);
        Level2TypeController level2Type = new Level2TypeController(level2TypeModel, level2TypeView);
        return level2Type;
    }

    private void Update()
    {
        level2TypeController.ScrollBackground();

        if(safeArea != Screen.safeArea)
        {
            safeArea = Screen.safeArea;
            OnSafeAreaChanged?.Invoke(safeArea);
        }
    }
}
