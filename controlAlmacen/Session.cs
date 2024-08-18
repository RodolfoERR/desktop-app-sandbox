namespace controlAlmacen
{
    public static class Session
    {
        public static string Accesstoken { get; set; }
        public static int UserId { get; set; }
        public static string UserName { get; set; }

        // Método para guardar los datos de sesión
        public static void SaveSessionData(string token, int userId, string userName)
        {
            Accesstoken = token;
            UserId = userId;
            UserName = userName;
        }

        public static void ClearSession()
        {
            Accesstoken = null;
            UserId = 0;
            UserName = null;
        }
    }
}