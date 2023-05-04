namespace PicPayLite.Presentation.ResponsePattern
{
    public class TokenResponse
    {
        public string Token { get; private set; }
        private TokenResponse(string token)
            => Token = token;
        
        public static TokenResponse Create(string token) 
            => new TokenResponse(token);
    }
}