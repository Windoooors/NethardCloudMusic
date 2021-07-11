using System.Collections.Generic;
using Kfstorm.LrcParser;
using Setchin.NethardMusic.Collections;

namespace Setchin.NethardMusic
{
    public class LyricController
    {
        private IOneLineLyric[] _lyric;
        private int _index = 0;

        public LyricController()
        {
        }
        
        public void Initialize(IEnumerable<IOneLineLyric> lyric)
        {
            _lyric = lyric.ToArray();
            _index = 0;
        }

        public int GetPosition(double offset)
        {
            UpdateState(offset);
            return _index;
        }

        public string GetLine(double offset)
        {
            UpdateState(offset);
            return _lyric[_index].Content;
        }

        private void UpdateState(double offset)
        {
            int length = _lyric.Length - 1;
            double start = _lyric[_index].Timestamp.TotalSeconds;

            if (_index < length - 1)
            {
                double stop = _lyric[_index + 1].Timestamp.TotalSeconds;

                if (offset >= start && offset < stop)
                {
                    return;
                }
            }

            IEnumerable<IOneLineLyric> lyric = _lyric;

            if (_index < length - 2)
            {
                double stop = _lyric[_index + 1].Timestamp.TotalSeconds;
                double nextStop = _lyric[_index + 2].Timestamp.TotalSeconds;

                if (offset > stop && offset < nextStop)
                {
                    _index++;
                    return;
                }

                if (offset > nextStop)
                {
                    lyric = lyric.Skip(_index);
                }
            }

            if (offset < start)
            {
                if (_index == 0)
                {
                    return;
                }

                _index = 0;
            }
            else if (offset > start && _index == length)
            {
                return;
            }

            double lastOffset = 0;

            int index = _index;

            foreach (var line in lyric)
            {
                double currentOffset = line.Timestamp.TotalSeconds;

                if (offset >= lastOffset && offset < currentOffset)
                {
                    _index = index;
                    return;
                }

                lastOffset = currentOffset;

                index++;
            }

            _index = length;
        }
    }
}
