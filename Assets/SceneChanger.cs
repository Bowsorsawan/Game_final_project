using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Transform player;            // ����Фü�����
    public Transform targetPoint;       // �ش�������蹵�ͧ�Թ件֧
    public float proximity = 1.0f;      // ���з����������ͷ�������¹�ҡ
    public string nextSceneName;        // ���ͧ͢ Scene �Ѵ价���ͧ�����Ŵ

    void Update()
    {
        // �ӹǳ������ҧ�����ҧ�����蹡Ѻ�ش����¹�ҡ
        float distance = Vector2.Distance(player.position, targetPoint.position);

        // ��Ҽ�����������������͡Ѻ�ش����¹�ҡ
        if (distance <= proximity)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        // ��Ŵ Scene ������ͷ���˹�� Inspector
        SceneManager.LoadScene(nextSceneName);
    }
}
