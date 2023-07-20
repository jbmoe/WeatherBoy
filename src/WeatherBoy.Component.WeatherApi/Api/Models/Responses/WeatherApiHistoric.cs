using System.Text.Json.Serialization;

namespace WeatherBoy.Component.WeatherApi.Api.Models.Responses;

public class WeatherApiHistoric
{
    public WeatherApiHistoric(List<WeatherApiHistoricDay> historicDay)
    {
        HistoricDay = historicDay;
    }

    [JsonPropertyName("forecastday")]
    public List<WeatherApiHistoricDay> HistoricDay { get; set; }

    public class WeatherApiHistoricDay
    {
        public WeatherApiHistoricDay(
            string date,
            int dateEpoch,
            WeatherApiDay day,
            WeatherApiAstro astro,
            List<WeatherApiHour> hour)
        {
            Date = date;
            DateEpoch = dateEpoch;
            Day = day;
            Astro = astro;
            Hour = hour;
        }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("date_epoch")]
        public int DateEpoch { get; set; }

        [JsonPropertyName("day")]
        public WeatherApiDay Day { get; set; }

        [JsonPropertyName("astro")]
        public WeatherApiAstro Astro { get; set; }

        [JsonPropertyName("hour")]
        public List<WeatherApiHour> Hour { get; set; }

        public class WeatherApiDay
        {
            public WeatherApiDay(
                double maxtempC,
                double maxtempF,
                double mintempC,
                double mintempF,
                double avgtempC,
                double avgtempF,
                double maxwindMph,
                double maxwindKph,
                double totalprecipMm,
                double totalprecipIn,
                double avgvisKm,
                double avgvisMiles,
                double avghumidity,
                WeatherApiCondition condition,
                double uv)
            {
                MaxtempC = maxtempC;
                MaxtempF = maxtempF;
                MintempC = mintempC;
                MintempF = mintempF;
                AvgtempC = avgtempC;
                AvgtempF = avgtempF;
                MaxwindMph = maxwindMph;
                MaxwindKph = maxwindKph;
                TotalprecipMm = totalprecipMm;
                TotalprecipIn = totalprecipIn;
                AvgvisKm = avgvisKm;
                AvgvisMiles = avgvisMiles;
                Avghumidity = avghumidity;
                Condition = condition;
                Uv = uv;
            }

            [JsonPropertyName("maxtemp_c")]
            public double MaxtempC { get; set; }

            [JsonPropertyName("maxtemp_f")]
            public double MaxtempF { get; set; }

            [JsonPropertyName("mintemp_c")]
            public double MintempC { get; set; }

            [JsonPropertyName("mintemp_f")]
            public double MintempF { get; set; }

            [JsonPropertyName("avgtemp_c")]
            public double AvgtempC { get; set; }

            [JsonPropertyName("avgtemp_f")]
            public double AvgtempF { get; set; }

            [JsonPropertyName("maxwind_mph")]
            public double MaxwindMph { get; set; }

            [JsonPropertyName("maxwind_kph")]
            public double MaxwindKph { get; set; }

            [JsonPropertyName("totalprecip_mm")]
            public double TotalprecipMm { get; set; }

            [JsonPropertyName("totalprecip_in")]
            public double TotalprecipIn { get; set; }

            [JsonPropertyName("avgvis_km")]
            public double AvgvisKm { get; set; }

            [JsonPropertyName("avgvis_miles")]
            public double AvgvisMiles { get; set; }

            [JsonPropertyName("avghumidity")]
            public double Avghumidity { get; set; }

            [JsonPropertyName("condition")]
            public WeatherApiCondition Condition { get; set; }

            [JsonPropertyName("uv")]
            public double Uv { get; set; }
        }

        public class WeatherApiAstro
        {
            public WeatherApiAstro(
                string sunrise,
                string sunset,
                string moonrise,
                string moonset,
                string moonPhase,
                string moonIllumination)
            {
                Sunrise = sunrise;
                Sunset = sunset;
                Moonrise = moonrise;
                Moonset = moonset;
                MoonPhase = moonPhase;
                MoonIllumination = moonIllumination;
            }

            [JsonPropertyName("sunrise")]
            public string Sunrise { get; set; }

            [JsonPropertyName("sunset")]
            public string Sunset { get; set; }

            [JsonPropertyName("moonrise")]
            public string Moonrise { get; set; }

            [JsonPropertyName("moonset")]
            public string Moonset { get; set; }

            [JsonPropertyName("moon_phase")]
            public string MoonPhase { get; set; }

