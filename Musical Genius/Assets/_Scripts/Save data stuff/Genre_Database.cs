using System.Collections.Generic;
using UnityEngine;

public class GenreDatabase : MonoBehaviour
{
    public static List<GenreData> Genres = new List<GenreData>()
    {
        new GenreData
        {
            genreName = "Pop",

            popularityAsia = 85,
            popularityEurope = 90,
            popularityNorthAmerica = 95,
            popularitySouthAmerica = 80,
            popularityAfrica = 70
        },

        new GenreData
        {
            genreName = "Rock",

            popularityAsia = 50,
            popularityEurope = 80,
            popularityNorthAmerica = 70,
            popularitySouthAmerica = 55,
            popularityAfrica = 35
        },

        new GenreData
        {
            genreName = "Rap",

            popularityAsia = 60,
            popularityEurope = 85,
            popularityNorthAmerica = 100,
            popularitySouthAmerica = 75,
            popularityAfrica = 65
        },

        new GenreData
        {
            genreName = "Jazz",

            popularityAsia = 40,
            popularityEurope = 50,
            popularityNorthAmerica = 45,
            popularitySouthAmerica = 35,
            popularityAfrica = 30
        }
    };
}