#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pivotObject;

    public float sensitivity;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, pivotObject.position, sensitivity);
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(CameraMovement))]
    public class CameraMovementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Set Pivot Object to Local Position"))
            {
                ((CameraMovement)target).SetPivotObjectToLocalPosition();
            }
        }
    }
#endif

    public void SetPivotObjectToLocalPosition()
    {
        pivotObject.position = transform.localPosition;
    }
}
