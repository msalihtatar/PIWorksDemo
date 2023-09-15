using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIWorksDemo.Models
{
    public class PlaySongModel
    {
        public string PLAY_ID { get; set; }

        public int SONG_ID { get; set; }

        public int CLIENT_ID { get; set; } 

        public DateTime PLAY_TS { get; set; }
    }
}
