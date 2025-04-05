using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
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