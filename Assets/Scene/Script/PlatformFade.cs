using UnityEngine;

public class PlatformFade : MonoBehaviour
{
    public float fadeDuration = 1.5f;  // �������ʱ��
    private float currentAlpha = 1f;   // ��ǰ͸����
    private Material material;         // ƽ̨����

    private void Start()
    {
        // ��ȡƽ̨�������Ⱦ�����
        Renderer renderer = GetComponent<Renderer>();

        // ��ȡƽ̨����Ĳ���
        material = renderer.material;

        // �����ʵ���ɫ����Ϊ��ɫ����ʼ͸����Ϊ1
        Color color = Color.black;
        color.a = currentAlpha;
        material.color = color;
    }

    private void Update()
    {
        // �����ǰ͸���ȴ���0�������͸���Ƚ���
        if (currentAlpha > 0f)
        {
            // ���㵱ǰ͸����
            currentAlpha -= Time.deltaTime / fadeDuration;
            currentAlpha = Mathf.Clamp01(currentAlpha);

            // ���²��ʵ�͸����
            Color color = material.color;
            color.a = currentAlpha;
            material.color = color;
        }
    }
}