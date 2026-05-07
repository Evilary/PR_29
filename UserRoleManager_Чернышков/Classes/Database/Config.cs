using Microsoft.EntityFrameworkCore;
using System;

namespace UserRoleManager_Чернышков.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=127.0.0.1;uid=root;pwd=;database=UserRoleManager;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}