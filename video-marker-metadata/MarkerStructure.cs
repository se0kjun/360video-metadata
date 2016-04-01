using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace video_marker_metadata
{
    class MarkerStructure : IEquatable<MarkerStructure>, IComparable<MarkerStructure>
    {
        public int markerId;
        public int frameSeq;
        public int milliseconds;

        public OpenCV.Net.Point2f marker_position;
        public OpenCV.Net.Size marker_size;

        public MarkerStructure(int _marker_id, int _frameSeq, OpenCV.Net.Point2f marker_pos, OpenCV.Net.Size ms)
        {
            markerId = _marker_id;
            frameSeq = _frameSeq;
            marker_size = ms;
            marker_position = marker_pos;
        }

        public int CompareTo(MarkerStructure other)
        {
            if (other == null)
                return 1;
            else
                return frameSeq.CompareTo(other.frameSeq);
        }

        public bool Equals(MarkerStructure other)
        {
            if (other == null)
                return false;
            else
            {
                if (Math.Abs(other.frameSeq - this.frameSeq) <= 5)
                    return true;
                else return false;
            }
        }
    }
}
