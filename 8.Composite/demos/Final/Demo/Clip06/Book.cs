using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip06
{
    public class Book
    {
        public string Title { get; }
        public Name Author { get; }
        public Volume Volumes { get; }

        public Book(string title, Name author, Volume volumes)
        {
            this.Title = title;
            this.Author = author;
            this.Volumes = volumes;
        }

        public override string ToString() =>
            $"{this.Author.Printable}, {this.Title}{this.Volumes.GetLabel(" (Vol. ", ")")}" +
            $"{this.VolumesToString()}";

        private string VolumesToString() => string.Join(string.Empty,
            this.MultipleVolumeTitles
                .Select(title => $"{Environment.NewLine}  - {title}").ToArray());

        private IEnumerable<string> MultipleVolumeTitles =>
            this.Volumes.GetTitles(1);
    }
}
