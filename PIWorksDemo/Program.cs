using PIWorksDemo;
using PIWorksDemo.Models;

List<PlaySongModel> playSongList = new List<PlaySongModel>();
using (var reader = new StreamReader(@"..\..\..\..\input.csv"))
{
    reader.ReadLine();//removing header
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var values = line.Split('\t');

        var playSongModel = new PlaySongModel()
        {
            PLAY_ID = values[0],
            SONG_ID = int.Parse(values[1]),
            CLIENT_ID = int.Parse(values[2]),
            PLAY_TS = DateTime.Parse(values[3]),
        };
        playSongList.Add(playSongModel);
    }
}

var resultQ1 = PlaySongApp.GetClientCountByPerPlayCount(playSongList);
Console.WriteLine(resultQ1);

var resultQ2 = PlaySongApp.GetPlayCountPerClienID(playSongList, 346);
Console.WriteLine(resultQ2);

var resultQ3 = PlaySongApp.GetDistinctSongCount(playSongList);
Console.WriteLine(resultQ3);

//foreach (var playSong in playSongList)
//{
//    Console.WriteLine(playSong.PLAY_ID + " " + playSong.CLIENT_ID + " " + playSong.SONG_ID + " " + playSong.PLAY_TS);
//}

Console.ReadLine();