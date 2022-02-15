using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.magenta;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.right, 360, fow.ViewRadius);
        Vector3 viewAngleA = Quaternion.AngleAxis(fow.ViewAngle / 2, Vector3.forward) * fow.transform.right;
        Vector3 viewAngleB = Quaternion.AngleAxis(-fow.ViewAngle / 2, Vector3.forward) * fow.transform.right;

        Handles.color = Color.red;
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.ViewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.ViewRadius);

        foreach (Transform visibleTarget in fow.VisibleTargets)
        {
            Handles.color = Color.yellow;
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
    }
}
    