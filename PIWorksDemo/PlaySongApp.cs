using PIWorksDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PIWorksDemo
{
    public class PlaySongApp
    {
        public static string GetClientCountByPerPlayCount(List<PlaySongModel> playSongList)
        {
            try
            {
                var groupedPlaySongList = playSongList.Where(x => x.PLAY_TS == new DateTime(2016, 8, 10))
                                                  .GroupBy(y => y.CLIENT_ID)
                                                  .Select(z => new
                                                  {
                                                      ClientID = z.Key,
                                                      PlayCount = z.Select(t => t.SONG_ID).Distinct().Count()
                                                  })
                                                  .GroupBy(c => c.PlayCount)
                                                  .Select(b => new
                                                  {
                                                      PLAY_COUNT = b.Key,
                                                      CLIENT_COUNT = b.Count()
                                                  });

                var json = JsonSerializer.Serialize(groupedPlaySongList);

                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetPlayCountPerClienID(List<PlaySongModel> playSongList, int playCount)
        {
            try
            {
                var playCountList = playSongList.GroupBy(y => y.CLIENT_ID)
                                                      .Select(z => new
                                                      {
                                                          ClientID = z.Key,
                                                          PlayCount = z.Select(t => t.SONG_ID).Distinct().Count()
                                                      })
                                                      .Where(b => b.PlayCount == playCount).Count();

                var json = JsonSerializer.Serialize(playCountList);

                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string GetDistinctSongCount(List<PlaySongModel> playSongList)
        {
            try
            {
                var distinctSongCount = playSongList.Select(t => t.SONG_ID).Distinct().Count();

                return distinctSongCount.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}