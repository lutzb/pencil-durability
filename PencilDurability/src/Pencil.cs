namespace PencilDurability
{
    public class Pencil
    {
        public void Write(ref string paper, string textToWrite)
        {
            paper += textToWrite;
        }
    }
}