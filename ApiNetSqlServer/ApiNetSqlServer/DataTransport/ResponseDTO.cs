namespace ApiNetSqlServer.DataTransport
{
    public class ResponseDTO
    {
        public ResponseDTO(string message = "", bool isSuccess = false, string ObjectResult = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public int Identity { get; set; }
        public string Message { get; set; }
    }
}
