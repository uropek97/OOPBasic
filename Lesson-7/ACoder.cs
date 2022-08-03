using System.Text;

namespace Lesson_7
{
    public class ACoder : Coder, ICoder
    {
        private string? _Text;
        private bool _IsEncrypted = false;
        private readonly string? _Primary;

        public override string? Text { get; set; }
        public override bool IsEncrypted { get; set; }

        public readonly string? Primary;

        public ACoder(string text) : base(text)
        {
            this.Primary = text;
        }

        public override string Encode()
        {
            this.IsEncrypted = true;
            this.Text  = base.Encode();
            return this.Text;
        }

        public override string Decode()
        {
            this.Text = this.Primary;
            return base.Decode();
        }
    }
}
