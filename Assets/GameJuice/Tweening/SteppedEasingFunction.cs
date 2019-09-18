using UnityEngine;

namespace GameJuice
{
    /// <summary>
    /// Easing function that moves in discrete steps
    /// </summary>
    [CreateAssetMenu(menuName = "Easing function/Stepped")]
    public class SteppedEasingFunction : EasingFunction
    {
        [SerializeField] private int Steps = 10;
        public override float Evaluate(float x)
        {
            return Mathf.Round(x * Steps) / (Steps * 1f);
        }
    }
}
