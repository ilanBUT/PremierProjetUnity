using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Gradient gradient;
    [SerializeField] private IntVariable playerCurrentLifePoints;
    [SerializeField] private IntVariable playerMaxLifePoints;

    void Update()
    {
        // On ne lance SetHealth que si toutes les variables sont assignées
        if (fillImage != null && playerCurrentLifePoints != null && playerMaxLifePoints != null)
        {
            SetHealth();
        }
    }

    private void SetHealth()
    {
        // Empêche la division par zéro si maxLifePoints n'est pas encore initialisé
        if (playerMaxLifePoints.CurrentValue <= 0) return;

        // Calcul du ratio de vie (0 à 1)
        float healthNormalized = (float)playerCurrentLifePoints.CurrentValue / playerMaxLifePoints.CurrentValue;

        // Mise à jour de la barre (doit être en mode "Filled" dans Unity)
        fillImage.fillAmount = healthNormalized;

        // Mise à jour de la couleur si un gradient est fourni
        if (gradient != null)
        {
            fillImage.color = gradient.Evaluate(healthNormalized);
        }
    }
}