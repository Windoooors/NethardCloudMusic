using System.Collections.Generic;
using Kfstorm.LrcParser;
using Setchin.NethardCloudMusic.Collections;

namespace Setchin.NethardCloudMusic
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

            int count = 0;

            if (_index < length - 2)
            {
                double stop = _lyric[_index + 1].Timestamp.TotalSeconds;
                double nextStop = _lyric[_index + 2].Timestamp.TotalSeconds;

                if (offset >= stop && offset < nextStop)
                {
                    _index++;
                    return;
                }

                if (offset > nextStop)
                {
                    count = _index;
                }
            }


            if (offset < start)
            {
                if (_index == 0)
                {
                    return;
                }
            }
            else if (offset > start && _index == length)
            {
                return;
            }

            double lastOffset = 0;
            int index = -1;

            var enumerator = ((IEnumerable<IOneLineLyric>)_lyric).GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (++index < count)
                {
                    continue;
                }

                double currentOffset = enumerator.Current.Timestamp.TotalSeconds;

                if (offset >= lastOffset && offset < currentOffset)
                {
                    _index = index == 0 ? 0 : index - 1;
                    return;
                }

                lastOffset = currentOffset;
            }

            _index = length;
        }
    }
}
