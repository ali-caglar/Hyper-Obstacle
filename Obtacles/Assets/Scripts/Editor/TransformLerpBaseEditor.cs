using System.Collections;
using UnityEngine;
using UnityEditor;
using TransformLerp.Base;

namespace Editor
{
    [CustomEditor(typeof(TransformLerpBase), true)]
    public class TransformLerpBaseEditor : UnityEditor.Editor
    {
        protected string _transformValueName = "";

        private SerializedProperty _isActive;
        private SerializedProperty _animationMode;
        private SerializedProperty _animationCurve;
        private SerializedProperty _animationLength;
        private SerializedProperty _startValue;
        private SerializedProperty _endValue;

        private IEnumerator _enumerator;
        private TransformLerpBase _transformLerpBase;

        protected virtual void OnEnable()
        {
            _transformLerpBase = (TransformLerpBase)target;

            _isActive = serializedObject.FindProperty("_isActive");
            _animationMode = serializedObject.FindProperty("_animationMode");
            _animationCurve = serializedObject.FindProperty("_animationCurve");
            _animationLength = serializedObject.FindProperty("_animationLength");
            _startValue = serializedObject.FindProperty("_startValue");
            _endValue = serializedObject.FindProperty("_endValue");

            EditorApplication.update += ExecuteCoroutine;
        }

        private void OnDisable() => EditorApplication.update -= ExecuteCoroutine;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical();
            serializedObject.Update();

            EditorGUILayout.PropertyField(_isActive, new GUIContent("Is Active"));

            if (_isActive.boolValue)
            {
                EditorGUILayout.PropertyField(_animationMode, new GUIContent("Animation Mode"));
                EditorGUILayout.PropertyField(_animationCurve, new GUIContent("Animation Curve"));
                EditorGUILayout.PropertyField(_animationLength, new GUIContent("Duration"));
                DrawTransformData();

                GUILayout.Space(20);

                DrawAnimationButtons();
            }
            else
            {
                _enumerator = null;
            }

            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndVertical();
        }

        private void DrawTransformData()
        {
            EditorGUILayout.PropertyField(_startValue, new GUIContent($"Start {_transformValueName}"));
            DrawTransformButtons(ref _startValue);
            EditorGUILayout.PropertyField(_endValue, new GUIContent($"End {_transformValueName}"));
            DrawTransformButtons(ref _endValue);
        }

        private void DrawTransformButtons(ref SerializedProperty property)
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button($"Get {_transformValueName} From Transform"))
            {
                GetTransformVector(ref property);
            }

            if (GUILayout.Button($"Set Transform {_transformValueName} From Property"))
            {
                SetTransformVector(ref property);
            }

            EditorGUILayout.EndHorizontal();
        }

        private void DrawAnimationButtons()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Start Animation"))
            {
                _enumerator = _transformLerpBase.LerpEnumerator;
            }

            if (GUILayout.Button("Stop/Reset Animation"))
            {
                _enumerator = null;
                SetTransformVector(ref _startValue);
            }

            EditorGUILayout.EndHorizontal();
        }

        protected virtual void GetTransformVector(ref SerializedProperty property)
        {
        }

        protected virtual void SetTransformVector(ref SerializedProperty property)
        {
        }

        private void ExecuteCoroutine() => _enumerator?.MoveNext();
    }
}