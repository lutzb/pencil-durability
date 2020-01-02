namespace PencilDurability
{
    using System.Linq;

    public class Pencil
    {
        private readonly int initialPointDurability;
        private int point;

        public Pencil(int pointDurability)
        {
            point = pointDurability;
            initialPointDurability = pointDurability;
        }

        public void Write(ref string paper, string textToWrite)
        {
            var currentPaper = paper;
            textToWrite.ToList().ForEach(c =>
            {
                if (point > 0 && !char.IsWhiteSpace(c))
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

        public void Sharpen()
        {
            point = initialPointDurability;
        }

        private void DegradePointDurability(char c)
        {
            point -= char.IsUpper(c) ? 2 : 1;
        }
    }
}