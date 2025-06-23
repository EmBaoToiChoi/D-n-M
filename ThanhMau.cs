
using UnityEngine;
using UnityEngine.UI;

public class ThanhMau : MonoBehaviour
{
    public Image thanhmau1;
    public void Capnhatthanhmau(float mauhientai, float mautoida){
        thanhmau1.fillAmount = mauhientai / mautoida ;
    }
    
}
