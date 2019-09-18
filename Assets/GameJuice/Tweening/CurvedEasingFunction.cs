using UnityEngine;

namespace GameJuice
{
    /// <summary>
    /// Easing function defined by a curve
    /// </summary>
    [CreateAssetMenu(menuName = "Easing function/Curved")]
    public class CurvedEasingFunction : EasingFunction
    {
        [SerializeField] private AnimationCurve FunctionCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        public override float Evaluate(float x) => FunctionCurve.Evaluate(x);
    }
}
