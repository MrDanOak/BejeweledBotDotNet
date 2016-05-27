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
                Value = 3,
                Priority = 3,
                Id = 0
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { false, true }, { true, false }, { false, true } },
                Move = new PieceMove() { FromX = 1, FromY = 0, ToX = 1, ToY = 1 },
                Value = 3,
                Priority = 3,
                Id = 1
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 2] { { false, true }, { true, false }, { true, false } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 0, ToY = 1 },
                Value = 3,
                Priority = 3,
                Id = 2
            });


            //2x3 horizontal moves
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { true, false, false }, { false, true, true } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 1, ToY = 0 },
                Value = 3,
                Priority = 2,
                Id = 3
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { false, true, false }, { true, false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 1, ToX = 1, ToY = 1 },
                Value = 3,
                Priority = 2,
                Id = 4
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 3] { { true, true, false }, { false, false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 3,
                Priority = 2,
                Id = 5
            });

            //1x4 vertical
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[1, 4] { {
                        true,
                        true,
                        false,
                        true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 0, ToY = 3 },
                Value = 3,
                Reversible = false,
                Priority = 3,
                Id = 6
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[1, 4] { {
                        true,
                        false,
                        true,
                        true } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 0, ToY = 1 },
                Value = 3,
                Reversible = false,
                Priority = 3,
                Id = 7
            });

            //4x1 horizontal
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 1] { { true }, { true }, { false }, { true } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 3, ToY = 0 },
                Value = 3,
                Reversible = false,
                Priority = 4,
                Id = 8
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 1] { { true }, { false }, { true }, { true } },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 1, ToY = 0 },
                Value = 3,
                Reversible = false,
                Priority = 4,
                Id = 9
            });

            //4x2 vertical
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 2] {{ false, true },{ false, true },{ true, false },{ false, true } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 4,
                Priority = 4,
                Id = 10
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 2] { { false, true }, { true, false }, { false, true }, { false, true } },
                Move = new PieceMove() { FromX = 1, FromY = 0, ToX = 1, ToY = 1 },
                Value = 4,
                Priority = 4,
                Id = 11
            });


            //4x2 horizontal
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 4] { { false, false, true, false }, { true, true, false, true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 4,
                Priority = 5,
                Id = 12
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 4] { { true, false, true, true }, { false, true, false, false } },
                Move = new PieceMove() { FromX = 0, FromY = 1, ToX = 1, ToY = 1 },
                Value = 4,
                Priority = 5,
                Id = 13
            });


            //5x2 vertical
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[5, 2] { { false, true }, { false, true }, { true, false }, { false, true }, { false, true } },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 5,
                Priority = 10,
                Id = 14
            });


            //5x2 horizontal
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[2, 5] { { false, false, true, false, false }, { true, true, false, true, true } },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 5,
                Priority = 10,
                Id = 15
            });


            //3x4 vertical
            //x picks group
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 4] {             
                    {false, false, true, false},
                    {false, false, true, false},
                    {true,  true,  false, true} },
                Move = new PieceMove() { FromX = 2, FromY = 3, ToX = 2, ToY = 2 },
                Value = 5,
                Priority = 7,
                Reversible=false,
                Id = 16
            });
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 4] {
                    {true,  true,  false, true},
                    {false, false, true,  false},
                    {false, false, true,  false}
                },
                Move = new PieceMove() { FromX = 0, FromY = 3, ToX = 0, ToY = 2 },
                Value = 5,
                Priority = 7,
                Reversible = false,
                Id = 17
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 4] {
                    {false, true, false, false},
                    {false, true, false, false},
                    {true,  false,  true, true}
                },
                Move = new PieceMove() { FromX = 2, FromY = 0, ToX = 2, ToY = 1 },
                Value = 5,
                Priority = 7,
                Reversible = false,
                Id = 18
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[3, 4] {
                    {true, false, true, true},
                    {false, true, false, false},
                    {false,  true,  false, false}
                },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 0, ToY = 1 },
                Value = 5,
                Priority = 7,
                Reversible = false,
                Id = 19
            });

            //3x4 horizontal
            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 3] {
                    { true, false, false},
                    { false, true, true},
                    { true,  false, false},
                    { true,  false, false}
                },
                Move = new PieceMove() { FromX = 0, FromY = 0, ToX = 1, ToY = 0 },
                Value = 5,
                Priority = 7,
                Reversible = false,
                Id = 20
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 3] {
                    { true,  false, false},
                    { true,  false, false},
                    { false, true,  true},
                    { true,  false, false}
                },
                Move = new PieceMove() { FromX = 3, FromY = 0, ToX = 2, ToY = 0 },
                Value = 5,
                Priority = 7,
                Reversible = false,
                Id = 21
            });


            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 3] {
                    { false, false, true},
                    { false, false, true},
                    { true,  true,  false},
                    { false, false, true}
                },
                Move = new PieceMove() { FromX = 3, FromY = 2, ToX = 2, ToY = 2 },
                Value = 5,
                Priority = 7,
                Reversible = false,
                Id = 22
            });

            matches.Add(new Matcher()
            {
                MatchMatrix = new bool[4, 3] {
                    { false, false, true},
                    { true,  true,  false},
                    { false, false, true},
                    { false, false, true}
                },
                Move = new PieceMove() { FromX = 0, FromY = 2, ToX = 1, ToY = 2 },
                Value = 5,
                Priority = 7,
                Reversible = false,
                Id = 23
            });
            
            return matches;
        }
    }
}
