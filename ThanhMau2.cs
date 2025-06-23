using UnityEngine;
using UnityEngine.UI;

public class ThanhMau2 : MonoBehaviour
{
    public Image thanhmau2;

    public void CapnhatThanhmau(float mauHienTai, float mauToiDa)
    {
        thanhmau2.fillAmount = mauHienTai / mauToiDa;
    }
}
