using System;

namespace Demo.Clip03
{
    public class Video : IEquatable<Video>
    {
        public string Title { get; }

        public Video(string title)
        {
            this.Title = title;
        }

        public bool Equals(Video other) =>
            other.GetType() == typeof(Video) &&
            other.Title.Equals(this.Title);

        public override bool Equals(object obj) =>
            obj is Video video && this.Equals(video);

        public override int GetHashCode() =>
            this.Title?.GetHashCode() ?? 0;

        public override string ToString() =>
            this.Title;
    }
}
