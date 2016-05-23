using System.Collections.Generic;

namespace DotNetBejewelledBot
{
    public class MatchBuilder
    {
        public MatchBuilder()
        {
        }
        public List<Matcher> GetMatchers()
        {
            List<Matcher> matches = new List<Matcher>();

            //3x2 vertical moves
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { false, true }, { false, true }, { true, false } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 3
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { true, false }, { true, false }, { false, true } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 3
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { false, true }, { true, false }, { false, true } },
                Move = new PieceMove() { FromX = 1, FromY = 0, ToX = 1, ToY = 1 },
                Value = 3
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { true, false }, { false, true }, { true, false } },
                Move = new PieceMove() { FromX = 1, FromY = 0, ToX = 1, ToY = 1 },
                Value = 3
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { false, true }, { true, false }, { true, false } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 0, ToY = 1 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { true, false }, { false, true }, { false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 0, ToY = 1 },
                Value = 3
            });

            //2x3 horizontal moves
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { true, false, false }, { false, true, true } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 1, ToY = 0 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { false, true, true }, { true, false, false } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 1, ToY = 0 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { false, true, false }, { true, false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 1, ToX = 1, ToY = 1 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { true, false, true }, { false, true, false } },
                Move = new PieceMove() { FromX = 0, FromY = 1, ToX = 1, ToY = 1 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { true, true, false }, { false, false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { false, false, true }, { true, true, false } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 3
            });

            //1x4 vertical
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[1, 4] { { true, true, false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 0, ToY = 3 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[1, 4] { { true, false, true, true } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 0, ToY = 1 },
                Value = 3
            });

            //4x1 horizontal
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 1] { { true }, { true }, { false }, { true } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 3, ToY = 0 },
                Value = 3
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 1] { { true }, { false }, { true }, { true } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 1, ToY = 0 },
                Value = 3
            });

            //4x2 vertical
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 2] { { false, true }, { false, true }, { true, false },{ false, true } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 4
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 2] { { true, false }, { true, false }, { false, true }, { true, false } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 4
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 2] { { false, true }, { true, false }, { false, true }, { false, true } },
                Move = new PieceMove() { FromX = 1, FromY = 0, ToX = 1, ToY = 1 },
                Value = 4
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 2] { { true, false }, { false, true }, { true, false }, { true, false } },
                Move = new PieceMove() { FromX = 1, FromY = 0, ToX = 1, ToY = 1 },
                Value = 4
            });

            //4x2 horizontal
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 4] { { false, false, true, false }, { true, true, false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 4
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 4] {  { true, true, false, true }, { false, false, true, false } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 4
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 4] { { true, false, true, true }, { false, true, false, false } },
                Move = new PieceMove() { FromX = 0, FromY = 1, ToX = 1, ToY = 1 },
                Value = 4
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 4] { { true, false, true, true }, { false, true, false, false } },
                Move = new PieceMove() { FromX = 0, FromY = 1, ToX = 1, ToY = 1 },
                Value = 4
            });

            //5x2 vertical
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[5, 2] { { false, true }, { false, true }, { true, false }, { false, true }, { false, true } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 5
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[5, 2] { { true, false }, { true, false }, { false, true }, { true, false }, { true, false } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 5
            });

            //5x2 horizontal
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 5] { { false, false, true, false, false }, { true, true, false, true, true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 5
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 5] { { true, true, false, true, true }, { false, false, true, false, false } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 5
            });

            return matches;
        }
    }
}
