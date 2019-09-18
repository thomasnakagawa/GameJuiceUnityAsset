using System.Collections;
using UnityEngine;

namespace GameJuice {
    /// <summary>
    /// Provides Enumerators to run in coroutines for tweening between values
    /// </summary>
    public static class Tween
    {
        /// <summary>
        /// Tween between two float values
        /// </summary>
        /// <param name="startValue">Value to start tweening from</param>
        /// <param name="endValue">Value to end tweening to</param>
        /// <param name="duration">Amount of time between the start and end value</param>
        /// <param name="easingFunction">Function that maps float[0-1]=>float[0-1] that defines the curve of the tween</param>
        /// <param name="onFrame">Action to run at every frame of the tween, passing a tweened float</param>
        /// <returns>Enumerator that will call onFrame on every frame of the tween</returns>
        public static IEnumerator Float(float startValue, float endValue, float duration, System.Func<float, float> easingFunction, System.Action<float> onFrame) =>
            Generic(startValue, endValue, duration, easingFunction, onFrame, Mathf.LerpUnclamped);

        /// <summary>
        /// Tween between two Vector3 values
        /// </summary>
        /// <param name="startValue">Value to start tweening from</param>
        /// <param name="endValue">Value to end tweening to</param>
        /// <param name="duration">Amount of time between the start and end value</param>
        /// <param name="easingFunction">Function that maps float[0-1]=>float[0-1] that defines the curve of the tween</param>
        /// <param name="onFrame">Action to run at every frame of the tween, passing a tweened Vector3</param>
        /// <returns>Enumerator that will call onFrame on every frame of the tween</returns>
        public static IEnumerator Vector3(Vector3 startValue, Vector3 endValue, float duration, System.Func<float, float> easingFunction, System.Action<Vector3> onFrame) =>
            Generic(startValue, endValue, duration, easingFunction, onFrame, UnityEngine.Vector3.LerpUnclamped);

        /// <summary>
        /// Tween between two Quaternion values
        /// </summary>
        /// <param name="startValue">Value to start tweening from</param>
        /// <param name="endValue">Value to end tweening to</param>
        /// <param name="duration">Amount of time between the start and end value</param>
        /// <param name="easingFunction">Function that maps float[0-1]=>float[0-1] that defines the curve of the tween</param>
        /// <param name="onFrame">Action to run at every frame of the tween, passing a tweened Quaternion</param>
        /// <returns>Enumerator that will call onFrame on every frame of the tween</returns>
        public static IEnumerator Quaternion(Quaternion startValue, Quaternion endValue, float duration, System.Func<float, float> easingFunction, System.Action<Quaternion> onFrame) =>
            Generic(startValue, endValue, duration, easingFunction, onFrame, UnityEngine.Quaternion.LerpUnclamped);

        /// <summary>
        /// Tween between two Color values
        /// </summary>
        /// <param name="startValue">Value to start tweening from</param>
        /// <param name="endValue">Value to end tweening to</param>
        /// <param name="duration">Amount of time between the start and end value</param>
        /// <param name="easingFunction">Function that maps float[0-1]=>float[0-1] that defines the curve of the tween</param>
        /// <param name="onFrame">Action to run at every frame of the tween, passing a tweened Color</param>
        /// <returns>Enumerator that will call onFrame on every frame of the tween</returns>
        public static IEnumerator Color(Color startValue, Color endValue, float duration, System.Func<float, float> easingFunction, System.Action<Color> onFrame) =>
            Generic(startValue, endValue, duration, easingFunction, onFrame, UnityEngine.Color.LerpUnclamped);

        /// <summary>
        /// Tween for generic type where the lerp function must be specified
        /// </summary>
        /// <typeparam name="T">Type of value to tween</typeparam>
        /// <param name="startValue">Value to start tweening from</param>
        /// <param name="endValue">Value to end tweening to</param>
        /// <param name="duration">Amount of time between the start and end value</param>
        /// <param name="easingFunction">Function that maps float[0-1]=>float[0-1] that defines the curve of the tween</param>
        /// <param name="onFrame">Action to run at every frame of the tween, passing a tweened T value</param>
        /// <param name="lerpFunction">Function that maps (T, T, float)=>T that defines how to interpolate between values of T</param>
        /// <returns>Enumerator that will call onFrame on every frame of the tween</returns>
        public static IEnumerator Generic<T>(T startValue, T endValue, float duration, System.Func<float, float> easingFunction, System.Action<T> onFrame, System.Func<T, T, float, T> lerpFunction)
        {
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                onFrame(lerpFunction(startValue, endValue, easingFunction(elapsedTime / duration)));
                yield return null;
                elapsedTime += Time.deltaTime;
            }
            onFrame(endValue);
        }
    }
}
