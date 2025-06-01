using UnityEngine;
using TMPro;

public class NumberClick : MonoBehaviour
{
    public TextMeshProUGUI targetText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 2D Raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // ���� ���� ó��
                if (targetText != null)
                {
                    int number = 0;
                    int.TryParse(targetText.text, out number);
                    number = (number + 1) % 10; // 9���� 0���� �ǵ���
                    targetText.text = number.ToString();
                }
                else
                {
                    Debug.LogWarning("TextMeshProUGUI�� ������� �ʾҽ��ϴ�.");
                }
            }
        }
    }
}
