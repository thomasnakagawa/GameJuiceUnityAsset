using UnityEngine;

namespace GameJuice
{
    /// <summary>
    /// Singleton MonoBehaviour to attach to camera object to give camera shake effect.
    /// Add trauma to add shake to the camera, the amount of camera shake is proportional to n^2 of trauma level.
    /// </summary>
    public class CameraShaker : MonoBehaviour
    {
        [Header("Shake recovery")]
        [SerializeField] private float TraumaRecoveryRate = 1f;
        [SerializeField] private float MaxTrauma = 1f;

        [Header("Shake speed")]
        [SerializeField] private float ShakeRate = 10f;

        [Header("Shake magnitude")]
        [SerializeField] private float MaxRollAngle = 5f;
        [SerializeField] private float MaxXTranslate = 0.5f;
        [SerializeField] private float MaxYTranslate = 0.5f;
        [SerializeField] private float MaxZTranslate = 0.5f;

        [Header("Debug")]
        [Tooltip("When enabled, press number keys 1, 2 and 3 to add trauma")]
        [SerializeField] private bool DebugKeysEnabled = false;

        public static float LIGHT_TRAUMA => 0.3f;
        public static float MODERATE_TRAUMA => 0.45f;
        public static float HEAVY_TRAUMA => 0.6f;

        private float currentTrauma = 0f;

        private static CameraShaker Instance;

        // Start is called before the first frame update
        void Start()
        {
            if (Instance != null)
            {
                Debug.LogWarning("There should not be multiple CameraShaker instances in a scene. Deleting one of them");
                Destroy(Instance);
            }
            Instance = this;

            if (transform.localPosition != Vector3.zero || transform.localEulerAngles != Vector3.zero)
            {
                Debug.LogWarning("CameraShaker component will move it's transform and should be attached to a transform with (0, 0, 0) position and rotation");
            }
        }

        /// <summary>
        /// Get perlin noise between [-1, 1]
        /// </summary>
        /// <param name="seed"></param>
        /// <returns></returns>
        private float PerlinNoise(float seed)
        {
            return (Mathf.PerlinNoise(seed, Time.time * ShakeRate) - 0.5f) * 2f;
        }

        // Update is called once per frame
        void Update()
        {
            if (currentTrauma > 0f)
            {
                // clamp trauma to max setting
                if (currentTrauma > MaxTrauma)
                {
                    currentTrauma = MaxTrauma;
                }

                // reduce trauma and calculate shake level based on trauma
                currentTrauma -= TraumaRecoveryRate * Time.deltaTime;
                float shakeLevel = Mathf.Pow(currentTrauma, 2f);

                // shake camera
                transform.localEulerAngles = Vector3.forward * shakeLevel * MaxRollAngle * PerlinNoise(1f);
                transform.localPosition = new Vector3(
                    shakeLevel * MaxXTranslate * PerlinNoise(2f),
                    shakeLevel * MaxYTranslate * PerlinNoise(3f),
                    shakeLevel * MaxZTranslate * PerlinNoise(4f)
                );
            }

            // clamp trauma to 0
            if (currentTrauma < 0f)
            {
                currentTrauma = 0f;
            }

            if (DebugKeysEnabled)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    AddTrauma(LIGHT_TRAUMA);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    AddTrauma(MODERATE_TRAUMA);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    AddTrauma(HEAVY_TRAUMA);
                }
            }
        }

        /// <summary>
        /// Add to the amount of camera shake. Class has fields LIGHT_TRAUMA, MODERATE_TRAUMA, HEAVY_TRAUMA for standard values.
        /// </summary>
        /// <param name="traumaLevel">Amount of trauma to add</param>
        public static void AddTrauma(float traumaLevel)
        {
            if (Instance == null)
            {
                Debug.LogException(new System.InvalidOperationException("Cannot shake camera, no CameraShaker instance in scene"));
            }
            else
            {
                Instance.currentTrauma += traumaLevel;
            }
        }
    }
}
