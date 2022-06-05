using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
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
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLables();
    }

    private void DisplayCooridnates()
    {
        // NOTE: this will cause a build error. Editor settings will have to be moved into the Assets/Editor folder when the game is built.
        var snapSettingsMove = UnityEditor.EditorSnapSettings.move;

        coordinate.x = Mathf.RoundToInt(transform.parent.position.x / snapSettingsMove.x);
        coordinate.y = Mathf.RoundToInt(transform.parent.position.z / snapSettingsMove.z);

        label.text = $"{coordinate.x},{coordinate.y}";
    }

    private void SetLabelColor()
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
