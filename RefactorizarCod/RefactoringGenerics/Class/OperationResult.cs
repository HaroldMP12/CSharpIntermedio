namespace RefactoringGenerics.Class
{
    public class OperationResult <TResult>
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public TResult? Result { get; set; }
    }
}
