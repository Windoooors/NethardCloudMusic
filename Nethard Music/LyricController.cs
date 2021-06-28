using System.Collections.Generic;
using Kfstorm.LrcParser;
using Setchin.NethardMusic.Collections;

namespace Setchin.NethardMusic
{
    public class LyricController
    {
        private IEnumerable<IOneLineLyric> _lyric;
        private IEnumerable<IOneLineLyric> _clippedLyric; // store clipped collection to save query time.
        private int _indexOffset = 0;

        public LyricController()
        {
        }

        public void Initialize(IEnumerable<IOneLineLyric> lyric)
        {
            _lyric = lyric;
            _clippedLyric = lyric;
            _indexOffset = 0;
        }

        public int GetPosition(double offset)
        {
            GetLine(offset);
            return _indexOffset;
        }

        public string GetLine(double offset)
        {
            int index;
            string content;

            if (TryGetLine(_clippedLyric, offset, out index, out content))
            {
                _clippedLyric = _clippedLyric.Skip(index);
                _indexOffset += index;
            }
            else if (TryGetLine(_lyric, offset, out index, out content))
            {
                _clippedLyric = _lyric.Skip(index);
                _indexOffset = index;
            }

            return content;
        }

        private static bool TryGetLine(IEnumerable<IOneLineLyric> lyric, double offset, out int index, out string content)
        {
            index = -1;
            content = null;
            double lastOffset = 0;

            foreach (var line in lyric)
            {
                if (lastOffset < offset && (lastOffset = line.Timestamp.TotalSeconds) > offset)
                {
                    return content != null;
                }

                content = line.Content;
                index++;
            }

            return false;
        }
    }
}
