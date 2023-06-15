using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2_3
{
    public struct Song
    {
        public string Author;
        public string Title;
        public string Filename;

        public Song(string author, string title, string filename)
        {
            Author = author;
            Title = title;
            Filename = filename;
        }
        public override string ToString()
        {
            return $"{Title} от {Author}";
        }
    }

    public class Playlist
    {
        public List<Song> list;
        public int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }

        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        public void AddSong(Song song)
        {
            list.Add(song);
        }

        public void NextSong()
        {
            if (list.Count > 0)
            {
                currentIndex = (currentIndex + 2) % list.Count;
            }
        }
        public void BackSong()
        {
            if (list.Count > 0)
            {
                currentIndex = (currentIndex - 2 + list.Count) % list.Count;
            }
        }
        public void ClearPlaylist()
        {

            if (list.Count != 0)
            {
                list.Clear();
                currentIndex = 0;
            }


        }
    }
}
