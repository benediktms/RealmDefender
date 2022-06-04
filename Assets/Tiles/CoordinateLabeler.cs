using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField]
    Color defaultColor = Color.white;

    [SerializeField]
    Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();

    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();

        DisplayCooridnates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCooridnates();
            UpdateObjectName();
        }

        ColorCoordinates();
        ToggleLables();
    }

    private void DisplayCooridnates()
    {
        float snapSettingsMoveX = UnityEditor.EditorSnapSettings.move.x;
        float snapSettingsMoveZ = UnityEditor.EditorSnapSettings.move.z;

        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / snapSettingsMoveX);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / snapSettingsMoveZ);

        label.text = $"{coordinate.x},{coordinate.y}";
        ColorCoordinates();
    }

    private void ColorCoordinates()
    {
        label.color = waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinate.ToString();
    }

    private void ToggleLables()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            label.enabled = !label.enabled;
        }
    }
}