            [JsonPropertyName("moon_illumination")]
            public string MoonIllumination { get; set; }
        }

        public class WeatherApiHour
        {
            public WeatherApiHour(
                int timeEpoch,
                string time,
                double tempC,
                double tempF,
                int isDay,
                WeatherApiCondition condition,
                double windMph,
                double windKph,
                int windDegree,
                string windDir,
                double pressureMb,
                double pressureIn,
                double precipMm,
                double precipIn,
                int humidity,
                int cloud,
                double feelslikeC,
                double feelslikeF,
                double windchillC,
                double windchillF,
                double heatindexC,
                double heatindexF,
                double dewpointC,
                double dewpointF,
                int willItRain,
                int chanceOfRain,
                int willItSnow,
                int chanceOfSnow,
                double visKm,
                double visMiles,
                double gustMph,
                double gustKph)
            {
                TimeEpoch = timeEpoch;
                Time = time;
                TempC = tempC;
                TempF = tempF;
                IsDay = isDay;
                Condition = condition;
                WindMph = windMph;
                WindKph = windKph;
                WindDegree = windDegree;
                WindDir = windDir;
                PressureMb = pressureMb;
                PressureIn = pressureIn;
                PrecipMm = precipMm;
                PrecipIn = precipIn;
                Humidity = humidity;
                Cloud = cloud;
                FeelslikeC = feelslikeC;
                FeelslikeF = feelslikeF;
                WindchillC = windchillC;
                WindchillF = windchillF;
                HeatindexC = heatindexC;
                HeatindexF = heatindexF;
                DewpointC = dewpointC;
                DewpointF = dewpointF;
                WillItRain = willItRain;
                ChanceOfRain = chanceOfRain;
                WillItSnow = willItSnow;
                ChanceOfSnow = chanceOfSnow;
                VisKm = visKm;
                VisMiles = visMiles;
                GustMph = gustMph;
                GustKph = gustKph;
            }

            [JsonPropertyName("time_epoch")]
            public int TimeEpoch { get; set; }

            [JsonPropertyName("time")]
            public string Time { get; set; }

            [JsonPropertyName("temp_c")]
            public double TempC { get; set; }

            [JsonPropertyName("temp_f")]
            public double TempF { get; set; }

            [JsonPropertyName("is_day")]
            public int IsDay { get; set; }

            [JsonPropertyName("condition")]
            public WeatherApiCondition Condition { get; set; }

            [JsonPropertyName("wind_mph")]
            public double WindMph { get; set; }

            [JsonPropertyName("wind_kph")]
            public double WindKph { get; set; }

            [JsonPropertyName("wind_degree")]
            public int WindDegree { get; set; }

            [JsonPropertyName("wind_dir")]
            public string WindDir { get; set; }

            [JsonPropertyName("pressure_mb")]
            public double PressureMb { get; set; }

            [JsonPropertyName("pressure_in")]
            public double PressureIn { get; set; }

            [JsonPropertyName("precip_mm")]
            public double PrecipMm { get; set; }

            [JsonPropertyName("precip_in")]
            public double PrecipIn { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("cloud")]
            public int Cloud { get; set; }

            [JsonPropertyName("feelslike_c")]
            public double FeelslikeC { get; set; }

            [JsonPropertyName("feelslike_f")]
            public double FeelslikeF { get; set; }

            [JsonPropertyName("windchill_c")]
            public double WindchillC { get; set; }

            [JsonPropertyName("windchill_f")]
            public double WindchillF { get; set; }

            [JsonPropertyName("heatindex_c")]
            public double HeatindexC { get; set; }

            [JsonPropertyName("heatindex_f")]
            public double HeatindexF { get; set; }

            [JsonPropertyName("dewpoint_c")]
            public double DewpointC { get; set; }

            [JsonPropertyName("dewpoint_f")]
            public double DewpointF { get; set; }

            [JsonPropertyName("will_it_rain")]
            public int WillItRain { get; set; }

            [JsonPropertyName("chance_of_rain")]
            public int ChanceOfRain { get; set; }

            [JsonPropertyName("will_it_snow")]
            public int WillItSnow { get; set; }

            [JsonPropertyName("chance_of_snow")]
            public int ChanceOfSnow { get; set; }

            [JsonPropertyName("vis_km")]
            public double VisKm { get; set; }

            [JsonPropertyName("vis_miles")]
            public double VisMiles { get; set; }

            [JsonPropertyName("gust_mph")]
            public double GustMph { get; set; }

            [JsonPropertyName("gust_kph")]
            public double GustKph { get; set; }
        }
    }
}