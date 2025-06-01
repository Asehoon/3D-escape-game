using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 playerPosition; // �÷��̾� ��ġ ����
    public string originalSceneName; // ���� �� �̸� ����
    public Transform playerTransform; // �÷��̾� ������Ʈ�� Transform (Inspector���� �Ҵ� �Ǵ� �ڵ� ����)
    public List<bool> booleanList; // ������ �����ϱ� ���� boolean ����Ʈ

    void Awake()
    {
        // �̱��� ���� ����: �̹� �ν��Ͻ��� ������ ���� ������Ʈ�� �ı�
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
        }
        else
        {
            Destroy(gameObject);
        }

        // booleanList �ʱ�ȭ
        if (booleanList == null)
        {
            booleanList = new List<bool>();
            Debug.Log("Boolean ����Ʈ �ʱ�ȭ��");
        }

        // playerTransform�� �Ҵ���� �ʾҴٸ� "MainCamera" �±׸� ���� ������Ʈ�� �ڵ����� ã��
        if (playerTransform == null)
        {
            GameObject cameraObject = GameObject.FindWithTag("MainCamera");
            if (cameraObject != null)
            {
                playerTransform = cameraObject.transform;
                Debug.Log("MainCamera �±׸� ���� ������Ʈ�� playerTransform�� �ڵ� �Ҵ�: " + cameraObject.name);
            }
            else
            {
                Debug.LogWarning("MainCamera �±׸� ���� ������Ʈ�� ã�� �� �����ϴ�. playerTransform�� �Ҵ���� ����.");
            }
        }
    }

    // �÷��̾� ��ġ ����
    public void SavePlayerPosition(string sceneName)
    {
        GameObject cameraObject = GameObject.FindWithTag("MainCamera");
        playerTransform = cameraObject.transform;
        if (playerTransform != null)
        {
            playerPosition = playerTransform.position; // �÷��̾� ������Ʈ�� ���� ��ġ ����
            originalSceneName = sceneName;
            Debug.Log($"�÷��̾� ��ġ ����: {playerPosition}, ���� ��: {sceneName}");
        }
        else
        {
            Debug.LogWarning("�÷��̾� Transform�� �Ҵ���� �ʾҽ��ϴ�. ��ġ�� ������ �� �����ϴ�.");
        }
    }

    // �÷��̾� ��ġ ��������
    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }

    // ���� �� �̸� ��������
    public string GetOriginalSceneName()
    {
        return originalSceneName;
    }

    // Boolean ����Ʈ�� �� �߰�
    public void AddBoolean(bool value)
    {
        booleanList.Add(value);
        Debug.Log($"Boolean �� �߰�: {value}, ����Ʈ ũ��: {booleanList.Count}");
    }

    // Boolean ����Ʈ���� Ư�� �ε����� �� ��������
    public bool GetBoolean(int index)
    {
        if (index >= 0 && index < booleanList.Count)
        {
            return booleanList[index];
        }
        Debug.LogWarning($"�߸��� �ε���: {index}, ����Ʈ ũ��: {booleanList.Count}");
        return false; // �⺻�� ��ȯ
    }

    // Boolean ����Ʈ���� Ư�� �ε����� �� ����
    public void SetBoolean(int index, bool value)
    {
        if (index >= 0 && index < booleanList.Count)
        {
            booleanList[index] = value;
            Debug.Log($"Boolean �� ����: �ε��� {index} = {value}");
        }
        else
        {
            Debug.LogWarning($"�߸��� �ε���: {index}, ����Ʈ ũ��: {booleanList.Count}");
        }
    }

    // Boolean ����Ʈ �ʱ�ȭ (��� �� ����)
    public void ClearBooleanList()
    {
        booleanList.Clear();
        Debug.Log("Boolean ����Ʈ �ʱ�ȭ��");
    }

    // Boolean ����Ʈ ũ�� ��ȯ
    public int GetBooleanListSize()
    {
        return booleanList.Count;
    }

    // �̱��� �ν��Ͻ��� �����ϴ� ������Ƽ
    public static GameManager Instance
    {
        get { return instance; }
    }
}
