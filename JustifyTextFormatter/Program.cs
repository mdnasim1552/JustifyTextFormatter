using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string inputText = "There are many variations of passages of Lorem " +
            "Ipsum available, but the majority have suffered alteration in " +
            "some form, by injected humour, or randomised words which don't " +
            "look even slightly believable. If you are going to use a passage " +
            "of Lorem Ipsum, you need to be sure there isn't anything embarrassing" +
            " hidden in the middle of text. All the Lorem Ipsum generators on the" +
            " Internet tend to repeat predefined chunks as necessary, " +
            "making this the first true generator on the Internet. It " +
            "uses a dictionary of over 200 Latin words, combined with a handful " +
            "of model sentence structures, to generate Lorem Ipsum which looks reasonable." +
            " The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.";
        int maxLineLength = 150;

        string formattedText = JustifyTextFinal(inputText, maxLineLength);

        Console.WriteLine(formattedText);
        Console.ReadKey();
    }

    public static string JustifyTextFinal(string inputText, int maxLineLength)
    {
        string[] words = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string outputText = "", lineBuilder="";
        int lineLength = 0;
        foreach (string word in words)
        {
            if (lineLength + word.Length + 1 > maxLineLength)
            {
                //int spacesToAdd = maxLineLength - lineLength;
                string lineBuilderTemp = "";
                int spacesToAdd = maxLineLength - lineBuilder.Trim().Length;
                if (spacesToAdd != 0)
                {
                    string[] wordslineBuilder = lineBuilder.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int spaceposition = wordslineBuilder.Length / 2-1;
                    for (int j = 0; j < wordslineBuilder.Length; j++)
                    {
                        lineBuilderTemp = lineBuilderTemp+ wordslineBuilder[j]+" ";
                        if (j >= spaceposition && spacesToAdd != 0)
                        {
                            lineBuilderTemp += " ";
                            spacesToAdd--;
                        }
                    }
                    outputText = outputText + lineBuilderTemp.Trim() + "\n\n";
                }
                else
                {
                    outputText = outputText + lineBuilder.Trim() + "\n";
                }
                
                lineBuilder = "";
                lineLength = 0;
            }
            lineBuilder = lineBuilder + word+" ";
            lineLength += word.Length + 1;
        }
        outputText = outputText + lineBuilder.Trim();
        return outputText.Trim();
    }
}