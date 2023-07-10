using UnityEngine;

public class PlatformFade : MonoBehaviour
{
    public float fadeDuration = 1.5f;  // 渐变持续时间
    private float currentAlpha = 1f;   // 当前透明度
    private Material material;         // 平台材质

    private void Start()
    {
        // 获取平台对象的渲染器组件
        Renderer renderer = GetComponent<Renderer>();

        // 获取平台对象的材质
        material = renderer.material;

        // 将材质的颜色设置为黑色，初始透明度为1
        Color color = Color.black;
        color.a = currentAlpha;
        material.color = color;
    }

    private void Update()
    {
        // 如果当前透明度大于0，则进行透明度渐变
        if (currentAlpha > 0f)
        {
            // 计算当前透明度
            currentAlpha -= Time.deltaTime / fadeDuration;
            currentAlpha = Mathf.Clamp01(currentAlpha);

            // 更新材质的透明度
            Color color = material.color;
            color.a = currentAlpha;
            material.color = color;
        }
    }
}