using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    protected Image HealthBarImage;

    void Start(){
        HealthBarImage = GetComponent<Image>();
    }

    public void SetHealthBarValue(float value){
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount <= 0.2f){
            SetHealthBarColor(Color.red);
        }
        else if(HealthBarImage.fillAmount <= 0.45f){
            SetHealthBarColor(Color.yellow);
        }
        else{
            SetHealthBarColor(Color.green);
        }
    }

    public float GetHealthBarValue(){
        return HealthBarImage.fillAmount;
    }
 
    public void SetHealthBarColor(Color healthColor){
        HealthBarImage.color = healthColor;
    }

    
}