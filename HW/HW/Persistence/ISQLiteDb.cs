using SQLite;

namespace HW
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

