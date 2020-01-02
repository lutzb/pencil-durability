namespace PencilDurability
{
    using System.Linq;

    public class Pencil
    {
        private int point;

        public Pencil(int pointDurability)
        {
            point = pointDurability;
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

        private void DegradePointDurability(char c)
        {
            if (char.IsUpper(c))
            {
                point -= 2;
            }
            else
            {
                point--;
            }
        }
    }
}