public class OperationTable
{
    public delegate int BinaryOp(int a, int b);

    private int startRow;
    private int endRow;
    private int startCol;
    private int endCol;
    private BinaryOp operation;

    public OperationTable(int start_row, int end_row,
                          int start_col, int end_col,
                          BinaryOp op)
    {
        startRow = start_row;
        endRow = end_row;
        startCol = start_col;
        endCol = end_col;
        operation = op;
    }

    public void Print()
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                Console.Write(operation(i, j).ToString().PadLeft(5));
            }
            Console.WriteLine();
        }
    }
}
