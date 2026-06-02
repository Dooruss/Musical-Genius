using System.Collections.Generic;

public static class Genre_Database
{
    public static List<Genre_Data> Genres = new()
    {
        new Genre_Data
        {
            genreName = "Pop",
            VocalsWeight = 0.4f,
            ProducingWeight = 0.2f,
            SongWritingWeight = 0.4f,
            LivePerformanceWeight = 0.2f
        },

        new Genre_Data
        {
            genreName = "Rock",
            VocalsWeight = 0.35f,
            ProducingWeight = 0.1f,
            SongWritingWeight = 0.35f,
            LivePerformanceWeight = 0.2f
        },

        new Genre_Data
        {
            genreName = "Rap",
            VocalsWeight = 0.2f,
            ProducingWeight = 0.2f,
            SongWritingWeight = 0.4f,
            LivePerformanceWeight = 0.3f
        },

        new Genre_Data
        {
            genreName = "Jazz",
            VocalsWeight = 0.2f,
            ProducingWeight = 0.15f,
            SongWritingWeight = 0.3f,
            LivePerformanceWeight = 0.4f
        },

        new Genre_Data
        {
            genreName = "Electronic",
            VocalsWeight = 0.1f,
            ProducingWeight = 0.4f,
            SongWritingWeight = 0.2f,
            LivePerformanceWeight = 0.1f
        },

        new Genre_Data
        {
            genreName = "Country",
            VocalsWeight = 0.3f,
            ProducingWeight = 0.1f,
            SongWritingWeight = 0.4f,
            LivePerformanceWeight = 0.2f
        },

        new Genre_Data
        {
            genreName = "RnB",
            VocalsWeight = 0.35f,
            ProducingWeight = 0.25f,
            SongWritingWeight = 0.25f,
            LivePerformanceWeight = 0.15f
        }

    };
    

    public static Genre_Data GetGenre(string genreName)
    {
        return Genres.Find(g => g.genreName == genreName);
    }
}
