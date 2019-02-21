namespace Sudoku
{
    public class SudokuTah
    {

        //Properties
        private int index;
        private int original;
        private int next;

        public SudokuTah(int index, int original, int next)
        {
            this.index = index;
            this.original = original;
            this.next = next;
        }

        //FromString, ToString
        public static SudokuTah FromString(string[] data)
        {
            return new SudokuTah(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));
        }
        public override string ToString()
        {
            return index + "-" + original + "-" + next;
        }

        //Getters
        public int GetIndex()
        {
            return index;
        }
        public int GetOriginal()
        {
            return original;
        }
        public int GetNext()
        {
            return next;
        }

    }
}
