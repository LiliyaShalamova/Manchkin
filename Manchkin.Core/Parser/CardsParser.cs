using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Microsoft.VisualBasic.FileIO;

namespace Manchkin.Core.Parser;

internal abstract class CardParser
{
    private readonly string _delimiters = ";";
    private readonly string[] _commentTokens = ["/*"];
    private protected string CurrentDirectory = Directory.GetCurrentDirectory();

    protected TextFieldParser GetTextFieldParser(string path)
    {
        var parser = new TextFieldParser(path);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(_delimiters);
        parser.CommentTokens = _commentTokens;

        return parser;
    }
}