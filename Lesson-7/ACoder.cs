using System.Text;

namespace Lesson_7
{
    public class ACoder : Coder, ICoder
    {
        private string? _Text;
        private bool _IsEncrypted = false;
        private readonly string? _Primary;

        public override string? Text { get { return this._Text; } set { this._Text = value; } }
        public override bool IsEncrypted { get {return this._IsEncrypted; } set {this._IsEncrypted = value; } }

        public ACoder(string text) : base(text)
        {
            this._Primary = text;
        }

        public override string Encode()
        {
            this.IsEncrypted = true;
            this.Text  = base.Encode();
            return this.Text;
        }

        public override string Decode()
        {
            this.Text = this._Primary;
            this.IsEncrypted = false;
            return base.Decode();
        }
    }
}
