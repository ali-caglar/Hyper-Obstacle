using System.Collections;
using UnityEngine;
using TransformLerp.Base;

namespace TransformLerp
{
    public class RotationLerp : TransformLerpBase
    {
        protected override IEnumerator Lerp()
        {
            float timeElapsed = 0;

            while (true)
            {
                timeElapsed += Time.deltaTime;
                float interpolationValue = _animationCurve.Evaluate(timeElapsed / _animationLength);

                Vector3 targetRotation = Vector3.Lerp(_startValue, _endValue, interpolationValue);
                _transform.localRotation = Quaternion.Euler(targetRotation);

                if (!_continuousAnimation && timeElapsed > _animationLength)
                {
                    break;
                }

                yield return null;
            }

            _transform.localRotation = Quaternion.Euler(_endValue);
        }
    }
}