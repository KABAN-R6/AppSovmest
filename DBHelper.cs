﻿using MySqlConnector;

namespace AppSovmest;

public class DBHelper
{
    public MySqlConnectionStringBuilder _connectionString { get; }

    public DBHelper()
    {
        _connectionString = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "pro2",
            UserID = "root",
            Password = "123456"

        };
    }
}