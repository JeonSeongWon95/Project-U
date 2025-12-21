using UnityEngine;

/// <summary>
/// 하루 사이클 스크립트(해, 조명 조절)
/// </summary>

public class DayNightCycle : MonoBehaviour
{
    private DayNightCycle instance;
    public DayNightCycle Instance 
    { 
        get 
        {
            if(instance == null)
                instance = new DayNightCycle();

            return instance;
        } 
    }

    [Header("Time")]
    [SerializeField] private float dayDuration = 60.0f; // 하루가 지나가는 시간. 60.0f -> 1분이 하루
    [SerializeField] private float timeOfDay; // 지금 시간. 0 = 새벽, 0.5 = 정오, 1 = 자정

    [Header("Light")]
    [SerializeField] private Light sunlight; // 해(Directional Light)
    [SerializeField] private Gradient sunColor; // 시간대 별 해 색상
    [SerializeField] private Gradient skyColor; // 시간대 별 하늘 색상
    [SerializeField] private AnimationCurve sunIntensity; // 시간대 별 빛 세기

    [Header("Weather Modifer")]
    private float weatherModifer = 1.0f; // 날씨에 따른 빛의 세기 조절용 Modifer
    public float WeatherModifer 
    {
        get {return weatherModifer;}
        set {weatherModifer = value;}
    }

    /// <summary>
    /// 시각에 따른 해 위치 변경
    /// </summary>
    private void Update()
    {
        timeOfDay += (Time.deltaTime / dayDuration);

        if (timeOfDay >= 1)
            timeOfDay = 0;

        float sunAngle = (timeOfDay * 360f) - 90f;
        sunlight.transform.localRotation = Quaternion.Euler(sunAngle, 170f, 0);

        ChangeLighting();
    }

    /// <summary>
    /// 시각 및 날씨에 따른 조명 변경
    /// </summary>
    private void ChangeLighting() 
    {
        sunlight.color = sunColor.Evaluate(timeOfDay);
        sunlight.intensity = sunIntensity.Evaluate(timeOfDay) * WeatherModifer;

        RenderSettings.ambientLight = skyColor.Evaluate(timeOfDay);

        if (RenderSettings.fog) 
        {
            RenderSettings.fogColor = skyColor.Evaluate(timeOfDay);
        }

    }
}
