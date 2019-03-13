using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using AssetStudioCore.Classes;

namespace AzurLaneLive2DExtract
{
    public class ImportedKeyframedAnimation
    {
        public string Name { get; set; }
        public float SampleRate { get; set; }
        public float Duration { get; set; }
        public bool Loop { get; set; }

        public List<ImportedAnimationKeyframedTrack> TrackList { get; set; } = new List<ImportedAnimationKeyframedTrack>();
        public List<AnimationEvent> EventList { get; set; }

        public ImportedAnimationKeyframedTrack FindTrack(string name)
        {
            var track = TrackList.Find(x => x.Name == name);
            if (track == null)
            {
                track = new ImportedAnimationKeyframedTrack { Name = name };
                TrackList.Add(track);
            }
            return track;
        }
    }

    public class ImportedKeyframe<T>
    {
        public float time { get; set; }
        public T value { get; set; }
        public T inSlope { get; set; }
        public T outSlope { get; set; }

        public ImportedKeyframe(float time, T value)
        {
            this.time = time;
            this.value = value;
        }

        public ImportedKeyframe(float time, T value, T inSlope, T outSlope)
        {
            this.time = time;
            this.value = value;
            this.inSlope = inSlope;
            this.outSlope = outSlope;
        }
    }

    public class ImportedAnimationKeyframedTrack
    {
        public string Name { get; set; }
        public string Target { get; set; }
        public List<ImportedKeyframe<float>> Curve = new List<ImportedKeyframe<float>>();
    }
}
