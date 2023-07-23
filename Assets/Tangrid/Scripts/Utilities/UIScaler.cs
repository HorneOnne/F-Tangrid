using UnityEngine;
using System.Collections;

namespace HackReaction
{
    public class UIScaler : MonoBehaviour
    {
        public Vector2 targetScale = new Vector2(1f, 1f);
        public float scalingDuration = 0.5f;

        private RectTransform rectTransform;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            StartCoroutine(ScaleOverTime());
        }

        IEnumerator ScaleOverTime()
        {
            Vector2 initialScale = rectTransform.localScale;
            float currentTime = 0f;

            while (currentTime < scalingDuration)
            {
                rectTransform.localScale = Vector2.Lerp(initialScale, targetScale, currentTime / scalingDuration);
                currentTime += Time.deltaTime;
                yield return null;
            }

            rectTransform.localScale = targetScale; // Ensure the target scale is reached
        }
    }
}
