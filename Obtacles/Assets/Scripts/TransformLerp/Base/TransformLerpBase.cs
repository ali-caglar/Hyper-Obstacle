using System.Collections;
using UnityEngine;

namespace TransformLerp.Base
{
    public abstract class TransformLerpBase : MonoBehaviour
    {
        [Header("Use")]
        [SerializeField] private bool _isActive;

        [Header("Animation Data")]
        [SerializeField] private WrapMode _animationMode;
        [SerializeField] protected AnimationCurve _animationCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] protected float _animationLength = 1f;

        [Header("Transform")]
        [SerializeField] protected Vector3 _startValue;
        [SerializeField] protected Vector3 _endValue;

        protected Transform _transform;
        protected bool _continuousAnimation;

        public IEnumerator LerpEnumerator { get; private set; }

        private void Awake() => Init();
        private void OnValidate() => Init();

        private void Init()
        {
            _transform = this.transform;
            _animationCurve.postWrapMode = _animationMode;
            _continuousAnimation = _animationMode == WrapMode.PingPong || _animationMode == WrapMode.Loop;
            LerpEnumerator = Lerp();
        }

        protected virtual IEnumerator Lerp()
        {
            yield return null;
        }

        public virtual void StartLerp()
        {
            if (_isActive)
            {
                StartCoroutine(LerpEnumerator);
            }
        }

        public virtual void StopLerp()
        {
            StopAllCoroutines();
        }
    }
}