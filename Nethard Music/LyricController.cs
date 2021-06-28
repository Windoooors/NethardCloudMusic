using System.Collections.Generic;
using Kfstorm.LrcParser;
using Setchin.NethardMusic.Collections;

namespace Setchin.NethardMusic
{
    public class LyricController
    {
        private IEnumerable<IOneLineLyric> _lyric;

        public LyricController()
        {
        }
        
        public void Initialize(IEnumerable<IOneLineLyric> lyric)
        {
            _lyric = lyric;
        }

        public int GetPosition(double offset)
        {
            int index;
            string content;

            TryGetLine(_lyric, offset, out index, out content);

            return index;
        }

        public string GetLine(double offset)
        {
            int index;
            string content;

            TryGetLine(_lyric, offset, out index, out content);

            return content;
        }

        private static bool TryGetLine(IEnumerable<IOneLineLyric> lyric, double offset, out int index, out string content)
        {
            index = -1;
            content = null;
            double lastOffset = 0;

            foreach (var line in lyric)
            {
                if ((lastOffset < offset || index == 0) && (lastOffset = line.Timestamp.TotalSeconds) > offset)
                {
                    break;
                }

                content = line.Content;
                index++;
            }

            return content != null;
        }
    }
}
