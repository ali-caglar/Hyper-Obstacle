using System.Collections;
using UnityEngine;
using TransformLerp.Base;

namespace TransformLerp
{
    public class PositionLerp : TransformLerpBase
    {
        protected override IEnumerator Lerp()
        {
            float timeElapsed = 0;

            while (true)
            {
                timeElapsed += Time.deltaTime;
                float interpolationValue = _animationCurve.Evaluate(timeElapsed / _animationLength);

                _transform.localPosition =
                    Vector3.Lerp(_startValue, _endValue, interpolationValue);

                if (!_continuousAnimation && timeElapsed > _animationLength)
                {
                    break;
                }

                yield return null;
            }

            _transform.localPosition = _endValue;
        }
    }
}