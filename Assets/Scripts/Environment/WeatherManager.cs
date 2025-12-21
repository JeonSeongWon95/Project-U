using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    private static WeatherManager instance;
    public static WeatherManager Instance 
    {
        get 
        {
            if(instance == null)
                instance = new WeatherManager();

            return instance;
        }
    }

    [Header("Particle")]
    [SerializeField] private ParticleSystem rainParticle; // 비 내리는 파티클
    [SerializeField] private ParticleSystem snowParticle; // 눈 내리는 파티클

    public void SetWeather(EWEATHERTYPE weatherType) 
    {
        rainParticle.Stop();
        snowParticle.Stop();

        switch (weatherType)
        {
            case EWEATHERTYPE.Serenity:
                break;
            case EWEATHERTYPE.Cloud:
                break;
            case EWEATHERTYPE.Rain:
                rainParticle.Play();
                break;
            case EWEATHERTYPE.Snow:
                snowParticle.Play();
                break;
            case EWEATHERTYPE.HeavyRain:
                break;
            case EWEATHERTYPE.HeavySnow:
                break;
            default:
                break;
        }

        UpdateAtmosphere(weatherType);
    }

    private void UpdateAtmosphere(EWEATHERTYPE weatherType) 
    {
        switch (weatherType)
        {
            case EWEATHERTYPE.Serenity:
                break;
            case EWEATHERTYPE.Cloud:
                break;
            case EWEATHERTYPE.Rain:
                break;
            case EWEATHERTYPE.Snow:
                break;
            case EWEATHERTYPE.HeavyRain:
                break;
            case EWEATHERTYPE.HeavySnow:
                break;
            default:
                break;
        }

    }
}
