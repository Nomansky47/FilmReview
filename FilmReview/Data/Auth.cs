namespace FilmReview.Data
{
    public static class Auth
    {
        public static void setAdmin(this HttpContext context, bool b)
        {
            if (b) context.Session.SetInt32("isAdmin", 0);
            else context.Session.SetInt32("isAdmin", 1);
        }
        public static bool? isAdmin(this HttpContext context)
        {
            if (context.Session.GetInt32("isAdmin") == 0)
                return true;
            else if (context.Session.GetInt32("isAdmin") == 1) return false;
            else return null;

        }
    }
}
