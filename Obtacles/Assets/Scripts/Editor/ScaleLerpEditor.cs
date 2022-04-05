using UnityEditor;
using TransformLerp;

namespace Editor
{
    [CustomEditor(typeof(ScaleLerp))]
    public class ScaleLerpEditor : TransformLerpBaseEditor
    {
        private ScaleLerp _scaleLerp;

        protected override void OnEnable()
        {
            base.OnEnable();

            _scaleLerp = (ScaleLerp)target;
            _transformValueName = "Scale";
        }

        protected override void GetTransformVector(ref SerializedProperty property)
        {
            property.vector3Value = _scaleLerp.transform.localScale;
        }

        protected override void SetTransformVector(ref SerializedProperty property)
        {
            _scaleLerp.transform.localScale = property.vector3Value;
        }
    }
}