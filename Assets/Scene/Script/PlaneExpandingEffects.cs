using UnityEngine;

public class PlaneExpandingEffects : MonoBehaviour
{
    private Renderer planeRenderer;
    private float startTime;
    private float delay = 3f; // �ӳ�ʱ��
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
        // ����ӳ�ʱ���ѹ������һ�δ��ʼЧ������ʼЧ��
        if (Time.time - startTime >= delay && !hasStarted)
        {
            hasStarted = true;
            startTime = Time.time; // ���ÿ�ʼʱ��
        }

        // ����Ѿ���ʼЧ��
        if (hasStarted)
        {
            // ����ӿ�ʼ�����ھ�����ʱ�����
            float elapsedRatio = (Time.time - startTime) / duration;

            // ����ʱ���������͸����
            float alpha = Mathf.Lerp(0f, 1f, elapsedRatio);

            // ����͸���ȵ����ʵ���ɫ������
            Color color = planeRenderer.material.color;
            color.a = alpha;
            planeRenderer.material.color = color;

            // ���������ʱ����ڳ���ʱ�䣬ֹͣ���²�������ȫ��͸��
            if (Time.time - startTime >= duration)
            {
                color.a = 1f;
                planeRenderer.material.color = color;
                enabled = false;
            }
        }
    }
}
