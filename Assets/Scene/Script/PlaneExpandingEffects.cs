using UnityEngine;

public class PlaneExpandingEffects : MonoBehaviour
{
    private Renderer planeRenderer;
    private float startTime;
    private float delay = 3f; // 延迟时间
    private float duration = 1.5f;
    private bool hasStarted;

    void Start()
    {
        planeRenderer = GetComponent<Renderer>();
        startTime = Time.time;
        hasStarted = false;
    }

    void Update()
    {
        // 如果延迟时间已过，并且还未开始效果，则开始效果
        if (Time.time - startTime >= delay && !hasStarted)
        {
            hasStarted = true;
            startTime = Time.time; // 重置开始时间
        }

        // 如果已经开始效果
        if (hasStarted)
        {
            // 计算从开始到现在经过的时间比例
            float elapsedRatio = (Time.time - startTime) / duration;

            // 根据时间比例计算透明度
            float alpha = Mathf.Lerp(0f, 1f, elapsedRatio);

            // 设置透明度到材质的颜色属性中
            Color color = planeRenderer.material.color;
            color.a = alpha;
            planeRenderer.material.color = color;

            // 如果经过的时间大于持续时间，停止更新并设置完全不透明
            if (Time.time - startTime >= duration)
            {
                color.a = 1f;
                planeRenderer.material.color = color;
                enabled = false;
            }
        }
    }
}
