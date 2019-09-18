using UnityEngine;

namespace GameJuice
{
    /// <summary>
    /// Base class for easing functions, which define how a value changes over time 
    /// </summary>
    public abstract class EasingFunction : ScriptableObject, IEvaluate
    {
        public abstract float Evaluate(float x);
    }
}
