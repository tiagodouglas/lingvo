namespace Lingvo.Infrastructure.Extensions;

public static class DapperExtensions
{
    public static string AddPagination(this string sql)
    {
        return $@"
                {sql} 
                OFFSET (@Page - 1) * @Rows ROWS
		        FETCH NEXT @Rows ROWS ONLY
            ";
    }
}
