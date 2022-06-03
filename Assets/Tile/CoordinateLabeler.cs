using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCooridnates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCooridnates();
            UpdateObjectName();
        }
    }

    private void DisplayCooridnates()
    {
        float snapSettingsMoveX = UnityEditor.EditorSnapSettings.move.x;
        float snapSettingsMoveZ = UnityEditor.EditorSnapSettings.move.z;

        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / snapSettingsMoveX);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / snapSettingsMoveZ);

        label.text = $"{coordinate.x},{coordinate.y}";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }
}
