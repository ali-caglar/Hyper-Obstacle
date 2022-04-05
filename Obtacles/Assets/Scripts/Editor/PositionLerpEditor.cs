using UnityEditor;
using TransformLerp;

namespace Editor
{
    [CustomEditor(typeof(PositionLerp))]
    public class PositionLerpEditor : TransformLerpBaseEditor
    {
        private PositionLerp _positionLerp;

        protected override void OnEnable()
        {
            base.OnEnable();
            
            _positionLerp = (PositionLerp)target;
            _transformValueName = "Position";
        }

        protected override void GetTransformVector(ref SerializedProperty property)
        {
            property.vector3Value = _positionLerp.transform.localPosition;
        }

        protected override void SetTransformVector(ref SerializedProperty property)
        {
            _positionLerp.transform.localPosition = property.vector3Value;
        }
    }
}