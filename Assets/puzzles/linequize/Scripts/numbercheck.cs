using UnityEngine;
using TMPro;

public class NumberClickChecker : MonoBehaviour
{
    public TextMeshProUGUI[] numberTexts; // ���� �ؽ�Ʈ 5��

    // ��ư Ŭ�� �� ȣ���� �Լ�
    public void CheckCode()
    {
        string code = "";
        foreach (var tmp in numberTexts)
        {
            code += tmp.text;
        }

        if (code == "12345")
        {
            Debug.Log("Ż��!");
        }
        else
        {
            Debug.Log("���� �Է�: " + code);
        }
    }
}
