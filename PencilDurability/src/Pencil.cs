namespace PencilDurability
{
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Pencil
    {
        private readonly int initialPointDurability;
        private int point;
        private int length;

        public Pencil(int pointDurability, int length)
        {
            this.initialPointDurability = pointDurability;
            this.point = pointDurability;
            this.length = length;
        }

        public void Write(ref string paper, string textToWrite)
        {
            var currentPaper = paper;
            textToWrite.ToList().ForEach(c =>
            {
                if (this.point > 0 && !char.IsWhiteSpace(c))
                {
                    currentPaper += c;

                    DegradePointDurability(c);
                }
                else if (c.Equals('\n'))
                {
                    currentPaper += c;
                }
                else
                {
                    currentPaper += " ";
                }
            });
            paper = currentPaper;
        }

        public void Erase(ref string paper, string textToErase)
        {
            var pattern = $"({textToErase})(?!.*\\1)";
            paper = Regex.Replace(paper, pattern, Regex.Replace(textToErase, ".", " "));
        }

        public void Sharpen()
        {
            if (this.length > 0)
            {
                this.point = this.initialPointDurability;
                this.length--;
            }
        }

        private void DegradePointDurability(char c)
        {
            this.point -= char.IsUpper(c) ? 2 : 1;
        }
    }
}