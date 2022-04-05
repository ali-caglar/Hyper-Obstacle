using UnityEngine;
using UnityEditor;
using TransformLerp;

namespace Editor
{
    [CustomEditor(typeof(RotationLerp))]
    public class RotationLerpEditor : TransformLerpBaseEditor
    {
        private RotationLerp _rotationLerp;

        protected override void OnEnable()
        {
            base.OnEnable();

            _rotationLerp = (RotationLerp)target;
            _transformValueName = "Rotation";
        }

        protected override void GetTransformVector(ref SerializedProperty property)
        {
            property.vector3Value = _rotationLerp.transform.localRotation.eulerAngles;
        }

        protected override void SetTransformVector(ref SerializedProperty property)
        {
            _rotationLerp.transform.localRotation = Quaternion.Euler(property.vector3Value);
        }
    }
}